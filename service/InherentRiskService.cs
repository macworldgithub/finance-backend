using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class InherentRiskService
{
    private readonly IMongoCollection<InherentRiskAssessment> _collection;

    public InherentRiskService(IOptions<MongoDbSettings> settings)
    {
        var mongoClient = new MongoClient(settings.Value.ConnectionString);
        var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
        _collection = database.GetCollection<InherentRiskAssessment>(settings.Value.InherentRiskCollectionName);
    }

    public async Task<List<InherentRiskAssessment>> GetAsync()
        => await _collection.Find(_ => true).ToListAsync();

    public async Task<InherentRiskAssessment?> GetAsync(string id)
        => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(InherentRiskAssessment inherentRisk)
    {
        await _collection.InsertOneAsync(inherentRisk);
    }

    public async Task UpdateAsync(string id, InherentRiskAssessment inherentRiskIn)
    {
        inherentRiskIn.Id = id; // make sure Id is set
        await _collection.ReplaceOneAsync(x => x.Id == id, inherentRiskIn);
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }
}