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
		Task<Student?> UpdateStudentAsync(int studentId, Student student);
		Task<bool> DeleteStudentAsync(int studentId);
		Task<List<Student>?> GetAllStudentsAsync(int pageNumber, int pageSize);
		Task<Student?> GetStudentByIdAsync(int studentId);
	}
}
