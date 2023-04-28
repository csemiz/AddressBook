using AddressBookBL.InterfacesOfManagers;
using AddressBookDL.InterfacesOfRepo;
using AddressBookEL.Models;
using AddressBookEL.ViewModels;
using AutoMapper;

namespace AddressBookBL.ImplementationOfManagers
{
    public class UserAddressManager : Manager<UserAddressVM,UserAddress,int>, IUserAddressManager
    {
        public UserAddressManager(IUserAddressRepo repo, IMapper mapper) : base(repo, mapper, null)
        {

        }
    }
}
