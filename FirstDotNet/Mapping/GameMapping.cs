using FirstDotNet.Dtos;
using FirstDotNet.Entities;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace FirstDotNet.Maping;

public static class  GameMapping{
    public static Game ToEntity(this CreateFristDto game){
        return new Game(){
            Name = game.Name,
            GenreId = game.GenreId,
            Price = game.Price,
            ReleasedDate = game.ReleasedDate
        };
    }
    public static Game ToEntity(this UpdateFristDto game, int  Id){
        return new Game(){
            Id = Id,
            Name = game.Name,
            GenreId = game.GenreId,
            Price = game.Price,
            ReleasedDate = game.ReleasedDate
        };
    }

    public static Genre ToEntity(this CreateGenreDtos genre){
        return new Genre(){
            Name = genre.Genre
        };
    }

    public static GenreDto ToGenreDto(this Genre genre){
        return new(
            genre.Id,
            genre.Name
        );
    }
    public static GameSummaryDto ToGameSummaryDto(this Game game){
        return new (
            game.Id,
            game.Name,
            game.Genre!.Name,
            game.Price,
            game.ReleasedDate

        );
    }
    public static GameDetailDto ToGameDetailDto(this Game game){
        return new (
            game.Id,
            game.Name,
            game.GenreId,
            game.Price,
            game.ReleasedDate

        );
    }
    

}