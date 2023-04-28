using AddressBookBL.InterfacesOfManagers;
using AddressBookDL.InterfacesOfRepo;
using AddressBookEL.Models;
using AddressBookEL.ViewModels;
using AutoMapper;

namespace AddressBookBL.ImplementationOfManagers
{
    public class DistrictManager : Manager<DistrictVM,District,int>, IDistrictManager
    {
        public DistrictManager(IDistrictRepo repo, IMapper mapper) : base(repo, mapper, null)
        {

        }
    }
}
