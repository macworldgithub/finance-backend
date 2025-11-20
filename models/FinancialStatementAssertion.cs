
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


public class FinancialStatementAssertion
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("no")]
    public double No { get; set; }

    [BsonElement("mainProcess")]
    public string MainProcess { get; set; } = string.Empty;

    [BsonElement("Internal Control Over Financial Reporting?")]
    public string InternalControlOverFinancialReporting { get; set; } = string.Empty;

    [BsonElement("Completeness")]
    public string Completeness { get; set; } = string.Empty;

    [BsonElement("Accuracy")]
    public string Accuracy { get; set; } = string.Empty;

    [BsonElement("Authorization")]
    public string Authorization { get; set; } = string.Empty;

    [BsonElement("Cutoff")]
    public string Cutoff { get; set; } = string.Empty;

    [BsonElement("Classification and Understandability")]
    public string ClassificationAndUnderstandability { get; set; } = string.Empty;

    [BsonElement("Existence")]
    public string Existence { get; set; } = string.Empty;

    [BsonElement("Rights and Obligations")]
    public string RightsAndObligations { get; set; } = string.Empty;

    [BsonElement("Valuation and Allocation")]
    public string ValuationAndAllocation { get; set; } = string.Empty;

    [BsonElement("Presentation / Disclosure")]
    public string PresentationDisclosure { get; set; } = string.Empty;
}
