using MinimalSampleSeven;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

// Endpoint filters
string ColorName(string color) => $"Color specified: {color}!";
app.MapGet("/colorSelector/{color}", ColorName)
    .AddEndpointFilter(async (invocationContext, next) =>
    {
        var color = invocationContext.GetArgument<string>(0);
        if (color.ToUpper() == "RED")
            return Results.Problem("Red not allowed!");
        return await next(invocationContext);
    });

app.MapGet("/filter", () =>
{
    return Results.Ok();
})
    .AddEndpointFilter<FirstFilter>()
    .AddEndpointFilter<SecondFilter>()
    .AddEndpointFilter<ThirdFilter>();
// Endpoint filters


// API Group
var all = app.MapGroup("soccer")
    .MapSoccerGroup()
    .WithTags("Soccer")
    //.WithOpenApi()
    ;

await app.RunAsync();
