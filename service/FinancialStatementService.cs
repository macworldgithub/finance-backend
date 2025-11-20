using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class FinancialStatementService
{
    private readonly IMongoCollection<FinancialStatementAssertion> _collection;

    public FinancialStatementService(IOptions<MongoDbSettings> settings)
    {
        var mongoClient = new MongoClient(settings.Value.ConnectionString);
        var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
        _collection = database.GetCollection<FinancialStatementAssertion>(settings.Value.FinancialStatementAssertionsCollectionName);
    }

    public async Task<List<FinancialStatementAssertion>> GetAsync()
        => await _collection.Find(_ => true).ToListAsync();

    public async Task<FinancialStatementAssertion?> GetAsync(string id)
        => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(FinancialStatementAssertion financialStatementAssertion)
    {
        await _collection.InsertOneAsync(financialStatementAssertion);
    }

    public async Task UpdateAsync(string id, FinancialStatementAssertion financialStatementAssertionIn)
    {
        financialStatementAssertionIn.Id = id; // make sure Id is set
        await _collection.ReplaceOneAsync(x => x.Id == id, financialStatementAssertionIn);
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }
}