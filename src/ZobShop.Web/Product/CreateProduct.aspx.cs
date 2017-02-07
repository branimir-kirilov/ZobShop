using System;
using WebFormsMvp;
using WebFormsMvp.Web;
using ZobShop.ModelViewPresenter.Product.Create;

namespace ZobShop.Web.Product
{
    [PresenterBinding(typeof(CreateProductPresenter))]
    public partial class CreateProduct : MvpPage<CreateProductViewModel>, ICreateProductView
    {
        public event EventHandler<CreateProductEventArgs> MyCreateProduct;

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void CreateProduct_Click(object sender, EventArgs e)
        {
            var name = this.Name.Text;
            var category = this.Category.Text;
            var quantity = int.Parse(this.Quantity.Text);
            var maker = this.Maker.Text;
            var price = int.Parse(this.Price.Text);
            var volume = double.Parse(this.Volume.Text);

            var args = new CreateProductEventArgs(name, category, quantity, price, volume, maker);
            this.MyCreateProduct?.Invoke(this, args);
        }
    }
}