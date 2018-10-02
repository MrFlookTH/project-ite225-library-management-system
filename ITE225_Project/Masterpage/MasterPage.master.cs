using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Masterpage_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["MemberID"] != null)
        {
            Session.Remove("AdminID");
            LabelUsername.Text = Session["MemberID"].ToString();
            //LabelName.Text = Session["Firstname"] + " ";
            //LabelName.Text += Session["Lastname"];
            PanelUserLogin.Visible = false;
            PanelUserAccount.Visible = true; 
        }
    }
    protected void alert(string msg)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + msg + "');</script>");
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string user = TextBoxUser.Text;
        string pass = TextBoxPass.Text;
        if (user.Trim() == "" || pass.Trim() == "")
        {
            alert("กรุณากรอกชื่อผู้ใช้ และ รหัสผ่าน");
        }
        else
        {
            string conString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
            SqlConnection connection = new SqlConnection(conString);
            string sql = "SELECT MemberID,Firstname,Lastname FROM Member WHERE MemberID=@user AND Password=@pass";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@user", user);
            command.Parameters.AddWithValue("@pass", pass);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                Session["MemberID"] = reader.GetString(0);
                Session["FirstName"] = reader.GetString(1);
                Session["Lastname"] = reader.GetString(2);
                Session.Timeout = 30;
                Response.Redirect("Account.aspx");
            }
            else
            {
                alert("ชื่อผู้ใช้ หรือ รหัสผ่านไม่ถูกต้อง");
            }
            connection.Close();
        }     
    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        PanelUserAccount.Visible = false;
        PanelUserLogin.Visible = true;
        Session.RemoveAll();
        Response.Redirect("Default.aspx");
    }
}
