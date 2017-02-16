using System;
using System.IO;
using AjaxControlToolkit;
using WebFormsMvp;
using WebFormsMvp.Web;
using ZobShop.ModelViewPresenter.Account;
using ZobShop.ModelViewPresenter.Product.Create;

namespace ZobShop.Web.Product
{
    [PresenterBinding(typeof(CreateProductPresenter))]
    public partial class CreateProduct : MvpPage<CreateProductViewModel>, ICreateProductView
    {
        private static byte[] ImageBuffer;
        private static string ImageMimeType;

        private const string RedirectUrl = "/Product/ProductDetails?id={0}";

        public event EventHandler<CreateProductEventArgs> MyCreateProduct;
        
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }


        protected void CreateProduct_Click(object sender, EventArgs e)
        {
            if (ImageBuffer == null)
            {
                this.ErrorMessage.Text = "Please upload an image for the product";
                return;
            }

            var name = this.Name.Text;
            var category = this.Category.Text;
            var quantity = int.Parse(this.Quantity.Text);
            var maker = this.Maker.Text;
            var price = int.Parse(this.Price.Text);
            var volume = double.Parse(this.Volume.Text);

            var args = new CreateProductEventArgs(name, category, quantity, price, volume, maker, ImageMimeType, ImageBuffer);

            this.MyCreateProduct?.Invoke(this, args);
            ImageBuffer = null;

            var redirectLink = string.Format(RedirectUrl, this.Model.Id);
            this.Response.Redirect(redirectLink);
        }

        protected void AjaxFileUpload_UploadCompleted(object sender, AjaxFileUploadEventArgs e)
        {
            ImageBuffer = e.GetContents();
            ImageMimeType = e.ContentType;
            AjaxFileUpload.Enabled = false;
        }

    }
}