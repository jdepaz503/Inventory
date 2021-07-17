using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Inventory.Helpers;
using Inventory.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;
using Invetory.Core.Interfaces;
using Inventory.Infraestructure.Repositories;
using Invetory.Core.UseCase.Interfaces;
using Invetory.Core.UseCase;
using Inventory.Infraestructure.Mapper;

namespace Inventory
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<inventorydbContext>(options => options.UseMySql(Configuration.GetConnectionString("DevConnection")));
            services.AddAndConfigMapper();
            services.AddCors();
            services.AddControllers();
            services.AddApiVersioning();

            //Inyección de dependencias
            services.AddTransient<IProductosRepository, ProductosRepository>();
            services.AddTransient<IOrdenesRepository, OrdenesRepository>();
            services.AddTransient<IProductoUseCase, ProductoUseCase>();
            services.AddTransient<IOrdenUseCase, OrdenUseCase>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Johnny's API",
                    Version = "v1",
                    Contact = new OpenApiContact() { Name = "Johnny De Paz", Email = "jdepaz2012@gmail.com" }
                });
                c.SchemaFilter<EnumSchemaFilter>();
            });
            services.AddMvc(r => r.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Johnny's API");
            });
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseMvc();
        }
    }
}
