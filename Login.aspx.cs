using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    string conn = SqlHelper.GetConnectionString("iBilling");
    string comm;
    SqlDataReader sqlDr;

    SqlParameter[] sqlParams = new SqlParameter[2];
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Header"] = "Login";
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (txtusername.Text.Trim() == string.Empty || txtpassword.Text.Trim() == string.Empty)
        {
            lblMsgLogin.Text = "Username or password can't blank";
        }
        else
        {
            sqlParams[0] = new SqlParameter("Account_User", txtusername.Text.Trim());
            sqlParams[1] = new SqlParameter("Account_Pass", txtpassword.Text.Trim());
            comm = "SELECT  [UserID],[Username],[Password],[Name],[Lastname],[Vendercode],[Position],[Email],[Typeuser],[Typeservice] FROM [iBilling].[dbo].[User] WHERE Username = @Account_User and Password = @Account_Pass";
            try
            {
                sqlDr = SqlHelper.ExecuteReader(conn, CommandType.Text, comm, sqlParams);
                sqlDr.Read();
                if (sqlDr.HasRows)
                {

                    Session["Account_User"] = sqlDr["Username"].ToString();
                    Session["Typeuser"] = sqlDr["Typeuser"].ToString();
                    Session["Name_Lastname"] = sqlDr["Name"].ToString() + " " + sqlDr["Lastname"].ToString();
                    Session["Position"] = sqlDr["Position"].ToString();
                    Session["Email"] = sqlDr["Email"].ToString();
                    Session["Username"] = sqlDr["Username"].ToString();
                    // 0 = admin
                    // 1 = planner
                    // 2 = transporter
                    // 3 = vendor
                    // 4 = customer

                    Response.Redirect("AuditReport.aspx");

                    //if (sqlDr["Typeuser"].ToString() == "0")
                    //{
                    //    string User = Session["Username"].ToString();
                    //    Response.Redirect("Main_Report.aspx?User=" + User + " ");
                    //}
                    //else if (sqlDr["Typeuser"].ToString() == "1")
                    //{
                    //    Response.Redirect("Main_Report.aspx");
                    //}
                    //else if (sqlDr["Typeuser"].ToString() == "3")
                    //{
                    //    Response.Redirect("InvoiceToCass.aspx");
                    //}

                }
                else
                {

                    lblMsgLogin.Text = "Username or Password incorrect";
                }
            }
            catch (Exception ex)
            {
                lblMsgLogin.Text = "Error : " + ex.Message;
            }
        }
    }
}