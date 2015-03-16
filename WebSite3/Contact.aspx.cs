using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

public partial class Contact : Page
{
    string Name;
    string email;
    string phoneNumber;
    string subject;
    string message;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void sendEmail(object sender, EventArgs e)
    { 
        try
        {

            Name = FullName.Text;
            email = Email.Text;
            phoneNumber = PhoneNumber.Text;
            subject = Subject.Text;
            message = Message.Text;
            MailMessage mail = new MailMessage();
            mail.To.Add("d.madugu12@gmail.com");
            mail.From = new MailAddress("d.madugu12@gmail.com", "Galway Tours");
            mail.Subject = subject;
            mail.Body = "Name: " + Name + "\n\n" + "Phone Number: " + phoneNumber + "\n\n"  + " E-mail Address: " + email + "\n\n" + "Message: " + message;
           
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 80;
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtpClient.Credentials = new System.Net.NetworkCredential("d.madugu12@gmail.com", "kwagam12");
            smtpClient.Send(mail);
            Response.Write("E-mail Sent!");
            Response.Redirect("~/Account/Welcome_Page");

        }catch(SmtpFailedRecipientsException eg)
        {
            Response.Write(eg.StackTrace);
        }
        catch(Exception ex)
        {
            Response.Write("Could not sent the email - error: " + ex.Message);
        }
        

    }
}