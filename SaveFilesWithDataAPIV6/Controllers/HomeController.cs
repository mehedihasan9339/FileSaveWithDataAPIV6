using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaveFilesWithDataAPIV6.Context;
using SaveFilesWithDataAPIV6.Data;
using SaveFilesWithDataAPIV6.Models;

namespace SaveFilesWithDataAPIV6.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HomeController : ControllerBase
	{
		private readonly IWebHostEnvironment _hostingEnvironment;
		private readonly databaseContext _context;

		public HomeController(IWebHostEnvironment hostingEnvironment, databaseContext context)
		{
			_hostingEnvironment = hostingEnvironment;
			_context = context;
		}

		[HttpPost("/api/SaveData")]
		public async Task<IActionResult> SaveData([FromForm] BasicDataVm model)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			try
			{
				var fileName = "";
				if (model.file != null)
				{
					fileName = model.file.FileName;
					var FilePath = Path.Combine(_hostingEnvironment.WebRootPath + "/Files");

					var filePath = Path.Combine(FilePath, model.file.FileName);

					using (FileStream fs = System.IO.File.Create(filePath))
					{
						model.file.CopyTo(fs);
					}
				}

				var data = new BasicInfo
				{
					Name = model.name,
					Email = model.email,
					Phone = model.phone,
					fileUrl = fileName
				};
				_context.basicInfos.Add(data);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{

				throw;
			}
			return Ok(model);
		}

		[HttpGet("/api/GetAllData")]
		public async Task<IActionResult> GetAllData()
		{
			var data = await _context.basicInfos.ToListAsync();
			return Ok(data);
		}
	}
}
