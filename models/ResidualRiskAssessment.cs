

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class ResidualRiskAssessment
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("no")]
    public double No { get; set; }

    [BsonElement("mainProcess")]
    public string MainProcess { get; set; } = string.Empty;

    [BsonElement("riskType")]
    public string RiskType { get; set; } = string.Empty;

    [BsonElement("riskDescription")]
    public string RiskDescription { get; set; } = string.Empty;

    [BsonElement("severity/ Impact")]
    public string SeverityImpact { get; set; } = string.Empty;

    [BsonElement("probability/ Likelihood")]
    public string ProbabilityLikelihood { get; set; } = string.Empty;

    [BsonElement("classification")]
    public string Classification { get; set; } = string.Empty;
}
