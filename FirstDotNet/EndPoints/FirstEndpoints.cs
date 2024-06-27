using FirstDotNet.Dtos;

namespace FirstDotNet.EndPoints;
public static class EndPoints
{
    private static readonly List<FristDto> firsts = [
        new(
            1,
            "Street Fighter II",
            "Fighting",
            19.99M,
            new DateOnly(1972,02,05)
        ),
        new(
            2,
            "Gta Vice city",
            "RolePlaying",
            19.99M,
            new DateOnly(1972,02,05)
        ),
        new(
            3,
            "Gta San Andress",
            "RolePlaying",
            19.99M,
            new DateOnly(1972,02,05)
        ),
        new(
            4,
            "FIFA 3",
            "Spots",
            19.99M,
            new DateOnly(1972,02,05)
        ),
    ];
    public static WebApplication MapFirstEndpoints(this WebApplication app){
        app.MapGet("games",()=> firsts);
        app.MapGet("games/{id}",(int id)=>{
            FristDto? game = firsts.Find(first => first.Id == id);
            return game is null ? Results.NotFound("id not found") : Results.Ok(game);
        }).WithName("GetFirst");
        app.MapPost("games",(CreateFristDto newFirst)=>{
            FristDto first = new(
                firsts.Count +1,
                newFirst.Name,
                newFirst.Genre,
                newFirst.Price,
                newFirst.ReleaseDate
            );
            firsts.Add(first);
            return Results.CreatedAtRoute("GetFirst",new {id = first.Id},first);
        });
        app.MapPut("games/{id}",(int id, UpdateFristDto updateFirst)=>{
                var index = firsts.FindIndex(first=> first.Id == id);
                if(index == -1){
                    return Results.NotFound("specidied Id not found");
                }
                firsts[index] = new FristDto(
                    id,
                    updateFirst.Name,
                    updateFirst.Genre,
                    updateFirst.Price,
                    updateFirst.ReleaseDate
                );
                return Results.Content("Updated Sucessfully");
            });
            app.MapDelete("games/{id}",(int id)=>{
                firsts.RemoveAll(game=> game.Id == id);
                return Results.Content("Deleted Sucessfully");
            });
        return app;
    }

}