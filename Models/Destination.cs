namespace cse325_team4_project.Models;

public class Destination
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required List<string> ImageUrls { get; set; }
    public string? PreviewImageUrl => ImageUrls?.FirstOrDefault();
    public required string Country { get; set; }
    public required string Category { get; set; } // e.g., "Beach", "Mountain", "City", "Historic"
    public double Rating { get; set; }
    public required string BestTimeToVisit { get; set; }
}
