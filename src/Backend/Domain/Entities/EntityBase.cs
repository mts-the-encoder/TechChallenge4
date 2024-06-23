namespace Domain.Entities;

public abstract class EntityBase
{
	public int Id { get; set; }
	public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
	public string Name { get; set; }
}