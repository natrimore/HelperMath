using HelperMath.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HelperMath.DataAccess.DataContext
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        DbContext IDataContext.DataContext => this;
    }
}
