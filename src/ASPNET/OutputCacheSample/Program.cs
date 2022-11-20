var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOutputCache(cachingOption =>
{
    cachingOption.AddPolicy("cachingPolicy",
        cache =>
        {
            cache
                .Cache()
                .Expire(TimeSpan.FromMinutes(5));
        });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseOutputCache();

app.MapGet("/cache", () =>
{
    return Results.Ok(StaticData.GetData());
})
.WithName("GetCache")
.WithOpenApi()
.CacheOutput();

app.Run();

internal class StaticData
{
    public static int MyData { get; set; } = 0;
    public static int GetData()
    {
        return ++MyData;
    }
}