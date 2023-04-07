using Business.Abstract;
using Business.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Web_MVC.Abstract;
using Web_MVC.Concrete.Helpers;

namespace Web_MVC.Configuration
{
    public class ConfigureDependencies
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationManager>();

            services.AddTransient<IUserAccessor, UserAccessor>();
            services.AddTransient<IFileHelper, FileHelper>();


        }



    }
}
