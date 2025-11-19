
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class InternalAuditTest
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("no")]
    public double No { get; set; }

    [BsonElement("mainProcess")]
    public string MainProcess { get; set; } = string.Empty;

    [BsonElement("check")]
    public string Check { get; set; } = string.Empty;

    [BsonElement("Internal Audit Test")]
    public string AuditTest { get; set; } = string.Empty;

    [BsonElement("Sample Size")]
    public string SampleSize { get; set; } = string.Empty;
}
