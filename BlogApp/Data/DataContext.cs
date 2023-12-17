
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data
{
    public class DataContext : DbContext
    {
         public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Blog> Bloglar => Set<Blog>();
         public DbSet<Contact> Contact => Set<Contact>();
        public DbSet<Comments> Yorumlar => Set<Comments>();
    
    }
}