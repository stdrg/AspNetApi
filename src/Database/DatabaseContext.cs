using Database.Models;

using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Database
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adresse> Adressen { get; set; } = null!;
        public virtual DbSet<Vermittler> Vermittler { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}