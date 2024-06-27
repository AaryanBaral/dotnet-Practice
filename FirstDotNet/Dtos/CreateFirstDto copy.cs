namespace FirstDotNet.Dtos;


public record class CreateFristDto( 
    string Name, 
    string Genre, 
    decimal Price, 
    DateOnly ReleaseDate
);
