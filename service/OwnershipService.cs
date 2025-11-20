using Microsoft.Extensions.Options;
using MongoDB.Driver;


public class OwnershipService
{
    private readonly IMongoCollection<Ownership> _collection;

    public OwnershipService(IOptions<MongoDbSettings> settings)
    {
        var mongoClient = new MongoClient(settings.Value.ConnectionString);
        var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
        _collection = database.GetCollection<Ownership>(settings.Value.OwnershipCollectionName);
    }

    public async Task<List<Ownership>> GetAsync()
        => await _collection.Find(_ => true).ToListAsync();

    public async Task<Ownership?> GetAsync(string id)
        => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Ownership ownership)
    {
        await _collection.InsertOneAsync(ownership);
    }

    public async Task UpdateAsync(string id, Ownership ownershipIn)
    {
        ownershipIn.Id = id; // make sure Id is set
        await _collection.ReplaceOneAsync(x => x.Id == id, ownershipIn);
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }
}