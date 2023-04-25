using FinalProjectGroup2.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectGroup2.Context
{
    //hobby db context
    public class HobbyContext : DbContext
    {
        public HobbyContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Hobby> Hobbies { get; set; }

    }
}
