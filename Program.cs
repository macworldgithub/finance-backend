// Program.cs
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using DotNetEnv;
using Microsoft.Extensions.Options;

// Load .env as early as possible
DotNetEnv.Env.TraversePath().Load();

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddOpenApi();

// Bind MongoDB settings from appsettings.json OR .env (via Configuration)
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDB"));

// Register MongoClient as singleton (connection pooling)
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    return new MongoClient(settings.ConnectionString);
});

// Register the Processes collection (creates it automatically on first insert if missing)
builder.Services.AddScoped<IMongoCollection<Processes>>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    var client = sp.GetRequiredService<IMongoClient>();
    var database = client.GetDatabase(settings.DatabaseName);

    // This line ensures the collection exists (MongoDB creates it lazily on first write)
    var collection = database.GetCollection<Processes>("Processes");

    // Optional: create indexes here if you want them
    // var indexKeys = Builders<Processes>.IndexKeys.Ascending(x => x.No);
    // collection.Indexes.CreateOne(new CreateIndexModel<Processes>(indexKeys, new CreateIndexOptions { Unique = true }));

    return collection;
});

var app = builder.Build();

// ──────────────────────────────────────────────────────────────
// API Endpoints for Processes

// Root
app.MapGet("/", () => new { Message = "Processes API is running!", Date = DateTime.UtcNow });

// Get all processes
app.MapGet("/processes", async (IMongoCollection<Processes> collection) =>
{
    var processes = await collection.Find(_ => true).ToListAsync();
    return Results.Ok(processes);
});

// Get by Id (ObjectId) or by No
app.MapGet("/processes/{id}", async (string id, IMongoCollection<Processes> collection) =>
{
    // Try as ObjectId first
    var filter = Builders<Processes>.Filter.Eq("_id", ObjectId.Parse(id));
    var process = await collection.Find(filter).FirstOrDefaultAsync();

    if (process == null && int.TryParse(id, out var no))
    {
        // Fallback: search by No field
        process = await collection.Find(p => p.No == no).FirstOrDefaultAsync();
    }

    return process is null
        ? Results.NotFound(new { Message = "Process not found" })
        : Results.Ok(process);
});

// Create a new process (this will create the collection if it doesn't exist)
app.MapPost("/processes", async (ProcessInput input, IMongoCollection<Processes> collection) =>
{
    var process = new Processes
    {
        No = input.No,
        MainProcess = input.MainProcess,
        ProcessDescription = input.ProcessDescription,
        ProcessObjectives = input.ProcessObjectives,
        ProcessSeverityLevels = input.ProcessSeverityLevels
    };

    await collection.InsertOneAsync(process);

    return Results.Created($"/processes/{process.Id}", new
    {
        Message = "Process created successfully!",
        Data = process
    });
});

// Update process by No (or by Id if you prefer)
app.MapPut("/processes/{no:int}", async (int no, ProcessInput input, IMongoCollection<Processes> collection) =>
{
    var update = Builders<Processes>.Update
        .Set(p => p.MainProcess, input.MainProcess)
        .Set(p => p.ProcessDescription, input.ProcessDescription)
        .Set(p => p.ProcessObjectives, input.ProcessObjectives)
        .Set(p => p.ProcessSeverityLevels, input.ProcessSeverityLevels);

    var result = await collection.UpdateOneAsync(p => p.No == no, update);

    if (result.MatchedCount == 0)
        return Results.NotFound(new { Message = $"Process with No {no} not found" });

    var updated = await collection.Find(p => p.No == no).FirstOrDefaultAsync();
    return Results.Ok(new { Message = "Process updated successfully", Data = updated });
});

// Delete process by No
app.MapDelete("/processes/{no:int}", async (int no, IMongoCollection<Processes> collection) =>
{
    var result = await collection.DeleteOneAsync(p => p.No == no);

    return result.DeletedCount == 0
        ? Results.NotFound(new { Message = $"Process with No {no} not found" })
        : Results.Ok(new { Message = $"Process with No {no} deleted successfully" });
});

// ──────────────────────────────────────────────────────────────
// OpenAPI / Swagger in development
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.Run();

// ──────────────────────────────────────────────────────────────
// Models & Settings

public class MongoDbSettings
{
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
}

// Your ODM schema
public class Processes
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public int No { get; set; }

    [BsonElement("mainProcess")]
    public string MainProcess { get; set; } = string.Empty;

    [BsonElement("processDescription")]
    public string ProcessDescription { get; set; } = string.Empty;

    [BsonElement("processObjectives")]
    public string ProcessObjectives { get; set; } = string.Empty;

    [BsonElement("processSeverityLevels")]
    public string ProcessSeverityLevels { get; set; } = string.Empty;
}

// Input DTO (so Id is not required from client)
public record ProcessInput(
    int No,
    string MainProcess,
    string ProcessDescription,
    string ProcessObjectives,
    string ProcessSeverityLevels);