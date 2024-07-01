
namespace FirstDotNet.Dtos;


public record class GameDetailDto( 
    int Id,
    string Name, 
    int GenreId, 
    decimal Price, 
    DateOnly ReleasedDate
);