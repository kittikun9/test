<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditReport.aspx.cs" Inherits="AuditReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Poppins">
    <style>
        .fonts {
            font-size: 30px;
            font-style: normal;
            color: #7a7a7a;
            
        }

        .form2 {
            font-style: normal;
            color: #FFFFFF;
            width: 100%;
            height: 70px;
            margin-left: auto;
            margin-right: auto;
            background-color: #4099ff;
            border-radius: 5px 5px 5px 5px;
        }

        .form {
            width: 100%;
            height: 500px;
            margin-top: 20px;
            margin-left: auto;
            margin-right: auto;
            border-style: outset;
            border-color: #4099ff;
        }



        .style1 {
            width: 700px;
            margin-top: 30px;
            margin-left: auto;
            margin-right: auto;
            height: 40px;
            border-style: solid;
            border-color: #4099ff;
        }

        .style2 {
            width: 700px;
            margin-top: 30px auto;
            margin-left: auto;
            margin-right: auto;
        }

        .m {
            margin-left: 60px;
            border-radius: 5px 5px 5px 5px;
            margin-top: 20px;
        }

        .a {
            float: left;
            margin-top: 10px;
            margin-left: 30px;
            font-size: 20px;
            font-family:Poppins;
        }

        .a1 {
            float: left;
            margin-top: 10px;
            
        }

        .b {
            float: left;
            margin-top: 10px;
            margin-left: 220px;
            font-size: 20px;
            font-family:Poppins;
        }

        .b1 {
            float: r;
            margin-top: 10px;
            margin-left: 150px;
            border-radius: 5px 5px 5px 5px;
        }

        .c {
            float: right;
            margin-top: 10px;
            margin-right: 20px;
            font-size: 20px;
            font-family:Poppins;
        }

        .c1 {
            float: right;
            margin-top: 10px;
            margin-right:24px;
        }

        .block-1 {
            float: left;
            margin-top: 15px;
            margin-left: 50px;
            font-size: 40px;
            font-family:Poppins;
            text-shadow: 1px 1px #CCCCFF;
        }

        .block-2 {
            float: right;
            margin-top: 40px;
            margin-right: 20px;
            font-size: 20px;
            font-family:Poppins;
            text-shadow: 1px 1px #CCCCFF;
        }

        .auto-style1 {
            width: 700px;
            margin-top: 30px auto;
            margin-left: auto;
            margin-right: auto;
            height: 135px;
        }
    </style>
</head>
<body>
     <div class="form2">

        <asp:Label ID="Label5" runat="server" Text="Audit Report " CssClass="block-1"></asp:Label>
        <a href="login.aspx" style="color:#fff;">
        <asp:Label ID="lblLogout" runat="server" Text="Logout " CssClass="block-2"></asp:Label>
            </a>
    </div>

    <form id="form1" runat="server" class="form">
        <div class="style1">
            <asp:Label ID="lblcustomer" runat="server" Text="Customer" CssClass="a"></asp:Label>
            <asp:Label ID="lblexcel" runat="server" Text="Excel" CssClass="b"></asp:Label>
            <asp:Label ID="lblupdate" runat="server" Text="Update" CssClass="c"></asp:Label>

        </div>
        <div class="auto-style1">
            <asp:DropDownList ID="DropDownListcustomer" runat="server"  Height="30px" Width="205px" CssClass="a1"></asp:DropDownList>

            <asp:ImageButton ID="imExport" runat="server" Height="30px" CssClass="b1"
                ImageUrl="~/Image/excel.jpg" ToolTip="Export Excel" Width="40px" OnClick="imExport_Click" />

            <asp:ImageButton ID="imUpdate" runat="server" Height="30px" CssClass="c1"
                ImageUrl="~/Image/update.png" ToolTip="Export Excel" Width="60px" OnClick="imUpdate_Click"  />
        </div>
    </form>
</body>
</html>
