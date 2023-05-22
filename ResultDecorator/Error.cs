namespace ResultDecorator;

public class Error
{
    public Error(string message)
    {
        Message = message;
    }

    public Error(string message, EErrorType type)
    {
        Message = message;
        Type = type;
    }

    public string Message { get; init; }
    public EErrorType Type { get; set; }

}