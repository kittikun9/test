<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title> Login </title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <script src="Js/jquery.min.js"></script>
    <script src="Js/bootstrap.min.js"></script>
    <style type="text/css">
        body {
            color: #fff;
            background: #3598dc;
        }

        .form-control {
            min-height: 41px;
            background: #f2f2f2;
            box-shadow: none !important;
            border: transparent;
        }

            .form-control:focus {
                background: #e2e2e2;
            }

        .form-control, .btn {
            border-radius: 2px;
        }

        .login-form {
            width: 350px;
            margin: 30px auto;
            text-align: center;
        }

            .login-form h2 {
                margin: 10px 0 25px;
            }

            .login-form form {
                color: #7a7a7a;
                border-radius: 3px;
                margin-bottom: 15px;
                background: #fff;
                box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
                padding: 30px;
            }

            .login-form .btn {
                font-size: 16px;
                font-weight: bold;
                background: #3598dc;
                border: none;
                outline: none !important;
            }

                .login-form .btn:hover, .login-form .btn:focus {
                    background: #2389cd;
                }

            .login-form a {
                color: #fff;
                text-decoration: underline;
            }

                .login-form a:hover {
                    text-decoration: none;
                }

            .login-form form a {
                color: #7a7a7a;
                text-decoration: none;
            }

                .login-form form a:hover {
                    text-decoration: underline;
                }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-lg-12 text-center">
                <div class="col-lg-4 col-md-4 col-sm-4 col-lg-offset-4" style="padding: 50px 0 0 0;">
                    <div style="background-color: #fff; padding: 50px 0 50px 0; color: #7a7a7a; border-radius: 5px 5px;">
                        <div class="login-form">
                            <h2 class="text-center">Login</h2>
                            <div class="form-group has-error">
                                <asp:TextBox ID="txtusername" runat="server" CssClass="form-control" placeholder="Username" required="required"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtpassword" runat="server" CssClass="form-control" placeholder="Password" required="required" TextMode="Password"> </asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnsubmit" runat="server" Text="Sign in" CssClass="btn btn-primary btn-lg btn-block" OnClick="btnsubmit_Click" />
                            </div>
                            <div class="form-group">
                            <asp:Label ID="lblMsgLogin" runat="server" ForeColor="Red" Style="font-weight: 700"></asp:Label>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>


    </form>
</body>
</html>
