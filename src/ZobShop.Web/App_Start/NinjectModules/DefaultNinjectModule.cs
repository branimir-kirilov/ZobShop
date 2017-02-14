using System.IO;
using System.Reflection;
using System.Web;
using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using ZobShop.ModelViewPresenter.ShoppingCart.Add;
using ZobShop.ModelViewPresenter.ShoppingCart.Summary;
using ZobShop.Orders;
using ZobShop.Orders.Contracts;
using ZobShop.Orders.Factories;

namespace ZobShop.Web.App_Start.NinjectModules
{
    public class DefaultNinjectModule : NinjectModule
    {
        private const string CartSessionKey = "cart";

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
            this.Bind<ICartLineFactory>().ToFactory().InSingletonScope();

            this.Bind<IShoppingCart>().ToMethod(this.GetShoppingCart).WhenInjectedInto(typeof(AddToCartPresenter));
            this.Bind<IShoppingCart>().ToMethod(this.GetShoppingCart).WhenInjectedInto(typeof(CartSummaryPresenter));
        }

        private IShoppingCart GetShoppingCart(IContext arg)
        {
            var cart = (IShoppingCart)HttpContext.Current.Session[CartSessionKey];

            if (cart == null)
            {
                cart = this.Kernel.Get<IShoppingCart>();
                HttpContext.Current.Session[CartSessionKey] = cart;
            }

            return cart;
        }
    }
}