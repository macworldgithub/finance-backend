
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
public class ControlActivity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("no")]
    public double No { get; set; }

    [BsonElement("mainProcess")]
    public string MainProcess { get; set; } = string.Empty;

    [BsonElement("controlObjectives")]
    public string ControlObjectives { get; set; } = string.Empty;

    [BsonElement("controlRef")]
    public string ControlRef { get; set; } = string.Empty;

    [BsonElement("controlDefinition")]
    public string ControlDefinition { get; set; } = string.Empty;

    [BsonElement("controlDescription")]
    public string ControlDescription { get; set; } = string.Empty;

    [BsonElement("controlResponsibility")]
    public string ControlResponsibility { get; set; } = string.Empty;

    [BsonElement("keyControl")]
    public string KeyControl { get; set; } = string.Empty;

    [BsonElement("zeroTolerance")]
    public string ZeroTolerance { get; set; } = string.Empty;
}
