using System.Linq;
using GDS.Core.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

using Microsoft.OData.Edm;
using GDS.Data;
using GDS.Core.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace GDS.API
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
            services.AddDbContext<Context>(opt =>
               opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddOData();
            //services.AddControllers(mvcOptions => mvcOptions.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseMvc(routeBuilder =>
            {
                routeBuilder.EnableDependencyInjection();
                routeBuilder.Select().OrderBy().Filter().Expand().MaxTop(null).Count();
                routeBuilder.MapODataServiceRoute("odata", null, GetEdmModel());
            });

            //app.UseMvc(routeBuilder =>
            //{
            //    routeBuilder.Select().Filter().Expand().OrderBy().MaxTop(null).Count();
            //
            //});

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }

        private IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder
            {
                Namespace = "API"
            };

            builder.EnumType<BibleVersion>();
            builder.EnumType<BookList>();

            builder.EntitySet<Book>("Books");
            builder.EntitySet<Bible>("Bibles");
            builder.EntitySet<Chapter>("Chapters");
            builder.EntitySet<Verse>("Verses");
            //builder.EntityType<Bible>().ContainsMany(x => x.Chapters);
            //builder.EntityType<Chapter>().ContainsMany(x => x.Verses);

            return builder.GetEdmModel();
        }
    }
}