
using System.Linq;
using AutoMapper;
using school.MODAL;

namespace school.API.helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles(){
            CreateMap<Course, CourseInfo>();
             CreateMap<CourseInfo,Course>();
         /*   CreateMap<Student, UserForListDto>()
            .ForMember(dest => dest.PhotoUrl, opt => {
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
            })
            .ForMember(dest => dest.Age, opt =>{
                opt.MapFrom(d => d.DAteOfBirth.CalculateAge());
               
                
            });
            CreateMap<User, UserForDetailedDto>() .ForMember(dest => dest.PhotoUrl, opt => {
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
            }) .ForMember(dest => dest.Age, opt =>{
                 opt.MapFrom(d => d.DAteOfBirth.CalculateAge());
               
            });
             CreateMap<Photo, PhotosForDetailedDto>();
             CreateMap<UserForUpdateDto, User>();
             CreateMap<Photo, PhotoForReturnDto>();
             CreateMap<PhotoForCreationDto, Photo>();
             CreateMap<MessageForCreationDto, Message>().ReverseMap();
             CreateMap<Message, MessageToReturnDto>()
             .ForMember( m => m.SenderPhotoUrl, opt => opt
             .MapFrom( u => u.Sender.Photos.FirstOrDefault( p=> p.IsMain).Url))
             .ForMember( m => m.RecipientPhotoUrl, opt => opt
             .MapFrom( u => u.Recipient.Photos.FirstOrDefault( p=> p.IsMain).Url));*/
        }
    
    }
}