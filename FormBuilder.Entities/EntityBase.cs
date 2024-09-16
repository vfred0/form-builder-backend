using System.ComponentModel.DataAnnotations;

namespace FormBuilder.Entities;

public class EntityBase
{
    [Key] public string Id { get; set; } = Guid.NewGuid().ToString();
}