using AddressBookEL.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBookEL.Models
{
    [Table("Districts")]
    public class District:BaseNumeric
    {
        [Required]
        [StringLength(50,MinimumLength = 2)]
        public string Name { get; set; }

        public int CityId { get; set; }


        [ForeignKey("CityId")]
        public virtual City City { get; set; }
    }
}
