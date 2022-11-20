using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRateLimiter(rateOptions =>
{
    rateOptions.AddFixedWindowLimiter("FiveFireInWindow", c =>
    {
        c.PermitLimit = 5;
        c.Window = TimeSpan.FromMinutes(1);
    });

    rateOptions.AddPolicy("rule", context =>
    {
        return RateLimitPartition.GetFixedWindowLimiter(context.Connection.RemoteIpAddress,
        _ => new FixedWindowRateLimiterOptions()
        {
            PermitLimit = 2,
            Window = TimeSpan.FromMinutes(1)
        });
    });
});

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseRateLimiter();

app.MapGet("/incremental", () =>
{
    return Results.Ok(new { Incremental = Incremental.GetId() });
})
.WithName("Incremental")
.WithOpenApi()
.RequireRateLimiting("FiveFireInWindow")
//.RequireRateLimiting("rule")
;


app.Run();

internal static class Incremental
{
    private static int Id { get; set; } = 0;
    public static int GetId()
    {
        return ++Id;
    }
}