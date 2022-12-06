using Microsoft.EntityFrameworkCore;
using MusicAPI.DbStuff.DbModels;

namespace MusicAPI.DbStuff
{
    public class DbSeed : IDbSeed
    {
        public WebContext webContext { get; set; }
        public DbSeed(WebContext context)
        {
            webContext = context;
        }
        public void Initialize()
        {
            if (!webContext.Tracks.Any())
            {
                var tracks = new List<TrackModel>()
                {
                    new TrackModel()
                    {
                        Author = "Depeche Model",
                        DateOfPublication = DateTime.UtcNow,
                        Genre = "Electro",
                        Name = "Black Celebration"
                    },
                    new TrackModel()
                    {
                        Author = "Pink Floyd",
                        DateOfPublication = DateTime.UtcNow,
                        Genre = "Rock",
                        Name = "Money"
                    },
                    new TrackModel()
                    {
                        Author = "Red Hot Chili Pepers",
                        DateOfPublication= DateTime.UtcNow,
                        Genre = "Rock",
                        Name = "Californication"
                    },
                    new TrackModel()
                    {
                        Author = "Foo Fighters",
                        DateOfPublication = DateTime.UtcNow,
                        Genre = "Rock",
                        Name = "Overlong"
                    }
                };
                webContext.Tracks.AddRange(tracks);
                webContext.SaveChanges();

            }
        }
    }
}
