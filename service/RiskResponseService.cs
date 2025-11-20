using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class RiskResponseService
{
    private readonly IMongoCollection<RiskResponse> _collection;

    public RiskResponseService(IOptions<MongoDbSettings> settings)
    {
        var mongoClient = new MongoClient(settings.Value.ConnectionString);
        var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
        _collection = database.GetCollection<RiskResponse>(settings.Value.RiskResponseCollectionName);
    }

    public async Task<List<RiskResponse>> GetAsync()
        => await _collection.Find(_ => true).ToListAsync();

    public async Task<RiskResponse?> GetAsync(string id)
        => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(RiskResponse riskResponsePlan)
    {
        await _collection.InsertOneAsync(riskResponsePlan);
    }

    public async Task UpdateAsync(string id, RiskResponse riskResponsePlanIn)
    {
        riskResponsePlanIn.Id = id; // make sure Id is set
        await _collection.ReplaceOneAsync(x => x.Id == id, riskResponsePlanIn);
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }
}