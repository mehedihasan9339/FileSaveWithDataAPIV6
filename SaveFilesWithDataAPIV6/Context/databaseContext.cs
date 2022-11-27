using Microsoft.EntityFrameworkCore;
using SaveFilesWithDataAPIV6.Data;

namespace SaveFilesWithDataAPIV6.Context
{
	public class databaseContext:DbContext
	{
		public databaseContext(DbContextOptions<databaseContext> options): base(options)
		{

		}
		public DbSet<BasicInfo> basicInfos { get; set; }
	}
}
