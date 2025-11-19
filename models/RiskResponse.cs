
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class RiskResponse
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("no")]
    public double No { get; set; }

    [BsonElement("mainProcess")]
    public string MainProcess { get; set; } = string.Empty;

    [BsonElement("typeOfRiskResponse")]
    public string TypeOfRiskResponse { get; set; } = string.Empty;
}