using System.Data.Entity;
using System.Web.Http;
using DigitalCensus.Dotnet.Dal;
using DigitalCensus.Dotnet.Dal.Abstract;
using DigitalCensus.Dotnet.Dal.Repository;
using DigitalCensus.Dotnet.Web.Helper;
using DigitialCensus.Dotenet.Services.Concrete;
using DigitialCensus.Dotenet.Services.Interface;
using Unity;
using Unity.WebApi;

namespace DigitalCensus.Dotnet.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            //DbContext
            container.RegisterType<DbContext, DigitalCensusDbContext>();

            //Repository
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IHouseRepository, HouseRepository>();
            container.RegisterType<ICitizenRepository, CitizenRepository>();
            container.RegisterType<IUserAccountRepository, UserAccountRepository>();

            //Service
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IHouseService, HouseService>();
            container.RegisterType<ICitizenService, CitizenService>();
            container.RegisterType<IUserAccountService, UserAccountService>();

            container.RegisterType<AuthProvider, AuthProvider>();

            //startup config resolution
            Startup.IoC = container;
            //WebApi
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

        }
    }
}