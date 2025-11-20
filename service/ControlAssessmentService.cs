using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class ControlAssessmentService
{
    private readonly IMongoCollection<ControlAssessment> _collection;

    public ControlAssessmentService(IOptions<MongoDbSettings> settings)
    {
        var mongoClient = new MongoClient(settings.Value.ConnectionString);
        var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
        _collection = database.GetCollection<ControlAssessment>(settings.Value.ControlAssessmentsCollectionName);
    }

    public async Task<List<ControlAssessment>> GetAsync()
        => await _collection.Find(_ => true).ToListAsync();

    public async Task<ControlAssessment?> GetAsync(string id)
        => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(ControlAssessment controlAssessment)
    {
        await _collection.InsertOneAsync(controlAssessment);
    }

    public async Task UpdateAsync(string id, ControlAssessment controlAssessmentIn)
    {
        controlAssessmentIn.Id = id; // make sure Id is set
        await _collection.ReplaceOneAsync(x => x.Id == id, controlAssessmentIn);
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }
}