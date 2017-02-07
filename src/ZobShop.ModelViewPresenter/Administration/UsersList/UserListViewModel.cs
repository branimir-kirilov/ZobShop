using System.Collections.Generic;
using ZobShop.Models;

namespace ZobShop.ModelViewPresenter.Administration.UsersList
{
    public class UserListViewModel
    {
        public ICollection<User> Users { get; set; }
    }
}
