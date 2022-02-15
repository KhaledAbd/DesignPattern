using AutoMapper;
using RepoTest.API.Dtos;
using RepoTest.API.Models;

namespace RepoTest.API.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile(){
            CreateMap<Product, ProductDtos>().ReverseMap();   
        }
    }
}