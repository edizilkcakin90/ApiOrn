using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using BLL;
using DAL;
using Microsoft.Extensions.Logging;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;

namespace ApiOrnek
{
    public class Startup
    {
        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            Configuration = configuration;
            loggerFactory.AddLog4Net();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddTransient<IUserRepository, EFRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddDbContext<ProjectContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<ProjectContext>(opts => opts.UseSqlServer(("Server=localhost;Database=ApiOrnekDB;Trusted_Connection=True;MultipleActiveResultSets=true")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var key = Encoding.ASCII.GetBytes(Configuration["Application:Secret"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Audience = "SomeCustomApp";
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.ClaimsIssuer = "mineplaJWT.api.demo";
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
                x.Events = new JwtBearerEvents()
                {
                    OnTokenValidated = (context) =>
                    {
                        //context.Principal.Identity is ClaimsIdentity
                        //So casting it to ClaimsIdentity provides all generated claims
                        //And for an extra token validation they might be usefull
                        var name = context.Principal.Identity.Name;
                        if (string.IsNullOrEmpty(name))
                        {
                            context.Fail("Unauthorized. Please re-login");
                        }
                        return Task.CompletedTask;
                    }
                };
            });

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
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

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
