using Domain.Enums;

namespace Application.Communication.Responses;

public class MovieResponse
{
    public int Id { get; set; }
    public string Director { get; set; }
    public string ReleasedYear { get; set; }
    public string Duration { get; set; }
    public Country Country { get; set; }
    public IEnumerable<Gender> Gender { get; set; }
    public double Rate { get; set; }
}