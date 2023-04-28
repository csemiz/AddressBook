using AddressBookBL.InterfacesOfManagers;
using AddressBookDL.InterfacesOfRepo;
using AddressBookEL.Models;
using AddressBookEL.ViewModels;
using AutoMapper;

namespace AddressBookBL.ImplementationOfManagers
{
    public class NeighbourhoodManager : Manager<NeighbourhoodVM,Neighbourhood,int>, INeighbourhoodManager
    {
        public NeighbourhoodManager(INeighbourhoodRepo repo, IMapper mapper) : base(repo, mapper, null)
        {

        }
    }
}
