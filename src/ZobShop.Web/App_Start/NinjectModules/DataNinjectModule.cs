using System.Data.Entity;
using Ninject.Modules;
using Ninject.Web.Common;
using ZobShop.Data;
using ZobShop.Data.Contracts;

namespace ZobShop.Web.App_Start.NinjectModules
{
    public class DataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUnitOfWork>().To<UnitOfWork>();
            this.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));

            this.Bind<DbContext>().To<ZobShopEntities>().InRequestScope();
        }
    }
}