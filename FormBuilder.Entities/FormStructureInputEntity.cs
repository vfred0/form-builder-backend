namespace FormBuilder.Entities;

public class FormStructureInputEntity : EntityBase
{
    public Guid FormStructureId { get; set; }
    public FormStructureEntity FormStructure { get; set; }
    public Guid InputId { get; set; }
    public InputEntity Input { get; set; }
}