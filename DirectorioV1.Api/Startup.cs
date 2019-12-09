using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DirectorioV1.Api.Config;
using DirectorioV1.Api.CrossCutting.Register;
using DirectorioV1.Api.DataAccess;
using DirectorioV1.Api.DataAccess.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DirectorioV1.Api
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

            services.AddDbContext<DirectorioV1DBContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DataBaseConnection"))
            );
            services.AddScoped<IDirectorioV1DBContext, DirectorioV1DBContext>();

            IoCRegister.AddRegistration(services);
            SwaggerConfig.AddRegistration(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            SwaggerConfig.AddRegistration(app);

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
