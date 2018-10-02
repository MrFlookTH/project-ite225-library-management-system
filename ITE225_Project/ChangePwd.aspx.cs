using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class ChangePwd : System.Web.UI.Page
{
    string conString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["MemberID"] != null)
        {
            if (!Page.IsPostBack)
            {
                txtUser.Text = Session["MemberID"].ToString();
            }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
    protected void alert(string msg)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + msg + "');</script>");
    }
    protected void btnEditPwd_Click(object sender, EventArgs e)
    {
        if (txtOldPwd.Text == "" || txtNewPwd.Text == "")
        {
            alert("กรุณากรอกรหัสผ่าน");
        }
        else if (txtNewPwd.Text != txtConfirmNewPwd.Text)
        {
            alert(txtOldPwd.Text);
        }
        else
        {
            SqlConnection conn = new SqlConnection(conString);
            SqlCommand comm = new SqlCommand();
            SqlDataReader reader;
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "SELECT Password FROM Member " +
                               "WHERE MemberID = @MemberID";
            comm.Parameters.AddWithValue("@MemberID", Session["MemberID"]);
            conn.Open();
            reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                if (reader.GetString(0) == txtOldPwd.Text)
                {
                    reader.Close();
                    comm.CommandText = "UPDATE Member SET Password = @NewPwd WHERE MemberID = @MemberID";
                    comm.Parameters.AddWithValue("@NewPwd",txtNewPwd.Text);
                    if (comm.ExecuteNonQuery() > 0)
                    {
                        alert("เปลี่ยนรหัสผ่านเรียบร้อยแล้ว");
                    }
                    else
                    {
                        alert("เกิดข้อผิดพลาด");
                    }
                }
            }
            conn.Close();
            comm.Dispose();
        }      
    }
}