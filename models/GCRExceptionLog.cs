using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


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

