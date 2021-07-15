using System.Linq;
using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    // AutoMapper helps us to map from one object to another
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Where we want to map from to where we want to map to
            // dest is the destination of the URL
            // src is the source of where we are mapping from
            CreateMap<AppUser, MemberDto>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => 
                    src.Photos.FirstOrDefault(x => x.IsMain).Url));  
            CreateMap<Photo, PhotoDto>();
            CreateMap<MemberUpdateDto, AppUser>();
        }
    }    
}