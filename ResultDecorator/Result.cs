namespace ResultDecorator;

public class Result<T>
{
    public Result(T obj)
    {
        A = obj;
        _errors = new List<Error>();
    }

    public T A { get; init; }

    public void AddError(Error error)
    {
        _errors.Add(error);
    }

    public void AddError(string message, EErrorType type)
    {
        _errors.Add(new Error(message, type));
    }

    private List<Error> _errors { get; }
    public IReadOnlyCollection<Error> Errors => _errors;
    public bool IsSuccess => Errors.Count == 0;

    public static implicit operator Result<T>(T a) => new(a);

    public R IfError<R>(Func<R> f)
    {
        return f();
    }

    public R IfSuccess<R>(Func<R> f)
    {
        return f();
    }

    public R ExecuteIf<R>(Func<R> isSuccess, Func<R> isError)
    {
        return IsSuccess ? isSuccess() : isError();
    }
}