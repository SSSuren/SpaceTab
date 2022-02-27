using Logcast.Recruitment.DataAccess.Repositories.Base;
using Logcast.Recruitment.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Logcast.Recruitment.DataAccess
{
    public class ApplicationDbContext : DbContext, IDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<AudioFile> AudioFiles { get; set; }
        public DbSet<AudioMetaData> AudioMetaDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            modelBuilder.Entity<Subscription>().HasIndex(p => p.Email).IsUnique();
        }
    }
}