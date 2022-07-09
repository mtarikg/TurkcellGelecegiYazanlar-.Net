using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using nbaDemo.Business.Abstracts;
using nbaDemo.Business.Concretes;
using nbaDemo.Business.MapperProfile;
using nbaDemo.DataAccess.Data;
using nbaDemo.DataAccess.Repositories.Abstracts;
using nbaDemo.DataAccess.Repositories.Concretes;
using System;
using System.Text;
using Hangfire;
using Hangfire.SqlServer;

namespace nbaDemo.API
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "nbaDemo.API", Version = "v1" });

                // Include 'SecurityScheme' to use JWT Authentication
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement { { jwtSecurityScheme, Array.Empty<string>() } });
            });

            // Add Hangfire services.
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(Configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                }));

            // Add the processing server as IHostedService
            services.AddHangfireServer();

            services.AddResponseCaching();

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

            services.AddCors(opt => opt.AddPolicy("Allow", builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            }));

            // Produce
            // Check and permit
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is a very secret key."));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateActor = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,

                    ValidIssuer = "nba",
                    ValidAudience = "nba.com",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IBackgroundJobClient backgroundJobs)
        {
            app.UseHangfireDashboard("/hangfire/dashboard");
            backgroundJobs.Enqueue(() => Console.WriteLine("Hangfire says hi!"));

            app.Map("/test", xapp => xapp.Run(async context =>
            {
                var queryExist = context.Request.Query.ContainsKey("id");

                if (queryExist)
                {
                    var id = int.Parse(context.Request.Query["id"]);
                    await context.Response.WriteAsync($"The request contains an id parameter. Value: {id}");
                }
                else
                {
                    await context.Response.WriteAsync($"This request does not have an id parameter.");
                }
            }));

            app.Use(async (context, next) =>
            {
                await next.Invoke();
                Console.WriteLine(context.Request.Method);
                var hasJsonContent = context.Request.HasJsonContentType();
                if (hasJsonContent)
                {
                    Console.WriteLine("This request contains JSON data.");
                }
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "nbaDemo.API v1"));
            }

            app.UseHttpsRedirection();
            app.UseResponseCaching();

            app.UseRouting();

            app.UseCors("Allow");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
