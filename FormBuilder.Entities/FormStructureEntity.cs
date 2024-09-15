namespace FormBuilder.Entities;

public class FormStructureEntity : EntityBase
{
    public required string Name { get; set; }
    public required string Description { get; set; }

    public ICollection<FormStructureInputEntity> FormStructureInputs { get; set; } =
        new List<FormStructureInputEntity>();

    public ICollection<InputEntity> Inputs { get; set; } = new List<InputEntity>();
}