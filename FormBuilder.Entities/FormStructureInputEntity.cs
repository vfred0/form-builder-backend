namespace FormBuilder.Entities;

public class FormStructureInputEntity : EntityBase
{
    public required string FormStructureId { get; set; }
    public FormStructureEntity FormStructure { get; set; }
    public required string InputId { get; set; }
    public InputEntity Input { get; set; }
    public string Value { get; set; }
}