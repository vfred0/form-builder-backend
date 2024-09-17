using System.ComponentModel.DataAnnotations.Schema;

namespace FormBuilder.Entities;

public class InputEntity : EntityBase
{
    public required string Name { get; set; }
    public required string DataType { get; set; }
    public bool Required { get; set; }
    
    public ICollection<FormStructureInputEntity> FormStructureInputs { get; set; } =
        new List<FormStructureInputEntity>();

    public ICollection<FormStructureEntity> FormStructures { get; set; } = new List<FormStructureEntity>();
    
    [NotMapped]
    public virtual string Value { get; set; }
}