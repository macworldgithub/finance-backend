using Microsoft.Extensions.Options;
using MongoDB.Driver;
using YourAppName.Models;

public class ProcessesService
{
    private readonly IMongoCollection<Processes> _collection;

    public ProcessesService(IOptions<MongoDbSettings> settings)
    {
        var mongoClient = new MongoClient(settings.Value.ConnectionString);
        var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
        _collection = database.GetCollection<Processes>(settings.Value.ProcessCollectionName);
    }

    public async Task<List<Processes>> GetAsync()
        => await _collection.Find(_ => true).ToListAsync();

    public async Task<Processes?> GetAsync(string id)
        => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Processes process)
    {
        await _collection.InsertOneAsync(process);
    }

    public async Task UpdateAsync(string id, Processes processIn)
    {
        processIn.Id = id; // make sure Id is set
        await _collection.ReplaceOneAsync(x => x.Id == id, processIn);
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }
}