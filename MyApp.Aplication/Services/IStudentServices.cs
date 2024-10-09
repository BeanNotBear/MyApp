using MyApp.Aplication.DTOs;
using MyApp.Domain.Entities;

namespace MyApp.Aplication.Services
{
	public interface IStudentServices
	{
		Task<PaginatedList<StudentDTO>> GetAllAsync(int pageNumber, int pageSize);
		Task<StudentDTO> CreateAsync(CreateStudentRequestDTO creatingStudentRequest);

		Task<StudentDTO> UpdateAsync(Guid studentId, UpdateStudentRequestDTO updateStudentRequest);
		Task<bool> DeleteAsync(Guid studentId);
		Task<StudentDTO> GetByIdAsync(Guid studentId);
	}
}
