using cse325_team4_project.Models;

namespace cse325_team4_project.Services;

public class DestinationService
{
    private static readonly List<Destination> Destinations = new()
    {
        new Destination
        {
            Id = 1,
            Name = "Bali",
            Country = "Indonesia",
            Description = "Tropical paradise with stunning beaches, rice terraces, and ancient temples.",
            ImageUrls = new() { "/images/bali.jpg", "/images/bali-2.jpg" },
            Category = "Beach",
            Rating = 4.8,
            BestTimeToVisit = "April - October"
        },
        new Destination
        {
            Id = 2,
            Name = "Swiss Alps",
            Country = "Switzerland",
            Description = "Majestic mountain peaks perfect for hiking, skiing, and scenic railway journeys.",
            ImageUrls = new() { "/images/swiss-alps.jpg", "/images/swiss-alps.jpg" },
            Category = "Mountain",
            Rating = 4.9,
            BestTimeToVisit = "June - September"
        },
        new Destination
        {
            Id = 3,
            Name = "Paris",
            Country = "France",
            Description = "The City of Light offers iconic landmarks, world-class museums, and exquisite cuisine.",
            ImageUrls = new() { "/images/paris.jpg", "/images/paris-2.jpg" },
            Category = "City",
            Rating = 4.7,
            BestTimeToVisit = "April - June"
        },
        new Destination
        {
            Id = 4,
            Name = "Machu Picchu",
            Country = "Peru",
            Description = "Ancient Incan citadel set high in the Andes Mountains, a UNESCO World Heritage Site.",
            ImageUrls = new() { "/images/machu-picchu.jpg", "/images/machu-picchu-2.jpg" },
            Category = "Historic",
            Rating = 4.9,
            BestTimeToVisit = "May - September"
        },
        new Destination
        {
            Id = 5,
            Name = "Maldives",
            Country = "Maldives",
            Description = "Pristine island resort destination with crystal-clear waters and overwater bungalows.",
            ImageUrls = new() { "/images/maldives.jpg", "/images/maldives-2.jpg" },
            Category = "Beach",
            Rating = 4.8,
            BestTimeToVisit = "November - April"
        },
        new Destination
        {
            Id = 6,
            Name = "Tokyo",
            Country = "Japan",
            Description = "Vibrant metropolis blending ancient temples with futuristic technology.",
            ImageUrls = new() { "/images/tokyo.jpg", "/images/tokyo-2.jpg" },
            Category = "City",
            Rating = 4.7,
            BestTimeToVisit = "March - May"
        },
        new Destination
        {
            Id = 7,
            Name = "Santorini",
            Country = "Greece",
            Description = "Iconic white-washed buildings overlooking the blue Aegean Sea.",
            ImageUrls = new() { "/images/santorini.jpg", "/images/santorini.jpg" },
            Category = "Beach",
            Rating = 4.8,
            BestTimeToVisit = "May - September"
        },
        new Destination
        {
            Id = 8,
            Name = "New Zealand",
            Country = "New Zealand",
            Description = "Land of adventure with dramatic landscapes, mountains, and outdoor activities.",
            ImageUrls = new() { "/images/new-zealand.jpg", "/images/new-zealand-2.jpg" },
            Category = "Mountain",
            Rating = 4.9,
            BestTimeToVisit = "December - February"
        },
        new Destination
        {
            Id = 9,
            Name = "Kyoto",
            Country = "Japan",
            Description = "Historic temples, peaceful gardens, and traditional culture in the heart of Japan.",
            ImageUrls = new() { "/images/kyoto.jpg", "/images/kyoto-2.jpg" },
            Category = "Historic",
            Rating = 4.7,
            BestTimeToVisit = "March - May"
        },
        new Destination
        {
            Id = 10,
            Name = "Barcelona",
            Country = "Spain",
            Description = "A lively city of Gaudí architecture, tapas bars, and sandy beaches.",
            ImageUrls = new() { "/images/barcelona.jpg", "/images/barcelona-2.jpg" },
            Category = "City",
            Rating = 4.7,
            BestTimeToVisit = "May - June"
        },
        new Destination
        {
            Id = 11,
            Name = "Cape Town",
            Country = "South Africa",
            Description = "A vibrant coastal city with beaches, mountains, and world-class food and wine.",
            ImageUrls = new() { "/images/cape-town.jpg", "/images/cape-town-2.jpg" },
            Category = "City",
            Rating = 4.6,
            BestTimeToVisit = "October - April"
        },
        new Destination
        {
            Id = 12,
            Name = "Banff",
            Country = "Canada",
            Description = "Alpine lakes and glacier-fed scenery in Banff National Park.",
            ImageUrls = new() { "/images/banff.jpg", "/images/banff-2.jpg" },
            Category = "Mountain",
            Rating = 4.8,
            BestTimeToVisit = "June - September"
        },
        new Destination
        {
            Id = 13,
            Name = "Rome",
            Country = "Italy",
            Description = "Ancient history, amazing food, and iconic landmarks in the Eternal City.",
            ImageUrls = new() { "/images/rome.jpg", "/images/rome-2.jpg" },
            Category = "City",
            Rating = 4.7,
            BestTimeToVisit = "April - June"
        },
        new Destination
        {
            Id = 14,
            Name = "Petra",
            Country = "Jordan",
            Description = "A UNESCO World Heritage site carved into red sandstone cliffs.",
            ImageUrls = new() { "/images/petra.jpg", "/images/petra-2.jpg" },
            Category = "Historic",
            Rating = 4.9,
            BestTimeToVisit = "March - May"
        },
        new Destination
        {
            Id = 15,
            Name = "Rio de Janeiro",
            Country = "Brazil",
            Description = "Golden beaches, vibrant carnival culture, and dramatic mountain scenery.",
            ImageUrls = new() { "/images/rio-de-janeiro.jpg", "/images/rio-de-janeiro-2.jpg" },
            Category = "Beach",
            Rating = 4.7,
            BestTimeToVisit = "December - March"
        },
        new Destination
        {
            Id = 16,
            Name = "Dubrovnik",
            Country = "Croatia",
            Description = "Historic walled city along the Adriatic Sea with timeless charm.",
            ImageUrls = new() { "/images/dubrovnik.jpg", "/images/dubrovnik-2.jpg" },
            Category = "Historic",
            Rating = 4.6,
            BestTimeToVisit = "May - October"
        }
    };

    private static int nextId = Destinations.Max(d => d.Id) + 1;

    public Task AddDestinationAsync(Destination destination)
    {
        destination.Id = nextId++;
        Destinations.Add(destination);
        return Task.CompletedTask;
    }

    public Task<IEnumerable<Destination>> GetAllDestinationsAsync()
    {
        return Task.FromResult(Destinations.AsEnumerable());
    }

    public Task<IEnumerable<Destination>> GetDestinationsByCategoryAsync(string category)
    {
        var filtered = Destinations.Where(d => d.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(filtered);
    }

    public Task<IEnumerable<Destination>> SearchDestinationsAsync(string searchTerm)
    {
        var filtered = Destinations.Where(d =>
            d.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
            d.Country.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
            d.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
        );
        return Task.FromResult(filtered);
    }

    public Task<Destination?> GetDestinationByIdAsync(int id)
    {
        var destination = Destinations.FirstOrDefault(d => d.Id == id);
        return Task.FromResult(destination);
    }

    public Task<IEnumerable<string>> GetCategoriesAsync()
    {
        var categories = Destinations.Select(d => d.Category).Distinct();
        return Task.FromResult(categories);
    }
}
