using Microsoft.EntityFrameworkCore;
namespace FinalProjectGroup2.Data
{
    public class FoodContext : DbContext{

        public FoodContext(DbContextOptions<FoodContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Food>().HasData(
                new Food {Name = "Pizza", Flavor = "Umami", Calories = 1000}
            
            );
        }

        public DbSet<Food> Foods { get; set; }

    }
}
