namespace MinimalSampleSeven;

public static class EndpointCounter
{
    private static int Incremental { get; set; }
    public static int GetIncremental() => ++Incremental;
}

public class FirstFilter : IEndpointFilter
{
    public virtual async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        return await next(context);
    }
}

public class SecondFilter : FirstFilter
{
    public override ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        Console.WriteLine($"    second before method {EndpointCounter.GetIncremental()}");
        var result = base.InvokeAsync(context, next);
        Console.WriteLine($"    second after method {EndpointCounter.GetIncremental()}");
        return result;
    }
}

public class ThirdFilter : FirstFilter
{
    public override ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        Console.WriteLine($"        third before method {EndpointCounter.GetIncremental()}");
        var result = base.InvokeAsync(context, next);
        Console.WriteLine($"        third after method {EndpointCounter.GetIncremental()}");
        return result;
    }
}