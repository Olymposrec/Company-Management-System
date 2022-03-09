using BusinessApp.Business.Abstract;
using BusinessApp.Business.Concrete;
using BusinessApp.DataAccess.Abstract;
using BusinessApp.DataAccess.Concrete.EfCore;
using BusinessApp.WebUI.EmailServices;
using BusinessApp.WebUI.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using AspNetCoreHero.ToastNotification;
using Hangfire;
using Hangfire.SqlServer;

namespace BusinessApp.WebUI
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
            services.AddNotyf(config =>
            {
                config.DurationInSeconds = 5;
                config.IsDismissable = true;
                config.Position = NotyfPosition.TopRight;
                });


            //Hangfire
            services.AddHangfire(config =>
            {
                var option = new SqlServerStorageOptions
                {
                    PrepareSchemaIfNecessary = true,
                    QueuePollInterval = TimeSpan.FromMinutes(5),
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    UseRecommendedIsolationLevel = true,
                    UsePageLocksOnDequeue = true,
                    DisableGlobalLocks = true
                };

                config.UseSqlServerStorage(Configuration.GetConnectionString("MSSqlConnection"));
                
            });

            



            services.AddDbContext<BusinessAppContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MSSqlConnection")));
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MSSqlConnection")));
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
            // IdentityUser Ayarlari
            services.Configure<IdentityOptions>(options =>
            {
                //password
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;

                //Lockout
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;

                //Emailconfirmed
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
            });
            //Cookie ayarlari
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/Accessdenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".BusinessApp.Security.Cookie",
                    SameSite = SameSiteMode.Strict
                };
            });
           

            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddScoped<ICompaniesServicesService, CompaniesServiceManager>();
            services.AddScoped<ICompanyService, CompanyManager>();
            services.AddScoped<IDepartmentService, DepartmentManager>();
            services.AddScoped<IFileUploadService, FileUploadManager>();
            services.AddScoped<IRequestService, RequestManager>();
            services.AddScoped<IRequestResponseService, RequestResponseManager>();
            services.AddScoped<IServiceService, ServiceManager>();
            services.AddScoped<IServiceUserService, ServiceUserManager>();
            services.AddScoped<IUsersApplicaitonService, UsersApplicationManager>();
            services.AddScoped<IEmployeeDepartmentService, EmployeeDepartmentManager>();
            services.AddScoped<IRequestDepartmentService, RequestDepartmentManager>();
            services.AddScoped<IEmployeeRequestsService, EmployeeRequestManager>();
            services.AddScoped<ILogsService, LogManager>();

            

            //EMAIL
            services.AddScoped<IEmailSender, SmtpEmailSender>(i =>
             new SmtpEmailSender(
                 Configuration["EmailSender:Host"],
                 Configuration.GetValue<int>("EmailSender:Port"),
                 Configuration.GetValue<bool>("EmailSender:EnableSSL"),
                 Configuration["EmailSender:UserName"],
                 Configuration["EmailSender:Password"]
             )
         );
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration Configuration, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseHangfireDashboard();
            app.UseHangfireServer();
            app.UseRouting();

            app.UseAuthorization();
            IdentitySeed.Seed(userManager, roleManager, Configuration).Wait();

            app.UseEndpoints(endpoints =>
            {
                #region Departments
                endpoints.MapControllerRoute(
           name: "departments",
           pattern: "Department/List",
           defaults: new { controller = "Department", action = "DepartmentList" });
                endpoints.MapControllerRoute(
                  name: "departmentsCreate",
                  pattern: "Department/Create",
                  defaults: new { controller = "Department", action = "DepartmentCreate" });
                endpoints.MapControllerRoute(
                   name: "departmentsEdit",
                   pattern: "Department/{id?}",
                   defaults: new { controller = "Department", action = "DepartmentEdit" });
                #endregion

                #region AdminRequest
                endpoints.MapControllerRoute(
                name: "adminRequests",
                pattern: "Admin/RequestList",
                defaults: new { controller = "Admin", action = "RequestList" });
                endpoints.MapControllerRoute(
               name: "adminRequestsSearch",
               pattern: "Admin/RequestSearch",
               defaults: new { controller = "Admin", action = "RequestSearch" });
                endpoints.MapControllerRoute(
             name: "adminRequestsDetail",
             pattern: "Admin/RequestDetail/{id?}",
             defaults: new { controller = "Admin", action = "RequestDetail" });
                #endregion

                #region UserRequests
                endpoints.MapControllerRoute(
                 name: "userRequestsCreate",
                 pattern: "Request/RequestCreate",
                 defaults: new { controller = "Request", action = "RequestCreate" });
                endpoints.MapControllerRoute(
                name: "userRequestsCreate",
                pattern: "Request/RequestHistory",
                defaults: new { controller = "Request", action = "RequestHistory" });
                endpoints.MapControllerRoute(
                name: "userRequestsCreate",
                pattern: "Request/RequestDetail/{id?}",
                defaults: new { controller = "Request", action = "RequestDetail" });
                #endregion

                #region AdminDefineServiceToUser
                endpoints.MapControllerRoute(
                 name: "adminDefineServiceToCompanyList",
                 pattern: "Admin/DefineServiceToCompanyList",
                 defaults: new { controller = "Admin", action = "DefineServiceToCompanyList" });
                endpoints.MapControllerRoute(
                  name: "adminDefineServiceToCompanySet",
                  pattern: "Admin/DefineServiceToCompany/{id?}",
                  defaults: new { controller = "Admin", action = "DefineServiceToCompanySet" });
                #endregion

                #region Applications
                endpoints.MapControllerRoute(
               name: "adminUsersApplication",
               pattern: "Admin/Applications",
               defaults: new { controller = "Admin", action = "ApplicationsList" });
                endpoints.MapControllerRoute(
                  name: "adminUsersRoleEdit",
                  pattern: "Admin/ApplicationsEdit/{UserId?}",
                  defaults: new { controller = "Admin", action = "ApplicationsEdit" });
                #endregion

                #region AdminUsersRoleRoute
                endpoints.MapControllerRoute(
                 name: "adminUsersRole",
                 pattern: "Admin/UsersRole",
                 defaults: new { controller = "Admin", action = "UserRoleList" });
                endpoints.MapControllerRoute(
                  name: "adminUsersRoleCreate",
                  pattern: "Admin/UsersRole/Create",
                  defaults: new { controller = "Admin", action = "UserRoleCreate" });
                endpoints.MapControllerRoute(
                   name: "adminUsersRoleEdit",
                   pattern: "Admin/UsersRole/{id?}",
                   defaults: new { controller = "Admin", action = "UserRoleEdit" });
                #endregion

                #region AdminUserRoute
                endpoints.MapControllerRoute(
                 name: "adminUsers",
                 pattern: "Admin/Users",
                 defaults: new { controller = "Admin", action = "UserList" });
                endpoints.MapControllerRoute(
                  name: "adminUsersCreate",
                  pattern: "Admin/Users/Create",
                  defaults: new { controller = "Admin", action = "UserCreate" });
                endpoints.MapControllerRoute(
                   name: "adminUsersEdit",
                   pattern: "Admin/Users/{id?}",
                   defaults: new { controller = "Admin", action = "UserEdit" });
                #endregion

                #region ServiceRoute
                endpoints.MapControllerRoute(
                 name: "adminServices",
                 pattern: "Admin/Services",
                 defaults: new { controller = "Admin", action = "ServiceList" });
                endpoints.MapControllerRoute(
                  name: "adminServiceCreate",
                  pattern: "Admin/Services/Create",
                  defaults: new { controller = "Admin", action = "ServiceCreate" });
                endpoints.MapControllerRoute(
                   name: "adminServiceEdit",
                   pattern: "Admin/Services/{id?}",
                   defaults: new { controller = "Admin", action = "ServiceEdit" });
                #endregion

                #region CompanyRoute
                endpoints.MapControllerRoute(
                 name: "adminCompanies",
                 pattern: "Admin/Companies",
                 defaults: new { controller = "Admin", action = "CompanyList" });
                endpoints.MapControllerRoute(
                  name: "adminCompaniesCreate",
                  pattern: "Admin/Companies/Create",
                  defaults: new { controller = "Admin", action = "CompanyCreate" });
                endpoints.MapControllerRoute(
                   name: "adminCompaniesEdit",
                   pattern: "Admin/Companies/{id?}",
                   defaults: new { controller = "Admin", action = "CompanyEdit" });
                #endregion

                endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
