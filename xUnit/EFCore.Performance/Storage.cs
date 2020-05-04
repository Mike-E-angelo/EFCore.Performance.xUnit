using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Performance
{
	public sealed class Storage : IdentityDbContext<User>
	{
		public Storage(DbContextOptions options) : base(options) {}
	}
}