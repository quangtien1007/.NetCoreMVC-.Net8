using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        #region DbSet
        //Set database for Categories
        //we can CRUD Categories
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = "1"},
                new Category { Id = 2, Name = "Get lit", DisplayOrder = "2"},
                new Category { Id = 3, Name = "Money bag", DisplayOrder = "3" }
            );
        }
    }


}
