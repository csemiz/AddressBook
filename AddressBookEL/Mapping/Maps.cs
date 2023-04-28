using AutoMapper;
using AddressBookEL.Entities;
using AddressBookEL.ViewModels;
using AddressBookEL.Models;

namespace AddressBookEL.Mapping
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<City, CityVM>().ReverseMap();
            CreateMap<District, DistrictVM>().ReverseMap();
            CreateMap<Neighbourhood, NeighbourhoodVM>().ReverseMap();
            CreateMap<UserAddress, UserAddressVM>().ReverseMap();
        }
    }
}
