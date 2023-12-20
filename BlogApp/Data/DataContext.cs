
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BlogApp.Data
{
    public class DataContext : IdentityDbContext<AppUser, AppRole,string>
    {
         public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Blog> Bloglar => Set<Blog>();
         public DbSet<Contact> Contact => Set<Contact>();
        public DbSet<Comments> Yorumlar => Set<Comments>();
    
    }
}