using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class ControlEnvironmentService
{
    private readonly IMongoCollection<ControlEnvironment> _collection;

    public ControlEnvironmentService(IOptions<MongoDbSettings> settings)
    {
        var mongoClient = new MongoClient(settings.Value.ConnectionString);
        var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
        _collection = database.GetCollection<ControlEnvironment>(settings.Value.ControlEnvironmentsCollectionName);
    }

    public async Task<List<ControlEnvironment>> GetAsync()
        => await _collection.Find(_ => true).ToListAsync();

    public async Task<ControlEnvironment?> GetAsync(string id)
        => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(ControlEnvironment controlEnvironment)
    {
        await _collection.InsertOneAsync(controlEnvironment);
    }

    public async Task UpdateAsync(string id, ControlEnvironment controlEnvironmentIn)
    {
        controlEnvironmentIn.Id = id; // make sure Id is set
        await _collection.ReplaceOneAsync(x => x.Id == id, controlEnvironmentIn);
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }
}