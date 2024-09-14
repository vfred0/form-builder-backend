namespace FormBuilder.Entities;

public class FormStructureEntity : EntityBase
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;

    public ICollection<InputEntity> Inputs { get; set; } = new List<InputEntity>();
}