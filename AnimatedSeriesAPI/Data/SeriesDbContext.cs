using Microsoft.EntityFrameworkCore;

namespace AnimatedSeriesAPI.Data
{
    public class SeriesDbContext : DbContext
    {
        public SeriesDbContext(DbContextOptions<SeriesDbContext> options)
            : base(options)
        {
        }
    }
}