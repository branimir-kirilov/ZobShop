namespace ZobShop.ModelViewPresenter.Administration.UsersList
{
    public class UserDetailsViewModel
    {
        public UserDetailsViewModel(string email, string address, string phoneNumber, string username, string id)
        {
            this.Email = email;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.Username = username;
            this.UserId = id;
        }

        public string Email { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Username { get; set; }

        public string UserId { get; set; }
    }
}
