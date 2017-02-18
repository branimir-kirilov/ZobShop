using System;
using WebFormsMvp;
using ZobShop.Services.Contracts;

namespace ZobShop.ModelViewPresenter.Product.Create
{
    public class CreateProductPresenter : Presenter<ICreateProductView>
    {
        private readonly IProductService service;

        public CreateProductPresenter(ICreateProductView view, IProductService service) : base(view)
        {
            if (service == null)
            {
                throw new ArgumentNullException("service cannot be null");
            }

            this.service = service;

            this.View.MyCreateProduct += OnCreateProduct;
        }

        public void OnCreateProduct(object sender, CreateProductEventArgs e)
        {
            var product = this.service.CreateProduct(e.Name, e.CategoryName, e.Quantity, e.Price, e.Volume, e.Maker, e.ImageMimeType, e.ImageBuffer);
            this.View.Model.Id = product.ProductId;
        }
    }
}
