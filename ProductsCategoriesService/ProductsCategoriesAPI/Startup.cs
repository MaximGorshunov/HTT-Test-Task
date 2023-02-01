using DataAccess.Entities;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.EntityFrameworkCore;
using Services.IServices;
using Services.Services;

namespace ProductsCategoriesAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            services.AddApiVersioning(opt => {
                opt.Conventions.Add(new VersionByNamespaceConvention());
                opt.ReportApiVersions = true;
            });

            services.AddDbContext<ProductsCategoriesDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ProductsCategoriesDB")));

            services.AddTransient<IRepository<Category>, CategoryRepository>();
            services.AddTransient<IRepository<Product>, ProductRepository>();

            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(builder => builder.MapControllers());
        }
    }
}

