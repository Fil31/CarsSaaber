using CarsSaaber.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarsSaaber.Data
{
    public class CarsContext : DbContext
    {
        public CarsContext(DbContextOptions<CarsContext> options) : base(options)
        {
        }

        public DbSet<Cars> CarsSaaber { get; set; }
    }
}
