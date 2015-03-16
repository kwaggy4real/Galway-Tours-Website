using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using WebSite3;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;

public partial class Account_Manage : System.Web.UI.Page
{
    protected string SuccessMessage
    {
        get;
        private set;
    }

    protected bool CanRemoveExternalLogins
    {
        get;
        private set;
    }

  /*  private bool HasPassword(UserManager manager)
    {
        var user = manager.FindById(Context.User.Identity.GetUserId());
        return (user != null && user.PasswordHash != null);
    }

    protected void Page_Load()
    {
        if (!IsPostBack)
        {
            // Determine the sections to render
            UserManager manager = new UserManager();
            if (HasPassword(manager))
            {
                changePasswordHolder.Visible = true;
            }
            else
            {
                setPassword.Visible = true;
                changePasswordHolder.Visible = false;
            }
         

            // Render success message
            var message = Request.QueryString["m"];
            if (message != null)
            {
                // Strip the query string from action
                Form.Action = ResolveUrl("~/Account/Manage");

                SuccessMessage =
                    message == "ChangePwdSuccess" ? "Your password has been changed."
                    : message == "SetPwdSuccess" ? "Your password has been set."
                    : message == "RemoveLoginSuccess" ? "The account was removed."
                    : String.Empty;
                successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
            }
        }
    }*/


    public void ChangePassword_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            MembershipUser user1 = Membership.GetUser(Context.User.Identity.GetUserName());
            

            if(user1.ChangePassword(oldpassword.Text,confirmPassword.Text))
            {
                Response.Redirect("~/Account/WelcomePage?m=SetPwdSuccess");                
            }
        }
    }

  /*  public IEnumerable<UserLoginInfo> GetLogins()
    {
        UserManager manager = new UserManager();
        var accounts = manager.GetLogins(User.Identity.GetUserId());
        CanRemoveExternalLogins = accounts.Count() > 1 || HasPassword(manager);
        return accounts;
    }*/

    public void RemoveLogin(string loginProvider, string providerKey)
    {
        UserManager manager = new UserManager();
        var result = manager.RemoveLogin(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
        var msg = result.Succeeded
            ? "?m=RemoveLoginSuccess"
            : String.Empty;
        Response.Redirect("~/Account/Manage" + msg);
    }

    private void AddErrors(IdentityResult result)
    {
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error);
        }
    }

    protected void redirectHome(object sender, EventArgs e)
    {
        Response.Redirect("~/Account/Welcome_Page.aspx");
    }
    protected void redirectDetails(object sender, EventArgs e)
    {
        Response.Redirect("~/Account/Details.aspx");
    }
    protected void redirectEditDetails(object sender, EventArgs e)
    {
        Response.Redirect("~/Account/Edit_Details.aspx");
    }

   
}