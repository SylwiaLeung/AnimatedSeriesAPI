using AnimatedSeriesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimatedSeriesAPI.Data
{
    public class SeriesSeeder
    {
        private readonly SeriesDbContext _context;

        public SeriesSeeder(SeriesDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Database.CanConnect())
            {
                if (!_context.Genres.Any())
                {
                    _context.Genres.AddRange(GetGenres());
                    _context.SaveChanges();
                }
                if (!_context.Directors.Any())
                {
                    _context.Directors.AddRange(GetDirectors());
                    _context.SaveChanges();
                }
                if (!_context.Lectors.Any())
                {
                    _context.Lectors.AddRange(GetLectors());
                    _context.SaveChanges();
                }
                if (!_context.Casts.Any())
                {
                    _context.Casts.AddRange(GetCasts());
                    _context.SaveChanges();
                }
                if (!_context.Series.Any())
                {
                    _context.Series.AddRange(GetSeries());
                    _context.SaveChanges();
                }
                if (!_context.Seasons.Any())
                {
                    _context.Seasons.AddRange(GetSeasons());
                    _context.SaveChanges();
                }
                if (!_context.Episodes.Any())
                {
                    _context.Episodes.AddRange(GetEpisodes());
                    _context.SaveChanges();
                }
            }
        }

        private IEnumerable<Episode> GetEpisodes()
        {
            List<Episode> episodes = new()
            {
                new Episode()
                {
                    Title = "Pilot",
                    Number = 1,
                    SeasonId = 1
                },
                new Episode()
                {
                    Title = "Pilot",
                    Number = 1,
                    SeasonId = 2
                },
                new Episode()
                {
                    Title = "Pilot",
                    Number = 1,
                    SeasonId = 3
                },
                new Episode()
                {
                    Title = "Pilot",
                    Number = 1,
                    SeasonId = 4
                },
                new Episode()
                {
                    Title = "Geometry",
                    Number = 1,
                    SeasonId = 5
                },
                new Episode()
                {
                    Title = "Pilot",
                    Number = 1,
                    SeasonId = 6
                },
            };
            return episodes;
        }

        private IEnumerable<Season> GetSeasons()
        {
            List<Season> seasons = new()
            {
                new Season()
                {
                    Number = 1,
                    SerieId = 1,
                    DirectorId = 4,
                    CastId = 1
                },
                new Season()
                {
                    Number = 1,
                    SerieId = 2,
                    DirectorId = 2,
                    CastId = 2
                },
                new Season()
                {
                    Number = 1,
                    SerieId = 3,
                    DirectorId = 3,
                    CastId = 3
                },
                new Season()
                {
                    Number = 1,
                    SerieId = 4,
                    DirectorId = 1,
                    CastId = 4
                },
                new Season()
                {
                    Number = 2,
                    SerieId = 4,
                    DirectorId = 1,
                    CastId = 4
                },
                new Season()
                {
                    Number = 1,
                    SerieId = 5,
                    DirectorId = 5,
                    CastId = 5
                }
            };
            return seasons;
        }

        private IEnumerable<Serie> GetSeries()
        {
            List<Serie> series = new()
            {
                new Serie()
                {
                    Title = "Rick & Morty",
                    GenreId = 1
                },
                new Serie()
                {
                    Title = "Final Space",
                    GenreId = 3
                },
                new Serie()
                {
                    Title = "JoJo Bizzare Adventure",
                    GenreId = 5
                },
                new Serie()
                {
                    Title = "Motorola Academy",
                    GenreId = 2
                },
                new Serie()
                {
                    Title = "Invincible",
                    GenreId = 4
                },
            };
            return series;
        }

        private IEnumerable<Cast> GetCasts()
        {
            List<Cast> casts = new()
            {
                new Cast()
                {
                },
                new Cast()
                {
                },
                new Cast()
                {
                },
                new Cast()
                {
                },
                new Cast()
                {
                },
            };
            return casts;
        }

        private IEnumerable<Lector> GetLectors()
        {
            List<Lector> lectors = new()
            {
                new Lector()
                {
                    Name = "Olan Rogers"
                },
                new Lector()
                {
                    Name = "Daisuke Ono"
                },
                new Lector()
                {
                    Name = "Justin Roiland"
                },
                new Lector()
                {
                    Name = "Chris Parnell"
                },
                new Lector()
                {
                    Name = "Kyle Herbert"
                },
                new Lector()
                {
                    Name = "Dominik Starzyk"
                }
            };
            return lectors;
        }

        private IEnumerable<Director> GetDirectors()
        {
            List<Director> directors = new()
            {
                new Director()
                {
                    Name = "Taika Waititi"
                },
                new Director()
                {
                    Name = "Dan Harmon"
                },
                new Director()
                {
                    Name = "Naokatsu Tsuda"
                },
                new Director()
                {
                    Name = "David Sacks"
                },
                new Director()
                {
                    Name = "Dominik Starzyk"
                }
            };
            return directors;
        }

        private IEnumerable<Genre> GetGenres()
        {
            List<Genre> genres = new()
            {
                new Genre()
                {
                    Name = "Comedy"
                },
                new Genre()
                {
                    Name = "Horror"
                },
                new Genre()
                {
                    Name = "Sci-Fi"
                },
                new Genre()
                {
                    Name = "Action"
                },
                new Genre()
                {
                    Name = "Anime"
                }
            };
            return genres;
        }
    }
}