using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CallDoc.API.Extensions;
using CallDoc.API.Midlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoWrapper;

namespace CallDoc.API
{
    public class Startup
    {
        public static string MemberId { get; set; }
        public static string MemberTypeId { get; set; }
        public static string MemberStatusId { get; set; }
        public static string TokenKey { get; private set; }

        private readonly IWebHostEnvironment _hostingEnvironment;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;

            _hostingEnvironment = env;
        }

        public IConfiguration Configuration { get; }
        public static string AppRoot { get; private set; }
        public static string Issuer { get; internal set; }
        public static string Audience { get; internal set; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.ConfigureSession();

            //Cross-Origin Resource Sharing (CORS)
            services.ConfigureCors(Configuration);

            services.ConfigureAutoMapper();
            services.ConfigureSwagger();
            services.ConfigureSignalR();
            services.RegisterServices();
            services.RegisterRepositories();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

//#if DEBUG

//            app.UseSwaggerStringCleaner();

//#endif

            TokenKey = Configuration.GetSection("AppSettings:TokenKey").Value;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseStaticFiles();

            app.UseApiResponseAndExceptionWrapper(new AutoWrapperOptions() { 
                                                                                ShowApiVersion = false,
                                                                                ShowStatusCode = true,
                                                                                ShowIsErrorFlagForSuccessfulResponse = true
                                                                            });

            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseCors("AllowAll");

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CallDocAPI");
                c.InjectStylesheet("/swagger/css/theme-flattop.css");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //SignalR
                //endpoints.MapHub<CustomerHub>("/customerhub");
            });

            AppRoot = _hostingEnvironment.ContentRootPath;

        }
    }
}
