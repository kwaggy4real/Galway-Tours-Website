<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Recover.aspx.cs" Inherits="Account_Recover" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <link rel="stylesheet" href="~/Content/Site.css" type="text/css"/> 

    <div id="recoverydiv">
    <h3>Password Recovery</h3>
            <asp:PlaceHolder ID="error" Visible="false" runat="server">
         <span id="message" class="error" runat="server"></span>

            </asp:PlaceHolder>
            <asp:PlaceHolder ID="username" runat="server" Visible="true">
    <div class="details"> 
       <label>Enter Username:</label><input class="form-control" id="user" name="User" runat="server"/>
    </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="question" Visible="false" runat="server">
                <div class="details"> 
              <label id="questionLabel" runat="server"></label> 
                 <input name="answer" class="form-control"/>
                   </div> 
            </asp:PlaceHolder>

        <asp:PlaceHolder ID="newpass" Visible="false" runat="server"> 
               <div class="details">Your new password is: <b> 
               <span id="password" runat="server"></span></b><br />
                <b style="color:red; font-size:small;">*Copy Password!!*</b> <br />
                <b style="color:red; font-size:large;">*Remember to change your password immediately you Log In!!*</b>
               </div>
        </asp:PlaceHolder> 

           <div> 
           <input type="submit" id="task" name="task" value="Next" runat="server"/>
           </div> 
    </div>
</asp:Content>

