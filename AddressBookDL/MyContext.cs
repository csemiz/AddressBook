using AddressBookEL.Entities;
using AddressBookEL.IdentityModels;
using AddressBookEL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AddressBookDL
{
    public class MyContext : IdentityDbContext<AppUser, AppRole,string>
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
            //ctora parametre verdik. Generic parametre Böylece connection string özelliğini OPSİYON olarak Program.cs üzerinden ayarlayacağız.

        }
        public DbSet<City> CityTable { get; set; }
        public DbSet<District> DistrictTable { get; set; }
        public DbSet<Neighbourhood> NeighbourhoodTable { get; set; }
        public DbSet<UserAddress> UserAddressTable { get; set; }
    }
}
