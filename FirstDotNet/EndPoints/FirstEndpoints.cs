using System.Text.RegularExpressions;
using FirstDotNet.Data;
using FirstDotNet.Dtos;
using FirstDotNet.Entities;
using FirstDotNet.Maping;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FirstDotNet.EndPoints;
public static class EndPoints
{
    public static RouteGroupBuilder MapFirstEndpoints(this WebApplication app){
        var gameRoute = app.MapGroup("games").WithParameterValidation();
        gameRoute.MapGet("/",(GameStoreContext dbContext)=>
         dbContext
            .Games
            .Include(game=>game.Genre)
            .Select(game=>game.ToGameSummaryDto())
            .AsNoTracking()
        );

        gameRoute.MapGet("/{id}",(int id,GameStoreContext dbContext)=>{
            Game? game = dbContext.Games.Find(id);

            return game is null ? 
            Results.NotFound("id not found") : Results.Ok(game.ToGameDetailDto());
        }).WithName("GetFirst");

        gameRoute.MapPost("/",(CreateFristDto newGame, GameStoreContext dbContext)=>{
            Game game = newGame.ToEntity();
            dbContext.Games.Add(game);
            dbContext.SaveChanges();

            return Results.CreatedAtRoute("GetFirst",new {id = game.Id },game.ToGameDetailDto());
        });
        gameRoute.MapPut("/{id}",(int id, UpdateFristDto updateFirst, GameStoreContext dbContext)=>{
                var existingGame = dbContext.Games.Find(id);
                if(existingGame is null){
                    return Results.NotFound("specidied Id not found");
                }
                dbContext.Entry(existingGame)
                .CurrentValues
                .SetValues(updateFirst.ToEntity(id));
                dbContext.SaveChanges();
                return Results.Content("Updated Sucessfully");
            });
        gameRoute.MapDelete("/{id}",(int id, GameStoreContext dbContext)=>{
                dbContext.Games.Where(game=> game.Id == id)
                .ExecuteDelete();
                return Results.Content("Deleted Sucessfully");
            });
        return gameRoute;
    }

}