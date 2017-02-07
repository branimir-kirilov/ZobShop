using WebFormsMvp;
using ZobShop.Services.Contracts;

namespace ZobShop.ModelViewPresenter.Product.List
{
    public class ProductListPresenter : Presenter<IProductListView>
    {
        private readonly IProductService service;

        public ProductListPresenter(IProductListView view, IProductService service) : base(view)
        {
            this.service = service;

            this.View.MyInit += View_MyInit;
        }

        private void View_MyInit(object sender, ProductListEventArgs e)
        {
            var category = e.Category;

            if (category == null)
            {
                this.View.Model.Products = this.service.GetProducts();
            }
            else
            {
                this.View.Model.Products = this.service.GetProductsByCategory(category);
            }
        }
    }
}
