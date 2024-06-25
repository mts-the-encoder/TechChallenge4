using System.Runtime.Serialization;

namespace Application.Exceptions;

[Serializable]
public class ExceptionBase(string message) : SystemException(message); 