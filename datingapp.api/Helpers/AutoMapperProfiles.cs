using System.Linq;
using AutoMapper;
using datingapp.api.Dtos;
using datingapp.api.Models;

namespace datingapp.api.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<user,UserForListDto>().ForMember(dest => dest.PhotoUrl,opt => {
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
            }).ForMember(dest => dest.age,opt =>{
                opt.ResolveUsing(p => p.DateOfBirth.Calculateage());
            });
            CreateMap<user,userForDetailsDto>().ForMember(dest => dest.PhotoUrl,opt => {
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
            }).ForMember(dest => dest.age,opt =>{
                opt.ResolveUsing(p => p.DateOfBirth.Calculateage());
            });
            CreateMap<photo,PhotoForUserDetailsDto>();
            
        }
    }
}