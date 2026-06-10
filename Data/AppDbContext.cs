using cse325_team4_project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace cse325_team4_project.Data;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Destination> Destinations => Set<Destination>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Destination>().HasData(
            new Destination
            {
                Id = 1,
                Name = "Bali",
                Description = "Tropical island destination with beaches, temples, and rice terraces.",
                ImageUrl = "/images/bali.jpg",
                Activities = "Beach days, temple visits, surfing, rice terrace tours",
                Price = 1200m
            },
            new Destination
            {
                Id = 2,
                Name = "Paris",
                Description = "Classic city break with art, history, and world-class dining.",
                ImageUrl = "/images/paris.jpg",
                Activities = "Museum visits, food tours, Seine river walks, cafe hopping",
                Price = 1500m
            },
            new Destination
            {
                Id = 3,
                Name = "Santorini",
                Description = "Whitewashed villages, blue water views, and unforgettable sunsets.",
                ImageUrl = "/images/santorini.jpg",
                Activities = "Sunset cruises, cliffside walks, photography, wine tasting",
                Price = 1750m
            },
            new Destination
            {
                Id = 4,
                Name = "Tokyo",
                Description = "A vibrant mix of modern city energy, tradition, and cuisine.",
                ImageUrl = "/images/tokyo.jpg",
                Activities = "Shrine visits, shopping, ramen tours, city exploration",
                Price = 1650m
            },
            new Destination
            {
                Id = 5,
                Name = "Banff",
                Description = "Mountain scenery, glacier lakes, and outdoor adventure year-round.",
                ImageUrl = "/images/banff.jpg",
                Activities = "Hiking, canoeing, wildlife viewing, scenic drives",
                Price = 1400m
            },
            new Destination
            {
                Id = 6,
                Name = "Cape Town",
                Description = "Coastal city with mountains, beaches, and a rich food scene.",
                ImageUrl = "/images/cape-town.jpg",
                Activities = "Table Mountain hikes, waterfront dining, beaches, wine tours",
                Price = 1550m
            }
        );
    }
}