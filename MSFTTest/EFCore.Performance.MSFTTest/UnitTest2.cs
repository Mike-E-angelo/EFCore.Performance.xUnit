using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace EFCore.Performance.MSFTTest
{
	[TestClass]
	public sealed class UnitTest2
	{
		[TestMethod]
		public Task TestMethod1() => Execute();

		[TestMethod]
		public Task TestMethod2() => Execute();

		[TestMethod]
		public Task TestMethod3() => Execute();

		[TestMethod]
		public Task TestMethod4() => Execute();

		[TestMethod]
		public Task TestMethod5() => Execute();

		static async Task Execute()
		{
			var host = new HostBuilder()
			           .ConfigureServices(x =>
			                              {
				                              x.AddSingleton<IServer, TestServer>()
				                               .AddDbContext<Storage>(builder => builder
				                                                                 .UseInMemoryDatabase(Guid.NewGuid()
				                                                                                          .ToString())
				                                                                 .EnableSensitiveDataLogging())
				                               .AddIdentityCore<User>()
				                               .AddEntityFrameworkStores<Storage>();
			                              })
			           .Build();
			await host.StartAsync();

			await host.Services.GetRequiredService<UserManager<User>>()
			          .CreateAsync(new User {UserName = "SomeUser"}, "*Password10*");
		}
	}
}
