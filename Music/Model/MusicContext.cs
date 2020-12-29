using System;
using Microsoft.EntityFrameworkCore;

namespace Music.Model
{
    public class MusicContext : DbContext
    {
        public MusicContext(DbContextOptions<MusicContext> options)
            : base(options)
        {
        }

        public DbSet<Songs> Songs { get; set; }
    }
}