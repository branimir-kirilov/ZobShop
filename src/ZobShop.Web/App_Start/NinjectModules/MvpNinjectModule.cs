using System;
using System.Linq;
using Ninject;
using Ninject.Activation;
using Ninject.Modules;
using Ninject.Parameters;
using WebFormsMvp;

namespace ZobShop.Web.App_Start.NinjectModules
{
    public class MvpNinjectModule : NinjectModule
    {
        private const string ViewConstructorArgumentName = "view";

        public override void Load()
        {
            throw new System.NotImplementedException();
        }

        private IPresenter GetPresenter(IContext context)
        {
            var parameters = context.Parameters.ToList();

            var presenterType = (Type)parameters[0].GetValue(context, null);
            var view = (IView)parameters[1].GetValue(context, null);

            var constructorParameter = new ConstructorArgument(ViewConstructorArgumentName, view);

            var presenter = (IPresenter)context.Kernel.Get(presenterType, constructorParameter);
            return presenter;
        }
    }
}