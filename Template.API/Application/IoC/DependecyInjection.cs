using Lorni.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;
using Template.API.Application.Mappings;
using MediatR;
using Template.API.Application.Swagger;

namespace Template.API.Application.IoC
{
    public class DependecyInjection
    {
        public static void Configure(IServiceCollection services)
        {
            // JWT
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // Injections
            services.AddAutoMapperConfiguration();
            services.AddScoped<DbSession>();

            //Services
            services.AddTransient<Interfaces.v1.IUserService, Services.v1.UserService>();

            //Repository
            services.AddTransient<Domain.ModelAggregate.v1.UserAggregate.IUserRepository, Infraestructure.Repositories.v1.UserRepository>();

            services.AddMediatR(typeof(Startup));
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenOptions>();
        }
    }
}
