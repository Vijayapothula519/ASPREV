<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="asprevproject.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true"></asp:GridView>
                <br />
                <tr>
                    <td><asp:Label runat="server" ID="lbl1" Text="FirstName*"></asp:Label></td>
                    <td><asp:TextBox runat="server" ID="tb1"></asp:TextBox></td>
                    <td><asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="tb1" ErrorMessage="enter FirstName" EnableClientScript="false" ForeColor="Red"></asp:RequiredFieldValidator></td>
                </tr>
                <br />
               
                <tr>
                    <td><asp:Label runat="server" ID="lbl2" Text="lastName"></asp:Label></td>
                    <td><asp:TextBox runat="server" ID="tb2"></asp:TextBox></td>
                </tr>
                <br />
                <tr>
                    <td><asp:Label runat="server" text="Gender*"></asp:Label></td>
                    <td> <asp:RadioButtonList ID="rblGender" runat="server">
                          <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                        <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="rfvGender" runat="server" ControlToValidate="rblGender" ErrorMessage="Please select a gender" EnableClientScript="false" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                <br />
                <tr>
                    <td><asp:Label runat="server" ID="lbl3" Text="Email*"></asp:Label></td>
                    <td><asp:TextBox runat="server" ID="tb3"></asp:TextBox></td>
                    <td><asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="tb3" ErrorMessage="enter email" EnableClientScript="false" ForeColor="red"></asp:RequiredFieldValidator></td>
                </tr>
                <br />
                <tr>
                    <td><asp:Label runat="server" ID="lbl4" Text="Mobile*"></asp:Label></td>
                    <td><asp:TextBox runat="server" ID="tb4"></asp:TextBox></td>
                    <td><asp:RequiredFieldValidator ID="rfv3" runat="server" ControlToValidate="tb4" ErrorMessage="mobile start with 7 or 8 or 9" EnableClientScript="false" ForeColor="red"></asp:RequiredFieldValidator></td>
                
                    
                </tr>
                <br />

                <tr>
                    <td colspan="3"><asp:Button runat="server" ID="btnInsert" Text="Insert" OnClick="btnInsert_Click" /></td>
                </tr>

                <tr>
                    <td colspan="3"><asp:Button runat="server" ID="btnDelete" Text="Delete" OnClick="btnDelete_Click" /></td>
                </tr>
                
               
  

            </table>
        </div>
    </form>
</body>
</html>
