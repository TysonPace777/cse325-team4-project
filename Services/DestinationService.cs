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
            ImageUrl = "/images/bali.jpg",
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
            ImageUrl = "/images/swiss-alps.jpg",
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
            ImageUrl = "/images/paris.jpg",
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
            ImageUrl = "/images/machu-picchu.jpg",
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
            ImageUrl = "/images/maldives.jpg",
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
            ImageUrl = "/images/tokyo.jpg",
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
            ImageUrl = "/images/santorini.jpg",
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
            ImageUrl = "/images/new-zealand.jpg",
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
            ImageUrl = "/images/kyoto.jpg",
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
            ImageUrl = "/images/barcelona.jpg",
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
            ImageUrl = "/images/cape-town.jpg",
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
            ImageUrl = "/images/banff.jpg",
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
            ImageUrl = "/images/rome.jpg",
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
            ImageUrl = "/images/petra.jpg",
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
            ImageUrl = "/images/rio-de-janeiro.jpg",
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
            ImageUrl = "/images/dubrovnik.jpg",
            Category = "Historic",
            Rating = 4.6,
            BestTimeToVisit = "May - October"
        }
    };

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
