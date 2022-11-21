namespace MinimalSampleSeven;

public static class SoccerGroup
{
    public static RouteGroupBuilder MapSoccerGroup(this RouteGroupBuilder group)
    {
        group.MapGet("/", () => Results.Ok(Soccers));
        group.MapGet("/{id}", (string id) => Results.Ok(Soccers.Where(x => x.PlayerName == id)));
        group.MapPost("/", (SoccerDto soccer) => Soccers.Add(soccer));
        group.MapDelete("/{id}", (string id) => Soccers.Remove(Soccers.First(t => t.PlayerName == id))).WithName("DeleteHistoryPlayer");
        return group;
    }

    public static List<SoccerDto> Soccers = new List<SoccerDto>() {
        new SoccerDto { PlayerName = "Paolo Rossi" },
        new SoccerDto { PlayerName = "Paolo Maldini" },
        new SoccerDto { PlayerName = "Micheal Platinì" },
        new SoccerDto { PlayerName = "Roberto Baggio" },
        new SoccerDto { PlayerName = "Ivan Zamorano" },
        new SoccerDto { PlayerName = "Gabriel Omar Batistuta" },
        new SoccerDto { PlayerName = "Francesco Totti" },
        new SoccerDto { PlayerName = "Giuseppe Signori" },
    };
}

public class SoccerDto
{
    public string PlayerName { get; init; }
}