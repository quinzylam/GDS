using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GDS.Core.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using Microsoft.OData.Edm;
using GDS.Data;
using GDS.Services.Core.Services;
using GDS.Core.Services;
using GDS.Data.DataStore;
using GDS.Core.Data;
using GDS.Core.Models.Enums;

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
            services.AddOData();

            services.AddDbContext<Context>(opt =>
               opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IDataStore<Book>), typeof(BookDataStore));
            services.AddScoped(typeof(IDataStore<Bible>), typeof(BibleDataStore));

            services.AddScoped(typeof(IBookService<Book>), typeof(BookService));
            services.AddScoped(typeof(IBibleService<Bible>), typeof(BibleService));

            services.AddControllers(mvcOptions => mvcOptions.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthorization();

            app.UseMvc(routeBuilder =>
            {
                routeBuilder.Select().Filter().Expand().OrderBy().MaxTop(null).Count();
                routeBuilder.MapODataServiceRoute("odata", null, GetEdmModel());
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }

        private IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EnumType<BibleVersion>();

            builder.EntitySet<Book>("Books");

            builder.EntitySet<Bible>("Bibles");
            builder.EntityType<Bible>().ContainsMany(x => x.Chapters);
            builder.EntityType<Chapter>().ContainsMany(x => x.Verses);

            return builder.GetEdmModel();
        }
    }
}