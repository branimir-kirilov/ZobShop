using System;
using Microsoft.AspNet.Identity;
using WebFormsMvp;
using WebFormsMvp.Web;
using ZobShop.ModelViewPresenter.Product.Details;
using ZobShop.ModelViewPresenter.Product.Details.RateProduct;

namespace ZobShop.Web.Product
{
    [PresenterBinding(typeof(ProductDetailsPresenter))]
    public partial class ProductDetails : MvpPage<ProductDetailsViewModel>, IProductDetailsView
    {
        private const string SqlCommandTemplate = "SELECT * FROM PRODUCTRATINGS WHERE PRODUCTID={0}";
        private const string RedirectUrlTemplate = "~/ShoppingCart/AddToCart?id={0}&quantity={1}";

        private static string SqlCommand;
        private static int ProductId;

        public event EventHandler<ProductDetailsEventArgs> MyProductDetails;
        public event EventHandler<RateProductEventArgs> RateProduct;

        private const string QueryId = "id";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ProductId = int.Parse(this.Request.QueryString[QueryId]);

                var args = new ProductDetailsEventArgs(ProductId);

                this.MyProductDetails?.Invoke(this, args);

                SqlCommand = string.Format(SqlCommandTemplate, ProductId);
            }
            catch (Exception)
            {
                this.ErrorLabel.Text = "Please provide an id";
                return;
            }

            this.SqlDataSourceComments.SelectCommand = SqlCommand;
            this.SqlDataSourceComments.DataBind();
            // TODO: Bind to model
        }

        protected void Rate_OnClick(object sender, EventArgs e)
        {
            var args = new RateProductEventArgs(int.Parse(this.RatingBox.Text), this.ContentRatingBox.Text, ProductId);

            this.RateProduct?.Invoke(this, args);

            this.SqlDataSourceComments.DataBind();
        }

        protected void AddToCartButton_OnClick(object sender, EventArgs e)
        {
            var quantityString = this.AddToCartQuantity.Text;
            var redirectUrl = string.Format(RedirectUrlTemplate, ProductId, quantityString);

            this.Response.Redirect(redirectUrl);
        }
    }
}