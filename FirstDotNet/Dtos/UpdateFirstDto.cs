namespace FirstDotNet.Dtos;


public record class UpdateFristDto( 
    string Name, 
    string Genre, 
    decimal Price, 
    DateOnly ReleaseDate
);
