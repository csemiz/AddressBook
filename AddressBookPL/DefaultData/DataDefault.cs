using AddressBookEL.IdentityModels;
using Microsoft.AspNetCore.Identity;

namespace AddressBookPL.DefaultData
{
    public static class DataDefault
    {
        public static IApplicationBuilder Data(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();
            var serviceProvider = scopedServices.ServiceProvider;
            var roleManager = serviceProvider.GetRequiredService<RoleManager<AppRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            CheckAndCreateRoles(roleManager);
            return app;
        }

        public static void CheckAndCreateRoles(RoleManager<AppRole> roleManager)
        {
            try
            {
                string[] roles = new string[] { "admin", "customer", "guest" };

                foreach (string item in roles)
                {
                    if (!roleManager.RoleExistsAsync(item.ToLower()).Result)
                    {
                        AppRole role = new AppRole()
                        {
                            Name = item
                        };

                        var result = roleManager.CreateAsync(role).Result;
                    }
                }
            }
            catch (Exception ex)
            {
                //ex loglanabilir.
            }
        }
    }
}
