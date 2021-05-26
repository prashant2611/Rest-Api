using CitiInformation.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CitiInformation.Services;

namespace CitiInformation
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration )
        {
            _configuration = configuration ??
                throw new ArgumentNullException(nameof(configuration));
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false)
                .AddMvcOptions(o =>                                                     //This is used to set choice of output format.
                {
                    o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                });


            var ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Database=CityInfoDB;Trusted_Connection=True;";
            //var ConnectionString = _configuration["connectionstring:cityInfoDBconnectionString"];

            services.AddDbContext<CityInfoContext>(o=>
            {
                o.UseSqlServer(ConnectionString);
            });

            services.AddScoped<ICityInfoRepository, CityInfoRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseStatusCodePages();
            app.UseMvc();
           
        }
    }
}
