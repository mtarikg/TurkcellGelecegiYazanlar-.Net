using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using nbaDemo.Business.Abstracts;
using nbaDemo.Business.Concretes;
using nbaDemo.Business.MapperProfile;
using nbaDemo.DataAccess.Data;
using nbaDemo.DataAccess.Repositories.Abstracts;
using nbaDemo.DataAccess.Repositories.Concretes;

namespace nbaDemo
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
            services.AddControllersWithViews();

            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<IPlayerRepository, EFPlayerRepository>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<ITeamRepository, EFTeamRepository>();
            services.AddScoped<IConferenceService, ConferenceService>();
            services.AddScoped<IConferenceRepository, EFConferenceRepository>();
            services.AddScoped<IDivisionService, DivisionService>();
            services.AddScoped<IDivisionRepository, EFDivisionRepository>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<IPositionRepository, EFPositionRepository>();
            services.AddScoped<IUserService, FakeUserService>();

            var connectionString = Configuration.GetConnectionString("db");
            services.AddDbContext<NbaDbContext>(opt => opt.UseSqlServer(connectionString));

            services.AddAutoMapper(typeof(MapProfile));

            services.AddSession();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
                option =>
                {
                    option.LoginPath = "/Users/Login";
                    option.AccessDeniedPath = "/Users/AccessDenied";
                }
            );
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "",
                    pattern: "Players",
                    defaults: new { controller = "Home", action = "Index" }
                    );

                endpoints.MapControllerRoute(
                    name: "",
                    pattern: "Teams",
                    defaults: new { controller = "Home", action = "Index" }
                    );

                endpoints.MapControllerRoute(
                    name: "",
                    pattern: "Standings",
                    defaults: new { controller = "Home", action = "Index" }
                    );

                endpoints.MapControllerRoute(
                    name: "",
                    pattern: "Users",
                    defaults: new { controller = "Home", action = "Login" }
                    );
            });
        }
    }
}
