using System;
using System.IO;
using AjaxControlToolkit;
using WebFormsMvp;
using WebFormsMvp.Web;
using ZobShop.ModelViewPresenter.Product.Create;

namespace ZobShop.Web.Product
{
    [PresenterBinding(typeof(CreateProductPresenter))]
    public partial class CreateProduct : MvpPage<CreateProductViewModel>, ICreateProductView
    {
        private byte[] ImageBuffer;
        private string ImageMimeType;

        private const string RedirectUrl = "/Product/ProductDetails?id={0}";

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
            args.ImageBuffer = this.ImageBuffer ?? args.ImageBuffer;
            args.ImageMimeType = this.ImageMimeType ?? args.ImageMimeType;

            this.MyCreateProduct?.Invoke(this, args);

            var redirectLink = string.Format(RedirectUrl, this.Model.Id);
            this.Response.Redirect(redirectLink);
        }

        protected void AjaxFileUploadEvent(object sender, AjaxFileUploadEventArgs e)
        {
            //TODO: Implement logic here
            this.ImageBuffer = e.GetContents();
            this.ImageMimeType = e.ContentType;
        }
    }
}