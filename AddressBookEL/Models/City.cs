using AddressBookEL.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBookEL.Entities
{
    [Table("Cities")]
    public class City : BaseNumeric
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string PlateCode { get; set; }

    }
}
