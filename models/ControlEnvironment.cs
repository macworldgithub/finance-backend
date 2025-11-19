using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class ControlEnvironment
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("no")]
    public double No { get; set; }

    [BsonElement("mainProcess")]
    public string MainProcess { get; set; } = string.Empty;

    [BsonElement("integrityAndEthicalValues")]
    public string IntegrityAndEthicalValues { get; set; } = string.Empty;

    [BsonElement("commitmentToCompetence")]
    public string CommitmentToCompetence { get; set; } = string.Empty;

    [BsonElement("managementPhilosophyAndOperatingStyle")]
    public string ManagementPhilosophyAndOperatingStyle { get; set; } = string.Empty;

    [BsonElement("organizationalStructure")]
    public string OrganizationalStructure { get; set; } = string.Empty;

    [BsonElement("assignmentOfAuthorityAndResponsibility")]
    public string AssignmentOfAuthorityAndResponsibility { get; set; } = string.Empty;

    [BsonElement("humanResourcePoliciesAndPractices")]
    public string HumanResourcePoliciesAndPractices { get; set; } = string.Empty;

    [BsonElement("boardOrAuditCommitteeParticipation")]
    public string BoardOrAuditCommitteeParticipation { get; set; } = string.Empty;

    [BsonElement("managementControlMethods")]
    public string ManagementControlMethods { get; set; } = string.Empty;

    [BsonElement("externalInfluences")]
    public string ExternalInfluences { get; set; } = string.Empty;

    [BsonElement("managementCommitmentToInternalControl")]
    public string ManagementCommitmentToInternalControl { get; set; } = string.Empty;

    [BsonElement("communicationAndEnforcementIntegrityEthics")]
    public string CommunicationAndEnforcementIntegrityEthics { get; set; } = string.Empty;

    [BsonElement("employeeAwarenessAndUnderstanding")]
    public string EmployeeAwarenessAndUnderstanding { get; set; } = string.Empty;

    [BsonElement("accountabilityAndPerformanceMeasurement")]
    public string AccountabilityAndPerformanceMeasurement { get; set; } = string.Empty;

    [BsonElement("commitmentToTransparencyAndOpenness")]
    public string CommitmentToTransparencyAndOpenness { get; set; } = string.Empty;
}
