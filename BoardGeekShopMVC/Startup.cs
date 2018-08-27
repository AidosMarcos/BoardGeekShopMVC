using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGeekShopMVC.Data;
using BoardGeekShopMVC.Data.Interfaces;
using BoardGeekShopMVC.Data.Models;
using BoardGeekShopMVC.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BoardGeekShopMVC
{
    public class Startup
    {
		private readonly IConfigurationRoot _configurationRoot;

		public Startup(IConfiguration configuration, IHostingEnvironment env)
		{
			_configurationRoot = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json").Build();

			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services) //dependency injection services here
        {
			services.AddDbContext<BoardGeekShopDbContext>(options =>
					options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddTransient<ICategoryRepository, CategoryRepository>();
			services.AddTransient<IProductRepository, ProductRepository>();
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddScoped(sp => ShoppingCart.GetCart(sp));

			services.AddDistributedMemoryCache();
			services.AddSession();
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logger)
        {
			logger.AddConsole();

			app.UseDeveloperExceptionPage();
			app.UseStatusCodePages();
			app.UseStaticFiles();
			app.UseSession();
			//app.UseMvcWithDefaultRoute();
			app.UseMvc(routes =>
			{
				routes.MapRoute(name: "categoryFilter", template: "Product/{action}/{category?}", defaults: new { Controller = "Product", Action = "List" });
				routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
			});
        }
    }
}
