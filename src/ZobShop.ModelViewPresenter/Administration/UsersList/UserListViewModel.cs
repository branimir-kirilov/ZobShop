using System.Collections.Generic;
using ZobShop.Models;

namespace ZobShop.ModelViewPresenter.Administration.UsersList
{
    public class UserListViewModel
    {
        public IEnumerable<User> Users { get; set; }
    }
}
