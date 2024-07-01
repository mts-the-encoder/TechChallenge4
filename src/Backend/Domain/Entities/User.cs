namespace Domain.Entities;

public class User : EntityBase
{
	public string YearBorn { get; set; }
	public string Name { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }
}