using Int20h.Common.Dtos.User;
using Int20h.DAL.Entities;
using AutoMapper;
using Int20h.Common.Dtos.Test;
using Int20h.Common.Dtos.Question;

namespace Int20h.BLL.Mappers
{
	public class DataMapperProfile : Profile
	{
		public DataMapperProfile()
		{
			ConfigureUserMapper();
		}

		private void ConfigureUserMapper()
		{
			CreateMap<User, UserDto>()
				.ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.PhoneNumber))
				.ReverseMap();

			CreateMap<SignInUserDto, User>().ReverseMap();

			CreateMap<SignUpUserDto, User>()
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Phone))
				.ReverseMap();

			CreateMap<EditUserDto, User>()
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Phone))
				.ReverseMap();

			CreateMap<CreateTestDto, Test>();
			CreateMap<Test, TestDto>();

			CreateMap<QuestionDto, Question>();

            CreateMap<Question, QuestionResponseDto>()
				.ForMember(dest => dest.QuestionOptions, opt => opt.MapFrom(src => src.QuestionOptions.ToList()));

            CreateMap<QuestionOption, QuestionOptionDto>();

        }
    }
}
