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
		public async Task<IActionResult> GetAll([FromQuery] QueryParameter queryParameter)
		{
			var result = await studentServices.GetAllAsync(queryParameter);
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
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var student = await studentServices.CreateAsync(createStudentRequest);

			return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
		}

		[HttpDelete]
		[Route("{id:guid}")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			bool isDeleted = await studentServices.DeleteAsync(id);
			if (!isDeleted)
			{
				return NotFound();
			}
			return NoContent();
		}

		[HttpPut]
		[Route("{id:guid}")]
		public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateStudentRequestDTO updateStudentRequest)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var updatedStudent = await studentServices.UpdateAsync(id, updateStudentRequest);
			if (updatedStudent == null)
			{
				return NotFound();
			}

			return Ok(updatedStudent);
		}
	}
}
