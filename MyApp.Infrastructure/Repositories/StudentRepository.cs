using MyApp.Domain.Entities;
using MyApp.Domain.Interfaces;
using MyApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Repositories
{
	public class StudentRepository : IStudentRepository
	{

		private readonly MyAppDbContext context;

		public StudentRepository(MyAppDbContext context)
		{
			this.context = context;
		}

		public async Task<Student?> AddStudentAsync(Student student)
		{
			//await context..AddAsync(student);
			await context.SaveChangesAsync();
			return student;
		}

		public async Task<bool> DeleteStudentAsync(int studentId)
		{
			//var student = await context.
		}

		public Task<List<Student>> GetAllStudentsAsync(int pageNumber, int pageSize)
		{
			throw new NotImplementedException();
		}

		public Task<Student> GetStudentByIdAsync(int studentId)
		{
			throw new NotImplementedException();
		}

		public Task<Student> UpdateStudentAsync(int studentId, Student student)
		{
			throw new NotImplementedException();
		}
	}
}
