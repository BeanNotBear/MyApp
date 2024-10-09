using AutoMapper;
using MyApp.Aplication.DTOs;
using MyApp.Domain.Entities;
using MyApp.Domain.Interfaces;

namespace MyApp.Aplication.Services
{
	public class StudentService : IStudentServices
	{

		private readonly IStudentRepository studentRepository;
		private IMapper mapper;

		public StudentService(IStudentRepository studentRepository, IMapper mapper)
		{
			this.studentRepository = studentRepository;
			this.mapper = mapper;
		}

		public async Task<StudentDTO> CreateAsync(CreateStudentRequestDTO creatingStudentRequest)
		{
			var studentEntity = mapper.Map<Student>(creatingStudentRequest);
			var createdStudent = await studentRepository.AddStudentAsync(studentEntity);
			var studentDTO = mapper.Map<StudentDTO>(createdStudent);
			return studentDTO;
		}

		public async Task<bool> DeleteAsync(Guid studentId)
		{
			var isDeleted = await studentRepository.DeleteStudentAsync(studentId);
			return isDeleted;
		}

		public async Task<PaginatedList<StudentDTO>> GetAllAsync(int pageNumber, int pageSize)
		{
			var students = await studentRepository.GetAllStudentsAsync(pageNumber, pageSize);
			var result = mapper.Map<PaginatedList<StudentDTO>>(students);
			return result;
		}

		public async Task<StudentDTO> GetByIdAsync(Guid studentId)
		{
			var student = await studentRepository.GetStudentByIdAsync(studentId);
			var studentDTO = mapper.Map<StudentDTO>(student);
			return studentDTO;
		}

		public async Task<StudentDTO> UpdateAsync(Guid studentId, UpdateStudentRequestDTO updateStudentRequest)
		{
			var studentEntity = mapper.Map<Student>(updateStudentRequest);
			var updatedStudent = await studentRepository.UpdateStudentAsync(studentId, studentEntity);
			var studentDTO = mapper.Map<StudentDTO>(studentEntity);
			return studentDTO;
		}
	}
}
