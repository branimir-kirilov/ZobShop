using System;

namespace ZobShop.ModelViewPresenter.Administration.ProductsList
{
    public class DeleteProductEventArgs : EventArgs
    {
        public DeleteProductEventArgs(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
