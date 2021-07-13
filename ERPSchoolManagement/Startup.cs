using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ERPSchoolManagement.Models;
using ERPSchoolManagement.Interface;
using ERPSchoolManagement.Service;
using Microsoft.OpenApi.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace ERPSchoolManagement
{

    //Scaffold-DbContext "Data Source=SQL5101.site4now.net;Database=db_a75dc8_gravity;Initial Catalog=db_a75dc8_gravity;User Id=db_a75dc8_gravity_admin;Password=Abhishek@7;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force -NoPluralize

    //Scaffold-DbContext "Server=DESKTOP-7N92LNJ;Database=SchoolManagementERPDB;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force -NoPluralize
    public class Startup
    {
        //public IConfigurationRoot Configuration
        //{
        //    get;
        //    set;
        //}
        //public static string ConnectionString
        //{
        //    get;
        //    private set;
        //}
        //public Startup(IHostingEnvironment env)
        //{
        //    Configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appSettings.json").Build();
        //}
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();


            services.AddDbContext<SchoolManagementERPDBContext>(options =>
                    options
                    .UseSqlServer(Configuration.GetConnectionString("SchoolManagementERPDBContext")));


            //services.AddDbContext<Master_Elearning_GravityContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("Master_Elearning_GravityContext")));


            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //services.AddDbContext<SchoolManagementERPDBContext>((serviceProvider, dbContextBuilder) => 
            //{
            //    var connectionStringPlaceHolder = Configuration.GetConnectionString("SchoolManagementERPDBContext");
            //    var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            //    var dbName = httpContextAccessor.HttpContext.Request.Headers["SchoolId"].First();
            //    var connectionString = connectionStringPlaceHolder.Replace("{dbName}", dbName);
            //    dbContextBuilder.UseSqlServer(connectionString);
            //});

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title ="ELearning",
                    Description = "ELearning API"
                });
            });
            services.AddTransient<ILocation, LocationService>();
            services.AddTransient<ISchool, SchoolService>();
            services.AddTransient<IRegistration, RegistrationService>();
            services.AddTransient<IManagement,ManagementService>();
            services.AddTransient<IStudent, StudentService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //ConnectionString = Configuration["ConnectionStrings:Master_Elearning_GravityContext"];

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
           
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "School Management API V1");
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapAreaControllerRoute(name: "areas", "areas", pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}");
            });
            //app.UseEndpoints(endpoints =>
            //{

            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Default}/{action=Index}/{id?}");
            //    endpoints.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}");
            //});
        }
    }
}

