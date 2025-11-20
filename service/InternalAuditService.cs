using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class InternalAuditService
{
    private readonly IMongoCollection<InternalAuditTest> _collection;

    public InternalAuditService(IOptions<MongoDbSettings> settings)
    {
        var mongoClient = new MongoClient(settings.Value.ConnectionString);
        var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
        _collection = database.GetCollection<InternalAuditTest>(settings.Value.InternalAuditTestCollectionName);
    }

    public async Task<List<InternalAuditTest>> GetAsync()
        => await _collection.Find(_ => true).ToListAsync();

    public async Task<InternalAuditTest?> GetAsync(string id)
        => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(InternalAuditTest internalAudit)
    {
        await _collection.InsertOneAsync(internalAudit);
    }

    public async Task UpdateAsync(string id, InternalAuditTest internalAuditIn)
    {
        internalAuditIn.Id = id; // make sure Id is set
        await _collection.ReplaceOneAsync(x => x.Id == id, internalAuditIn);
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }
}