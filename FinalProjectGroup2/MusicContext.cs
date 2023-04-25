using Microsoft.EntityFrameworkCore;

namespace FinalProjectGroup2.Data
{
    public class MusicContext : DbContext
    {

        public MusicContext(DbContextOptions<MusicContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Music>().HasData(
                new Music { Id = 1234, title = "Example",  artist = "Example", musicGenre = "Example", releaseDate = "01/22/2019", musicAlbum = "Example" }

            );
        }

        public DbSet<Music> Musicc { get; set; }

    }
}
