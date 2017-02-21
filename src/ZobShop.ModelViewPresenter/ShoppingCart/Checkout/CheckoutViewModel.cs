namespace ZobShop.ModelViewPresenter.ShoppingCart.Checkout
{
    public class CheckoutViewModel
    {
        public CheckoutViewModel()
        {

        }

        public CheckoutViewModel(string name, string address, string phoneNumber)
        {
            this.Name = name;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
        }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsCheckoutSuccessful { get; set; }
    }
}
