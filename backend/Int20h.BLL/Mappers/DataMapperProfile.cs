﻿using Int20h.Common.Dtos.User;
using Int20h.DAL.Entities;
using AutoMapper;
using Int20h.Common.Dtos.Test;
using Int20h.Common.Dtos.Question;
using Int20h.Common.Dtos.Subject;
using Int20h.Common.Dtos.Student;
using Int20h.Common.Dtos.Group;
using Int20h.Common.Dtos.Session;

namespace Int20h.BLL.Mappers
{
	public class DataMapperProfile : Profile
	{
		public DataMapperProfile()
		{
			ConfigureUserMapper();
			ConfigureGroupMapper();
			ConfigureSubjectMapper();
			ConfigureTestMapper();
			ConfigureStudentMapper();
			ConfigureTests();
			ConfigureTeacherMapper();
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
        }

		private void ConfigureGroupMapper()
		{

			CreateMap<CreateGroupDto, Group>().ReverseMap();
			CreateMap<Group, GroupDto>().ReverseMap();

			CreateMap<Subject, SubjectDto>().ReverseMap();

			CreateMap<CreateTestDto, Test>();
			CreateMap<Test, TestDto>();
		}
		private void ConfigureTests()
		{
            CreateMap<QuestionDto, Question>()
                .ForMember(dest => dest.QuestionOptions, opt => opt.MapFrom(src => src.QuestionOptions));

            CreateMap<Question, QuestionResponseDto>()
                .ForMember(dest => dest.QuestionOptions, opt => opt.MapFrom(src => src.QuestionOptions.ToList()));

            CreateMap<QuestionOption, QuestionOptionDto>().ReverseMap();

            CreateMap<TestEditDto, Test>();

            CreateMap<TestSession, SessionDto>()
                .ForMember(dest => dest.Answers, opt => opt.Ignore());
        }

		private void ConfigureSubjectMapper()
		{
			CreateMap<Subject, SubjectDto>().ReverseMap();

			CreateMap<CreateTestDto, Test>();
			CreateMap<Test, TestDto>();
		}

		private void ConfigureTestMapper()
		{
			CreateMap<CreateTestDto, Test>();
			CreateMap<Test, TestDto>();
		}

		private void ConfigureStudentMapper()
		{
			CreateMap<StudentDto, StudentInformation>().ReverseMap();
		}

		private void ConfigureTeacherMapper()
		{
			CreateMap<TeacherDto, TeacherInformation>().ReverseMap();
		}
	}
}
