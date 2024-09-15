using System.ComponentModel.DataAnnotations;

namespace FormBuilder.Entities;

public class EntityBase
{
    [Key] public Guid Id { get; set; } = Guid.NewGuid();
}