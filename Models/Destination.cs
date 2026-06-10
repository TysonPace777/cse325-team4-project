using System.ComponentModel.DataAnnotations;

namespace cse325_team4_project.Models;

public class Destination
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }

    [Required]
    [MaxLength(4000)]
    public required string Description { get; set; }

    [Required]
    [MaxLength(500)]
    public required string ImageUrl { get; set; }

    [Required]
    [MaxLength(1000)]
    public required string Activities { get; set; }

    [Range(typeof(decimal), "0", "1000000")]
    public decimal Price { get; set; }
}
