using AddressBookDL.InterfacesOfRepo;
using AddressBookEL.Models;

namespace AddressBookDL.ImplementationsOfRepo
{
    public class NeighbourhoodRepo : Repository<Neighbourhood,int>, INeighbourhoodRepo
    {
        public NeighbourhoodRepo(MyContext context): base(context)
        {
            
        }
    }
}
