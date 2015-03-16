using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Account_Recover : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack)
        {
            if (task.Value == "Next")
            {
                
                MembershipUser mUser = Membership.GetUser(user.Value.ToString());
                    if(mUser != null)
                    {

                        question.Visible = true;
                        questionLabel.InnerText = mUser.PasswordQuestion;
                            if(Request["answer"] != null)
                            {
                                try
                                {
                                    string newPassword = mUser.ResetPassword(Request["answer"]);
                                    username.Visible = false;
                                    question.Visible = false;
                                    newpass.Visible = true;
                                    password.InnerText = "galwaycitytours";
                                    task.Value = "Log In";

                                }
                                catch(MembershipPasswordException)
                                {
                                    ReportError("Wrong asnwer");
                                }

                            }
                    }
                    else
                    {
                        ReportError("Unknown username");
                    }
            }
           /* else if(task.Value == "Restart")
            {
                Response.Redirect(Request.Path);
            }*/
            else
            {
                Response.Redirect(FormsAuthentication.LoginUrl);
            }
                
        }
    }

    protected void ReportError(string errorMsg)
    {
        message.InnerText = "Error: " + errorMsg;
        error.Visible = true;
        task.Value = "Restart";
    }
}