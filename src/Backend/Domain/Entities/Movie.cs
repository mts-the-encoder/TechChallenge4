using Domain.Enums;

namespace Domain.Entities;

public class Movie : EntityBase
{
	public string Director { get; set; }
	public string ReleasedYear { get; set; }
	public string Duration { get; set; }
	public Country Country { get; set; }
	public IEnumerable<Gender> Gender { get; set; }
	public double Rate { get; set; }
	public int UserId { get; set; }
}