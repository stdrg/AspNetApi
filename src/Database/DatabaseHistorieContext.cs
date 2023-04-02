using Database.Models;

using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Xml;

namespace Database
{
    public partial class DatabaseHistorieContext : DbContext
    {
        public DatabaseHistorieContext(DbContextOptions<DatabaseHistorieContext> options) 
            : base(options)
        {
        }

        public virtual DbSet<AdresseHistorie> AdressenHistorie { get; set; } = null!;
        public virtual DbSet<VermittlerHistorie> VermittlerHistorie { get; set; } = null!;

       
    }
}