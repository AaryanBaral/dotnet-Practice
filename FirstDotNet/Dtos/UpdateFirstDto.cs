using System.ComponentModel.DataAnnotations;

namespace FirstDotNet.Dtos;


public record class UpdateFristDto( 
    [Required][StringLength(50)]string Name, 
    int GenreId, 
    [Required][Range(1,100)]decimal Price, 
    [Required]DateOnly ReleasedDate
);
