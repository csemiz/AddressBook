using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AddressBookEL.IdentityModels
{
    public class AppUser : IdentityUser
    {
        //IdentityUser  classının içindeki propertylerden farklı olarak eklemek istediğin özellikler var ise IdentityUser clasından kalıtım alarak tabloyu genişletebiliriz.
        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public bool IsPassive { get; set; }

        [Required]
        [StringLength (10, MinimumLength = 10)]
        [RegularExpression("^[0-9]*", ErrorMessage = "Telefon rakamlardan oluşmalıdır")]
        public override string PhoneNumber { get; set; }
    }
}
