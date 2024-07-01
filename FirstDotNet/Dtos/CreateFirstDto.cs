using System.ComponentModel.DataAnnotations;

namespace FirstDotNet.Dtos;


public record class CreateFristDto( 
    [Required][StringLength(50)]string Name, 
    int GenreId, 
    [Required][Range(1,100)]decimal Price, 
    [Required]DateOnly ReleasedDate
);
