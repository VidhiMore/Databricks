using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement
{
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //we set middleware here
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //following lines of code for adding the default page when hits the url
            //FileServerOptions defaultoption = new FileServerOptions();
            //defaultoption.DefaultFilesOptions.DefaultFileNames.Clear();
            //defaultoption.DefaultFilesOptions.DefaultFileNames.Add("foo.html");
            

            // end here

            //app.UseDefaultFiles(defaultoption); //this middleware for serving the default files in our solution
            app.UseStaticFiles(); // this middleware for serving the static files in our solution
            app.UseMvcWithDefaultRoute();
    

            // instade of using useDefaultFiles and UseStaticFile we can use UseFileServer to serve this because usefilesever combines the functionalit of both
            //app.UseFileServer();


            app.Run(async (context) =>
            {               
                await context.Response.WriteAsync("Hello");
            });
        }
    }
}
