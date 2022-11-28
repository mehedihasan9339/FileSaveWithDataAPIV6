namespace SaveFilesWithDataAPIV6.Models
{
	public class BasicDataVm1
	{
		public string? name { get; set; }
		public string? email { get; set; }
		public string? phone { get; set; }
		public IFormFile[]? file { get; set; }
	}
}
