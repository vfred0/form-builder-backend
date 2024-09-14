namespace FormBuilder.Entities;

public class InputEntity : EntityBase
{
    public string Name { get; set; } = default!;
    public string DataType { get; set; } = default!;
    public bool Required { get; set; }
    public Guid FormStructureId { get; set; }
    public FormStructureEntity FormStructureEntity { get; set; } = new();
}