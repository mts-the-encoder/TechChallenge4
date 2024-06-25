namespace Application.Communication.Responses;

public class ErrorResponse
{
    public List<string> Messages { get; set; }

    public ErrorResponse(string messages)
    {
        Messages = new List<string>
        {
            messages
        };
    }
    
    public ErrorResponse(List<string> mensagens)
    {
        Messages = mensagens;
    }

}