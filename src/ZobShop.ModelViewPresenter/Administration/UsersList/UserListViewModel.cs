using System.Collections.Generic;

namespace ZobShop.ModelViewPresenter.Administration.UsersList
{
    public class UserListViewModel
    {
        public IEnumerable<UserDetailsViewModel> Users { get; set; }
    }
}
