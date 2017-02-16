using System.Collections.Generic;
using ZobShop.ModelViewPresenter.Product.Details;

namespace ZobShop.ModelViewPresenter.Product.List
{
    public class ProductListViewModel
    {
        public IEnumerable<ProductDetailsViewModel> Products { get; set; }

        public IEnumerable<string> Categories { get; set; }
    }
}
