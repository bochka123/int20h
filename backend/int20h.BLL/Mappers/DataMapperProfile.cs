using int20h.Common.Dtos.User;
using int20h.DAL.Entities;
using AutoMapper;

namespace int20h.BLL.Mappers
{
	public class DataMapperProfile : Profile
	{
		public DataMapperProfile()
		{
			ConfigureUserMapper();
		}

		private void ConfigureUserMapper()
		{
			CreateMap<User, UserDto>().ReverseMap();
			CreateMap<SignInUserDto, User>().ReverseMap();
			CreateMap<SignUpUserDto, User>().ReverseMap();
			CreateMap<EditUserDto, User>().ReverseMap();
        }
	}
}
