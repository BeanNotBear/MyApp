using Microsoft.EntityFrameworkCore;
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
			await context.Students.AddAsync(student);
			await context.SaveChangesAsync();
			return student;
		}

		public async Task<bool> DeleteStudentAsync(int studentId)
		{
			var student = await context.Students.FindAsync(studentId);
			if (student == null)
			{
				return false;
			}
			context.Students.Remove(student);
			await context.SaveChangesAsync();
			return true;
		}

		public async Task<List<Student>?> GetAllStudentsAsync(int pageNumber, int pageSize)
		{
			var students = context.Students.AsQueryable();

			var skipResult = (pageNumber - 1) * pageSize;

			var result = await students.Skip(skipResult).Take(pageSize).ToListAsync();
			return result;
		}

		public async Task<Student?> GetStudentByIdAsync(int studentId)
		{
			var student = await context.Students.FindAsync(studentId);
			return student;
		}

		public async Task<Student?> UpdateStudentAsync(int studentId, Student student)
		{
			var existingStudent = await context.Students.FindAsync(studentId);
			if (existingStudent == null)
			{
					return null;
			}
			existingStudent.FirstName = student.FirstName;
			existingStudent.LastName = student.LastName;

			await context.SaveChangesAsync();
			return existingStudent;
		}
	}
}
