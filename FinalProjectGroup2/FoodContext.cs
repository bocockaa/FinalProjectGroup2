using Microsoft.EntityFrameworkCore;
namespace FinalProjectGroup2.Data
{
    public class FoodContext : DbContext{

        public FoodContext(DbContextOptions<FoodContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Food>().HasData(
                new Food {Id = 1, Name = "Pizza", Flavor = "Umami", Calories = 1000, Vegan = false},
                new Food {Id = 2, Name = "Apple", Flavor = "Sweet", Calories = 100, Vegan = true},
                new Food {Id = 3, Name = "Kimchi", Flavor = "Sour", Calories = 25, Vegan = false}


            );
        }

        public DbSet<Food> Foods { get; set; }

    }
}
