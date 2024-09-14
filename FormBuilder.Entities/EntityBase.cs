using System.ComponentModel.DataAnnotations;

namespace FormBuilder.Entities;

public class EntityBase
{
    [Key] public Guid Id { get; set; } = Guid.NewGuid();

    public bool Status { get; set; } = true;
}