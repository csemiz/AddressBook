using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBookEL.Models
{
    public class BaseNumeric
    {
        [Column(Order = 1)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(Order = 2)]
        public DateTime CreatedDate { get; set; }
        public bool IsRemoved { get; set; }
    }
}
