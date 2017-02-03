using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using WebFormsMvp;
using WebFormsMvp.Web;
using ZobShop.Authentication;
using ZobShop.Models;
using ZobShop.ModelViewPresenter.Account.Register;

namespace ZobShop.Web.Account
{
    [PresenterBinding(typeof(RegisterPresenter))]
    public partial class Register : MvpPage<RegisterViewModel>, IRegisterView
    {
        public event EventHandler<RegisterEventArgs> MyRegister;

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var args = new RegisterEventArgs(this.Context, this.Email.Text, this.Password.Text);
            this.MyRegister?.Invoke(this, args);

            if (this.Model.IsRegistrationSuccessful)
            {
                IdentityHelper.RedirectToReturnUrl(this.Request.QueryString["ReturnUrl"], this.Response);
            }
            else
            {
                this.ErrorMessage.Text = this.Model.ErrorMessage;
            }
        }

    }
}