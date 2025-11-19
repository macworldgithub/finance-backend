using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


  public class Ownership
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("no")]
    public double No { get; set; }   // 5.1 → double

    [BsonElement("mainProcess")]
    public string MainProcess { get; set; } = string.Empty;

    [BsonElement("activity")]
    public string Activity { get; set; } = string.Empty;

    [BsonElement("process")]
    public string Process { get; set; } = string.Empty;

    [BsonElement("processStage")]
    public string ProcessStage { get; set; } = string.Empty;

    [BsonElement("functions")]
    public string Functions { get; set; } = string.Empty;

    [BsonElement("clientSegmentOrFunctionalSegment")]
    public string ClientSegmentOrFunctionalSegment { get; set; } = string.Empty;

    [BsonElement("operationalUnit")]
    public string OperationalUnit { get; set; } = string.Empty;

    [BsonElement("division")]
    public string Division { get; set; } = string.Empty;

    [BsonElement("entity")]
    public string Entity { get; set; } = string.Empty;

    [BsonElement("unitOrDepartment")]
    public string UnitOrDepartment { get; set; } = string.Empty;

    [BsonElement("productClass")]
    public string ProductClass { get; set; } = string.Empty;

    [BsonElement("productName")]
    public string ProductName { get; set; } = string.Empty;
}