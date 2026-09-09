using AutoMapper;
using Tax_Radar_Domain.Entities;
using TaxRadar_Application.DTOs.Users;

namespace TaxRadar_Application.Validators.Profiles.Users;

public class UserProfile:Profile
{
   public UserProfile()
   {
      CreateMap<User, UserDto>()
         .ForCtorParam(nameof(UserDto.Email), opt=> opt.MapFrom(src=>src.Email.Value))
         .ForCtorParam(nameof(UserDto.Ico), opt=>opt.MapFrom(src=>src.Ico!.Value))
         .ForCtorParam(nameof(User.Dic), opt=>opt.MapFrom(src=>src.Dic!.Value));
      
      
   }
}