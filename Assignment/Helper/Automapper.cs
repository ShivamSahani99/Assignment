using Assignment.DTO;
using Assignment.Entities;

using AutoMapper;

namespace Assignment.Helper
{
    public class Automapper: Profile
    {
        public Automapper()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }
    }
}
