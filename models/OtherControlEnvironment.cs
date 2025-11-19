using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class OtherControlEnvironment
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("no")]
    public double No { get; set; }

    [BsonElement("mainProcess")]
    public string MainProcess { get; set; } = string.Empty;

    [BsonElement("responsibilityDelegationMatrix")]
    public string ResponsibilityDelegationMatrix { get; set; } = string.Empty;

    [BsonElement("segregationOfDuties")]
    public string SegregationOfDuties { get; set; } = string.Empty;

    [BsonElement("reportingLines")]
    public string ReportingLines { get; set; } = string.Empty;

    [BsonElement("mission")]
    public string Mission { get; set; } = string.Empty;

    [BsonElement("visionAndValues")]
    public string VisionAndValues { get; set; } = string.Empty;

    [BsonElement("goalsAndObjectives")]
    public string GoalsAndObjectives { get; set; } = string.Empty;

    [BsonElement("structuresAndSystems")]
    public string StructuresAndSystems { get; set; } = string.Empty;

    [BsonElement("policiesAndProcedures")]
    public string PoliciesAndProcedures { get; set; } = string.Empty;

    [BsonElement("processes")]
    public string Processes { get; set; } = string.Empty;

    [BsonElement("integrityAndEthicalValues")]
    public string IntegrityAndEthicalValues { get; set; } = string.Empty;

    [BsonElement("oversightStructure")]
    public string OversightStructure { get; set; } = string.Empty;

    [BsonElement("standards")]
    public string Standards { get; set; } = string.Empty;

    [BsonElement("methodologies")]
    public string Methodologies { get; set; } = string.Empty;

    [BsonElement("rulesAndRegulations")]
    public string RulesAndRegulations { get; set; } = string.Empty;
}

