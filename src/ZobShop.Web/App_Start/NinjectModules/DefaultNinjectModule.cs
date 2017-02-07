using System.IO;
using System.Reflection;
using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace ZobShop.Web.App_Start.NinjectModules
{
    public class DefaultNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .BindDefaultInterface();
            });
        }
    }
}