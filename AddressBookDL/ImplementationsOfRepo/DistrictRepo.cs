using AddressBookDL.InterfacesOfRepo;
using AddressBookEL.Models;

namespace AddressBookDL.ImplementationsOfRepo
{
    public class DistrictRepo : Repository<District, int>, IDistrictRepo
    {
        public DistrictRepo(MyContext context) : base(context)
        {

        }
    }
}
