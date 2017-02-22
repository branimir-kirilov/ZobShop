using System;

namespace ZobShop.ModelViewPresenter.Administration.UsersList
{
    public class UserIdEventArgs : EventArgs
    {
        public UserIdEventArgs(string id)
        {
            this.UserId = id;
        }

        public string UserId { get; set; }
    }
}
