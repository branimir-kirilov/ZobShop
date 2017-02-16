using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.ModelBinding;
using WebFormsMvp;
using WebFormsMvp.Web;
using ZobShop.ModelViewPresenter.Product.Details;
using ZobShop.ModelViewPresenter.Product.List;
using ZobShop.ModelViewPresenter.Search;

namespace ZobShop.Web
{
    [PresenterBinding(typeof(SearchPresenter))]
    public partial class Search : MvpPage<ProductListViewModel>, ISearchView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public event EventHandler<SearchEventArgs> MySearch;

        public IEnumerable<ProductDetailsViewModel> Reapeater_GetData([QueryString("q")] string query)
        {
            return this.Model.Products;
        }

        protected void SearchButton_OnClick(object sender, EventArgs e)
        {
            var searchQuery = this.SearchParam.Text;

            var args = new SearchEventArgs(searchQuery);

            this.MySearch?.Invoke(this, args);

            var showLabel = true;

            if (this.Model.Products.Any())
            {
                showLabel = false;
                this.Reapeater.DataSource = this.Model.Products;
                this.DataBind();
            }

            this.NoResultsLabel.Visible = showLabel;
        }
    }
}