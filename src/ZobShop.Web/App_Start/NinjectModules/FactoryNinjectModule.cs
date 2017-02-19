using Ninject.Extensions.Factory;
using Ninject.Modules;
using Ninject.Web.Common;
using ZobShop.Factories;
using ZobShop.ModelViewPresenter;

namespace ZobShop.Web.App_Start.NinjectModules
{
    public class FactoryNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IProductFactory>().ToFactory().InRequestScope();
            this.Bind<ICategoryFactory>().ToFactory().InRequestScope();
            this.Bind<IProductRatingFactory>().ToFactory().InRequestScope();
            this.Bind<IUserFactory>().ToFactory().InRequestScope();

            this.Bind<IViewModelFactory>().ToFactory().InRequestScope();
        }
    }
}