using System.ComponentModel.DataAnnotations;

namespace SaveFilesWithDataAPIV6.Data
{
	public class BasicInfo
	{
		[Key]
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Email { get; set; }
		public string? Phone { get; set; }
		public string? fileUrl { get; set; }
	}
}
