using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class ResidualRiskService
{
    private readonly IMongoCollection<ResidualRiskAssessment> _collection;

    public ResidualRiskService(IOptions<MongoDbSettings> settings)
    {
        var mongoClient = new MongoClient(settings.Value.ConnectionString);
        var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
        _collection = database.GetCollection<ResidualRiskAssessment>(settings.Value.ResidualRiskAssessmentCollectionName);
    }

    public async Task<List<ResidualRiskAssessment>> GetAsync()
        => await _collection.Find(_ => true).ToListAsync();

    public async Task<ResidualRiskAssessment?> GetAsync(string id)
        => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(ResidualRiskAssessment residualRisk)
    {
        await _collection.InsertOneAsync(residualRisk);
    }

    public async Task UpdateAsync(string id, ResidualRiskAssessment residualRiskIn)
    {
        residualRiskIn.Id = id; // make sure Id is set
        await _collection.ReplaceOneAsync(x => x.Id == id, residualRiskIn);
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }
}