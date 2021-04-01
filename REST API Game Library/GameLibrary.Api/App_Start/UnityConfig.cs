using GameLibrary.DataAccess.Repo;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace GameLibrary.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            RegisterTypes(container);
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IGameLibraryRepo, SqlGameLibrary>();
        }
    }
}