using Microsoft.EntityFrameworkCore;
using MusicAPI.DbStuff.DbModels;
using System;

namespace MusicAPI.DbStuff
{
    public class WebContext : DbContext
    {
        public WebContext(DbContextOptions<WebContext>options) : base(options)
        {

        }

        public DbSet<TrackModel> Tracks { get; set; }
    }
}
