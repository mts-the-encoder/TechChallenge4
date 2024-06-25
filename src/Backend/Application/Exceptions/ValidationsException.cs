using Domain.Entities;

namespace Application.Exceptions;

[Serializable]
public class ValidationsException(List<string> errors) : ExceptionBase(string.Empty)
{
    public List<string> Errors { get; set; } = errors;
}