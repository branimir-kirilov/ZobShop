using System.IO;
using System.Reflection;
using Ninject.Extensions.Conventions;
using Ninject.Modules;
using ZobShop.Orders;
using ZobShop.Orders.Contracts;

namespace ZobShop.Web.App_Start.NinjectModules
{
    public class DefaultNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(x =>
            {
                {
                    var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    x.FromAssembliesInPath(path)
                      .SelectAllClasses()
                      .BindDefaultInterface();
                }
            });

            this.Bind<ICartLine>().To<CartLine>();
            this.Bind<IShoppingCart>().To<ShoppingCart>();
        }
    }
}