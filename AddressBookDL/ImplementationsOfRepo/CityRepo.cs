using AddressBookDL.InterfacesOfRepo;
using AddressBookEL.Entities;

namespace AddressBookDL.ImplementationsOfRepo
{
    public class CityRepo : Repository<City,int>, ICityRepo
    {
        public CityRepo(MyContext context) : base(context)
        {
            
        }
    }
}
