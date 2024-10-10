using AutoMapper;
using MyApp.Aplication.DTOs;
using MyApp.Domain.Entities;

namespace MyApp.Aplication.Mappers
{
	public class MapperProfiles : Profile
	{
		public MapperProfiles()
		{
			CreateMap<StudentDTO, Student>().ReverseMap();
			CreateMap<UpdateStudentRequestDTO, Student>().ReverseMap();
			CreateMap<StudentDTO, Student>().ReverseMap();
			CreateMap<PaginatedList<StudentDTO>, PaginatedList<Student>>().ReverseMap();
		}
	}
}
