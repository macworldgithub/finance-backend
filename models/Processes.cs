// Models/Processes.cs
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace YourAppName.Models
{
    // MongoDB Settings (from appsettings.json or .env)
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }

    // Main document schema
    public class Processes
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public int No { get; set; }

        [BsonElement("mainProcess")]
        public string MainProcess { get; set; } = string.Empty;

        [BsonElement("processDescription")]
        public string ProcessDescription { get; set; } = string.Empty;

        [BsonElement("processObjectives")]
        public string ProcessObjectives { get; set; } = string.Empty;

        [BsonElement("processSeverityLevels")]
        public string ProcessSeverityLevels { get; set; } = string.Empty;
    }


public class GRCExceptionLog
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("no")]
    public double No { get; set; }

    [BsonElement("mainProcess")]
    public string MainProcess { get; set; } = string.Empty;

    [BsonElement("GRC Adequacy")]
    public string GRCAdequacy { get; set; } = string.Empty;

    [BsonElement("GRC Effectiveness")]
    public string GRCEffectiveness { get; set; } = string.Empty;

    [BsonElement("Explanation")]
    public string Explanation { get; set; } = string.Empty;
}



    // Input DTO (used in POST/PUT so client doesn't send Id)
    public record ProcessInput(
        int No,
        string MainProcess,
        string ProcessDescription,
        string ProcessObjectives,
        string ProcessSeverityLevels);
}