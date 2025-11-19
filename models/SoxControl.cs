
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
public class SOXControl
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("no")]
    public double No { get; set; }

    [BsonElement("mainProcess")]
    public string MainProcess { get; set; } = string.Empty;

    [BsonElement("SOX Control Activity")]
    public string SOXControlActivity { get; set; } = string.Empty;
}
