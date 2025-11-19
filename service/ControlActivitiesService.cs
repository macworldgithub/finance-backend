using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class ControlActivitiesService
{
    private readonly IMongoCollection<ControlActivity> _collection;

    public ControlActivitiesService(IOptions<MongoDbSettings> settings)
    {
        var mongoClient = new MongoClient(settings.Value.ConnectionString);
        var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
        _collection = database.GetCollection<ControlActivity>(settings.Value.ControlActivitiesCollectionName);
    }

    public async Task<List<ControlActivity>> GetAsync()
        => await _collection.Find(_ => true).ToListAsync();

    public async Task<ControlActivity?> GetAsync(string id)
        => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(ControlActivity controlActivity)
    {
        await _collection.InsertOneAsync(controlActivity);
    }

    public async Task UpdateAsync(string id, ControlActivity controlActivityIn)
    {
        controlActivityIn.Id = id; // make sure Id is set
        await _collection.ReplaceOneAsync(x => x.Id == id, controlActivityIn);
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }
}
