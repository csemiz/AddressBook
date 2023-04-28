using AddressBookBL.InterfacesOfManagers;
using AddressBookDL.InterfacesOfRepo;
using AddressBookEL.Entities;
using AddressBookEL.ViewModels;
using AutoMapper;

namespace AddressBookBL.ImplementationOfManagers
{
    public class CityManager:Manager<CityVM,City,int>,ICityManager
    {
        public CityManager(ICityRepo repo, IMapper mapper):base(repo, mapper,null) 
        {
            
        }
    }
}
