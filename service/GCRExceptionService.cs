using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class GCRExceptionService
{
    private readonly IMongoCollection<GRCExceptionLog> _collection;

    public GCRExceptionService(IOptions<MongoDbSettings> settings)
    {
        var mongoClient = new MongoClient(settings.Value.ConnectionString);
        var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
        _collection = database.GetCollection<GRCExceptionLog>(settings.Value.GRCExceptionLogCollectionName);
    }

    public async Task<List<GRCExceptionLog>> GetAsync()
        => await _collection.Find(_ => true).ToListAsync();

    public async Task<GRCExceptionLog?> GetAsync(string id)
        => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(GRCExceptionLog gcrException)
    {
        await _collection.InsertOneAsync(gcrException);
    }

    public async Task UpdateAsync(string id, GRCExceptionLog gcrExceptionIn)
    {
        gcrExceptionIn.Id = id; // make sure Id is set
        await _collection.ReplaceOneAsync(x => x.Id == id, gcrExceptionIn);
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }
}