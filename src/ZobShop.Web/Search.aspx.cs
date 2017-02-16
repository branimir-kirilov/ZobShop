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
        private const string SearchQueryParam = "search";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var searchQuery = this.Request.QueryString[SearchQueryParam];

                var args = new SearchEventArgs(searchQuery);

                this.MySearch?.Invoke(this, args);

                this.Reapeater.DataSource = this.Model.Products;
                this.DataBind();
            }
            catch (Exception)
            {

            }
        }

        public event EventHandler<SearchEventArgs> MySearch;

        public IEnumerable<ProductDetailsViewModel> Reapeater_GetData([QueryString("q")] string query)
        {
            return this.Model.Products;
        }
    }
}