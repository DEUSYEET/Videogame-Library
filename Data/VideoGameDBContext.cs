using Microsoft.EntityFrameworkCore;

namespace Video_Game_Library.Models
{
    public class VideoGameDBContext : DbContext
    {
        public VideoGameDBContext(DbContextOptions<VideoGameDBContext> options) : base(options){}
        public DbSet<Game> games { get; set; }

    }
}
