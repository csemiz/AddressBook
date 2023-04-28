using AddressBookDL.InterfacesOfRepo;
using AddressBookEL.Models;

namespace AddressBookDL.ImplementationsOfRepo
{
    public class UserAddressRepo : Repository<UserAddress,int>, IUserAddressRepo
    {
        public UserAddressRepo(MyContext context):base(context)
        {
            
        }
    }
}
