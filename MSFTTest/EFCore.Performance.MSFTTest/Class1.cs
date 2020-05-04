using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Performance.MSFTTest
{
	public sealed class User : IdentityUser {}

	public sealed class Storage : IdentityDbContext<User>
	{
		public Storage(DbContextOptions options) : base(options) {}
	}
}
