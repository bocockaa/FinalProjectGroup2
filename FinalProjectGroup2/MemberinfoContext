using Microsoft.EntityFrameworkCore;

namespace FinalProjectGroup2.Data
{
    public class MemberinfoContext : DbContext{
        
        public MemberinfoContext(DbContextOptions<MemberinfoContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Member>().HasData(
                new Member {Id = 1, FullName = "Justin Cowdrey", Birthday = "1999, 5, 30", Program = "IT", Year = "senior"}
                new Member {Id = 2, FullName = "Rachel Lindquist", Birthday = "2000, 5, 26", Program = "Computer Science", Year = "senior"}
                new Member {Id = 3, FullName = "Athena Bocock", Birthday = "1999, 2, 15", Program = "IT", Year = "senior"}
                new Member {Id = 4, FullName = "Osama Bondogji", Birthday = "2001, 7, 7", Program = "IT", Year = "junior"}
            );
        }

        public DbSet<Member> Memberr {get; set;}

    }
}