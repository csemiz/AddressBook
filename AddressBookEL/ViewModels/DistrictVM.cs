using AddressBookEL.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AddressBookEL.ViewModels
{
    public class DistrictVM
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsRemoved { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        public int CityId { get; set; }
        public CityVM City { get; set; }
    }
}
