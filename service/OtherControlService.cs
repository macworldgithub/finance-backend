using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class OtherControlService
{
    private readonly IMongoCollection<OtherControlEnvironment> _collection;

    public OtherControlService(IOptions<MongoDbSettings> settings)
    {
        var mongoClient = new MongoClient(settings.Value.ConnectionString);
        var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
        _collection = database.GetCollection<OtherControlEnvironment>(settings.Value.OtherControlEnvironmentCollectionName);
    }

    public async Task<List<OtherControlEnvironment>> GetAsync()
        => await _collection.Find(_ => true).ToListAsync();

    public async Task<OtherControlEnvironment?> GetAsync(string id)
        => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(OtherControlEnvironment otherControl)
    {
        await _collection.InsertOneAsync(otherControl);
    }

    public async Task UpdateAsync(string id, OtherControlEnvironment otherControlIn)
    {
        otherControlIn.Id = id; // make sure Id is set
        await _collection.ReplaceOneAsync(x => x.Id == id, otherControlIn);
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }
}