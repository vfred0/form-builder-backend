namespace FormBuilder.Entities;

public class FormStructureInputEntity : EntityBase
{
    public string FormStructureId { get; set; }
    public FormStructureEntity FormStructure { get; set; }
    public string InputId { get; set; }
    public InputEntity Input { get; set; }
}