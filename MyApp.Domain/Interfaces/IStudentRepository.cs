using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Interfaces
{
	public interface IStudentRepository
	{
		Task<Student?> AddStudentAsync(Student student);
		Task<Student?> UpdateStudentAsync(Guid studentId, Student student);
		Task<bool> DeleteStudentAsync(Guid studentId);
		Task<PaginatedList<Student>> GetAllStudentsAsync(int pageNumber, int pageSize);
		Task<Student?> GetStudentByIdAsync(Guid studentId);
	}
}
