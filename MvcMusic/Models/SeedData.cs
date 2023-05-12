using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMusic.Data;
using MvcMusic.Models;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMusicContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMusicContext>>()))
            {
                // Look for any movies.
                if (context.Music.Any())
                {
                    return;   // DB has been seeded
                }

                context.Music.AddRange(
                    new Music
                    {
                        Title = "We will rock you",
                        ReleaseDate = "1989-2-12",
                        Genre = "Rock",
                        Rating = "Good"
                    },

                    new Music
                    {
                        Title = "Heal the world",
                        ReleaseDate = "1984-3-13",
                        Genre = "Pop",
                        Rating = "Good"
                    },

                    new Music
                    {
                        Title = "Sunset Glow",
                        ReleaseDate = "2005-2-23",
                        Genre = "KPop",
                        Rating = "Bad"
                    },

                    new Music
                    {
                        Title = "Rap God",
                        ReleaseDate = "2013-4-15",
                        Genre = "Rap",
                        Rating = "Bad"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}