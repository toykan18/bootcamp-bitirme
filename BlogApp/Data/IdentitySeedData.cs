using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data
{
    public static class IdentitySeedData{
        private const string adminUser = "Admin";
        private const string adminPassword = "Admin_123";

        public static async void IdentityTestUser(IApplicationBuilder app){
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<DataContext>();

            if(context.Database.GetAppliedMigrations().Any()){
                context.Database.Migrate();
            }

            var UserManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            var user = await UserManager.FindByIdAsync(adminUser);
            if(user == null){
                user = new AppUser{
                    UserName = adminUser,
                    Email = "admin@toykana.com",
                    PhoneNumber = "123456678912",   
                };

                await UserManager.CreateAsync(user, adminPassword);
            }
        }

    }
}