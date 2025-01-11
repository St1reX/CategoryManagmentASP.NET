using CategoryManagmentASP.NET.Models;
using Microsoft.EntityFrameworkCore;

namespace CategoryManagmentASP.NET.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
    }
}
