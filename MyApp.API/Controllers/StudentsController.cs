using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Aplication.DTOs;
using MyApp.Aplication.Services;

namespace MyApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentsController : ControllerBase
	{
		private readonly IStudentServices studentServices;

		public StudentsController(IStudentServices studentServices)
		{
			this.studentServices = studentServices;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll([FromQuery] int pageNumber, [FromQuery] int pageSize)
		{
			var result = await studentServices.GetAllAsync(pageNumber, pageSize);
			return Ok(result);
		}

		[HttpGet]
		[Route("{id:guid}")]
		public async Task<IActionResult> GetById([FromRoute] Guid id)
		{
			var student = await studentServices.GetByIdAsync(id);
			if (student == null)
			{
				return NotFound();
			}
			return Ok(student);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateStudentRequestDTO createStudentRequest)
		{
			var student = await studentServices.CreateAsync(createStudentRequest);

			return CreatedAtAction(nameof(GetById), new {id = student.Id}, student);
		}
	}
}
