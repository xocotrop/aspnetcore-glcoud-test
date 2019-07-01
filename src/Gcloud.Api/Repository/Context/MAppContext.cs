using Gcloud.Api.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gcloud.Api.Repository.Context
{
    public class MAppContext : DbContext
    {
        public MAppContext(DbContextOptions<MAppContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<User> Users { get; set; }
    }
}