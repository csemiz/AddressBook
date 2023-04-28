using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AddressBookEL.IdentityModels
{
    public class AppRole : IdentityRole
    {
        [StringLength(50,MinimumLength =2)]
        public override string Name { get; set; }
    }
}
