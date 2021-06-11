using AutoMapper;
using CallDoc.API.Repositories;
using CallDoc.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CallDoc.API.Extensions
{
    public static class ServiceExtensions
    {
        #region AutoMapper
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        #endregion

        #region Swagger

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "CallDoc API",
                    Description = "API used for CallDoc App",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "SkillUp",
                        Email = "contact@skillup.mk",
                        Url = new Uri("https://skillup.mk"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "No License",
                        Url = new Uri("https://example.com/license"),
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, true);
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

                //Enable Swagger authentication
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter your token to authorize!",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                // Create Authorization header and insert the token in it
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {{
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,

                    },
                    new List<string>()
                }
                });

            });
        }

        #endregion

        #region SignalR

        public static void ConfigureSignalR(this IServiceCollection services)
        {
            services.AddSignalR();
        }
        #endregion

        #region Register Repositories

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<ILookupRepository, LookupRepository>();
            services.AddTransient<IServicesRepository, ServicesRepository>();
            services.AddTransient<IInstitutionRepository, InstitutionRepository>();
            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddTransient<IMemberRepository, MemberRepository>();
            services.AddTransient<IAuthRepository, AuthRepository>();
        }

        #endregion

        #region Register Services
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ILookupService, LookupService>();
            services.AddTransient<IServicesService, ServicesService>();
            services.AddTransient<IInstitutionService, InstitutionService>();
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<IMemberService, MemberService>();
        }

        #endregion

        #region CORS

        public static void ConfigureCors(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                builder =>
                {
                    builder
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .WithOrigins("http://localhost:4200")
                    //.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
                });
            });
        }

        #endregion

        #region Session

        public static void ConfigureSession(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(config =>
            {
                config.Cookie.Name = "CallDoc.Session";
                config.IdleTimeout = TimeSpan.FromHours(24);
            });
        }

        #endregion
    }
}
