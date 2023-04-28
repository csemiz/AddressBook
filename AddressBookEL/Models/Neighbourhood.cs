using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBookEL.Models
{
    [Table("Neighbourhoods")]
    public class Neighbourhood : BaseNumeric
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 5)]
        public string PostCode { get; set; }

        public int DistrictId { get; set; }

        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }


    }
}
