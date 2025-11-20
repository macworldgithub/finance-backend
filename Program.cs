// Program.cs
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using DotNetEnv;
using Microsoft.Extensions.Options;

DotNetEnv.Env.TraversePath().Load();

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddOpenApi();

// 👇 Add this to enable controllers
builder.Services.AddControllers();

// Bind MongoDB settings from appsettings.json OR .env (via Configuration)
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDB"));

// Register MongoClient as singleton (connection pooling)
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    return new MongoClient(settings.ConnectionString);
});

   builder.Services.AddScoped<ControlActivitiesService>();
   builder.Services.AddScoped<ControlAssessmentService>();
    builder.Services.AddScoped<ControlEnvironmentService>();
    builder.Services.AddScoped<FinancialStatementService>();
    builder.Services.AddScoped<GCRExceptionService>();
    builder.Services.AddScoped<InherentRiskService>();
    builder.Services.AddScoped<InternalAuditService>();
    builder.Services.AddScoped<OtherControlService>();
    builder.Services.AddScoped<OwnershipService>();
    builder.Services.AddScoped<ProcessesService>();
    builder.Services.AddScoped<ResidualRiskService>();
    builder.Services.AddScoped<RiskResponseService>();
    builder.Services.AddScoped<SoxControlService>();
    



var app = builder.Build();

// OpenAPI / Swagger in development
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// 👇 Add this to map your controllers' routes
app.MapControllers();

app.Run();
// Models & Settings
public class MongoDbSettings
{
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;





    // 👇 add these
    public string ControlActivitiesCollectionName { get; set; } = "ControlActivities";
    public string ControlAssessmentsCollectionName { get; set; } = "ControlAssessments";
    public string ControlEnvironmentsCollectionName { get; set; } = "ControlEnvironments";
    public string FinancialStatementAssertionsCollectionName { get; set; } = "FinancialStatementAssertions";

    public string GRCExceptionLogCollectionName { get; set; } = "GRCExceptionLogs";

    public string InherentRiskCollectionName { get; set; } = "InherentRisks";
    public string InternalAuditTestCollectionName { get; set; } = "InternalAuditTests";

    public string OtherControlEnvironmentCollectionName { get; set; } = "OtherControlEnvironments";
    public string OwnershipCollectionName { get; set; } = "Ownerships";
    public string ProcessCollectionName { get; set; } = "Processes";
    public string ResidualRiskAssessmentCollectionName { get; set; } = "ResidualRiskAssessments";

    public string RiskResponseCollectionName { get; set; } = "RiskResponses";

    public string SoxControlCollectionName { get; set; } = "SoxControls";
}
