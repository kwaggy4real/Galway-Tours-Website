<%@ Page Title="Contact Us" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="~/Content/Site.css" type="text/css"/> 

     <div id="about_contact_div">
    <h2><%: Title %>.</h2>
    <h3>Galway City Tours & Guide</h3>
    <h4>Address</h4>
    <address>
        National Univeristy of Ireland,<br />
        Galway City, Ireland <br />
        <abbr title="Phone">P:</abbr>
        089-479-7919
    </address>

    <address>
        <strong>E-mail:</strong>   <a href="mailto:gtours@yahoo.com">gtours@yahoo.com</a><br />
    </address>

         <div id="contact_extra">
             <h2>Write Us For More Information.</h2><br />
             <fieldset>
                 <legend><em>Fill Details</em></legend>
             <table>
                             <tr>
                                 <td align="right">
                                     <asp:Label ID="FullNameLabel" runat="server" AssociatedControlID="FullName">Full Name:</asp:Label>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="FullName" runat="server" CssClass="form-control" required="True"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="FullNameRequired" runat="server" ControlToValidate="FullName" ErrorMessage="Full Name is required." ToolTip="Full Name is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                 </td>
                             </tr>
                             <tr>
                                 <td align="right">
                                     <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">Email Address:</asp:Label>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="Email" runat="server" CssClass="form-control" required="True" placeholder="example@example.com"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" ErrorMessage="Email is required." ToolTip="Email is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                 </td>
                             </tr>
                             <tr>
                                 <td align="right">
                                     <asp:Label ID="PhoneNumberLabel" runat="server" AssociatedControlID="PhoneNumber" >Phone Number:</asp:Label>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="PhoneNumber" runat="server" CssClass="form-control" placeholder="0874512365"></asp:TextBox>
                                    <p></p>
                                 </td>
                             </tr>
                             <tr>
                                 <td align="right">
                                     <asp:Label ID="SubjectLabel" runat="server" AssociatedControlID="Subject">Subject:</asp:Label>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="Subject" runat="server" CssClass="form-control" required="True"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="SubjectField" runat="server" ControlToValidate="Subject" ErrorMessage="A Subject is required." ToolTip="A Subject is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                 </td>
                             </tr>    
                             <tr>
                                 <td align="right">
                                     <asp:Label ID="MessageLabel" runat="server" AssociatedControlID="Message">Message:</asp:Label>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="Message" runat="server" TextMode="MultiLine" Columns="50" Rows="6"  CssClass="form-control" required="True"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="MessageFieldValidator" runat="server" ControlToValidate="Message" ErrorMessage="A Message to us is required." ToolTip="A Message to us is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                 </td>
                             </tr>            
                         </table>  
                 </fieldset>                               
                    <div id="contact_btn">
                             <asp:Button OnClick="sendEmail" Text="   Send   " runat="server"  CssClass="btn btn-default" />
                   </div>

         </div>
         </div>
</asp:Content>
