
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


public class ControlAssessment
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("no")]
    public double No { get; set; }

    [BsonElement("mainProcess")]
    public string MainProcess { get; set; } = string.Empty;

    [BsonElement("levelOfResponsibility-Operating Level (Entity / Activity)")]
    public string LevelOfResponsibility { get; set; } = string.Empty;

    [BsonElement("COSO Principle #")]
    public string COSOPrinciple { get; set; } = string.Empty;

    [BsonElement("operationalApproach (Automated / Manual)")]
    public string OperationalApproach { get; set; } = string.Empty;

    [BsonElement("operationalFrequency")]
    public string OperationalFrequency { get; set; } = string.Empty;

    [BsonElement("controlClassification (Preventive / Detective / Corrective)")]
    public string ControlClassification { get; set; } = string.Empty;
}
