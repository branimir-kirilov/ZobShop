using System;

namespace ZobShop.ModelViewPresenter.Search
{
    public class SearchEventArgs : EventArgs
    {
        public SearchEventArgs(string query)
        {
            this.SearchQueryString = query;
        }

        public string SearchQueryString { get; set; }
    }
}
