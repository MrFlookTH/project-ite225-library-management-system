using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


public partial class Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminID"] != null)
        {
            Session.Remove("MemberID");
            Session.Remove("Firstname");
            Session.Remove("Lastname");
            PanelAdminLogin.Visible = false;
            PanelAdminMenu.Visible = true;
        }     
    }
    protected void alert(string msg)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + msg + "');</script>");
    }
    protected void btnAdminLogin_Click(object sender, EventArgs e)
    {
        string conString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
        SqlConnection conn = new SqlConnection(conString);
        string sql = "SELECT AdminID FROM Admin WHERE AdminID=@AdminID AND Password=@password";
        SqlCommand comm = new SqlCommand(sql,conn);
        comm.Parameters.AddWithValue("@AdminID",adminUser.Text);
        comm.Parameters.AddWithValue("@password",adminPass.Text);
        conn.Open();
        SqlDataReader reader = comm.ExecuteReader();
        if (reader.HasRows)
        {
            Session["AdminID"] = adminUser.Text;
            Response.Redirect("Admin.aspx#head");
            conn.Close();
        }
        else
        {
            alert("ชื่อผู้ใช้งาน หรือ รหัสผ่านไม่ถูกต้อง");
            conn.Close();
        }     
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.Remove("AdminID");
        Response.Redirect("Admin.aspx");
    }

}