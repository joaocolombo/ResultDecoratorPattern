using ResultDecorator;

namespace UnitTest;
public class ResultUnitTests
{
    [Fact]
    public void ReturnPrimitiveSuccess()
    {
        var x = new TestClass().MethodReturnPrimitive();
        Assert.True(x.IsSuccess);
    }

    [Fact]
    public void ReturnPrimitiveFailure()
    {
        var x = new TestClass().MethodReturnPrimitiveFail();
        Assert.False(x.IsSuccess);
    }

    [Fact]
    public void ReturnPrimitiveIfFail()
    {
        var x = new TestClass().MethodReturnPrimitiveFail();
        var number = x.IfError(() => 0);

        Assert.Equal(0, number);
    }

    [Fact]
    public void ReturnPrimitiveIfSuccess()
    {
        var x = new TestClass().MethodReturnPrimitiveFail();
        var number = x.IfSuccess(() => 0);

        Assert.Equal(0, number);
    }

    [Fact]
    public void ReturnPrimitiveIfExecute()
    {
        var x = new TestClass().MethodReturnPrimitive();
        var number = x.ExecuteIf(
            () => 0,
            () => 1);

        Assert.Equal(0, number);
    }

    [Fact]
    public void ReturnPrimitiveIfExecuteFail()
    {
        var x = new TestClass().MethodReturnPrimitiveFail();
        var number = x.ExecuteIf(
            () => 0,
            () => 1);

        Assert.Equal(1, number);
    }

    public class TestClass
    {
        public Result<string> MethodReturnPrimitive()
        {
            return "Success";
        }

        public Result<string> MethodReturnPrimitiveFail()
        {
            var r = new Result<string>("Success");
            r.AddError("Error", EErrorType.Business);
            return r;
        }
    }
}
