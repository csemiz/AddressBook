using AddressBookEL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AddressBookEL.ViewModels
{
    public class NeighbourhoodVM
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsRemoved { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 5)]
        public string PostCode { get; set; }

        public int DistrictId { get; set; }

        public DistrictVM District { get; set; }
    }
}
