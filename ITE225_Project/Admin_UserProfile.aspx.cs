using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_UserProfile : System.Web.UI.Page
{
    string conString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["AdminID"] == null)
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
    protected void alert(string msg)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + msg + "');</script>");
    }
    protected bool isDigits(string n)
    {
        return n.All(char.IsDigit);
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(conString);
        SqlCommand comm = new SqlCommand();
        SqlDataReader reader;
        comm.Connection = conn;
        comm.CommandType = CommandType.Text;
        comm.CommandText = "SELECT IDNumber,Firstname,Lastname,Address,Tel,Email FROM Member " +
                           "WHERE MemberID = @MemberID";
        comm.Parameters.AddWithValue("@MemberID", txtUser.Text);
        conn.Open();
        reader = comm.ExecuteReader();
        if (reader.HasRows)
        {
            reader.Read();
            regUser.Text = txtUser.Text;
            regIDNumber.Text = reader.GetString(0);
            regFirstname.Text = reader.GetString(1);
            regLastname.Text = reader.GetString(2);
            regAddress.Text = reader.GetString(3);
            regTel.Text = reader.GetString(4);
            regEmail.Text = reader.GetString(5);
            reader.Close();
            PanelSearch.Visible = false;
            PanelUserProfile.Visible = true;
        }
        else
        {
            alert("ไม่พบข้อมูลสมาชิก");
        }
        conn.Close();
        comm.Parameters.Clear();
        comm.Dispose();
    }
    protected void btnEditProfile_Click(object sender, EventArgs e)
    {
        if (regIDNumber.Text.Trim() == "")
        {
            alert("กรุณากรอกหมายเลขบัตรประชาชน");
            regIDNumber.Focus();
        }
        else if (regFirstname.Text.Trim() == "")
        {
            alert("กรุณากรอกชื่อจริง");
            regFirstname.Focus();
        }
        else if (regLastname.Text.Trim() == "")
        {
            alert("กรุณากรอกนามสกุล");
            regLastname.Focus();
        }
        else if (regAddress.Text.Trim() == "")
        {
            alert("กรุณากรอกที่อยู่");
            regAddress.Focus();
        }
        else if (regTel.Text.Trim() == "")
        {
            alert("กรุณากรอกเบอร์โทรศัพท์");
            regTel.Focus();
        }
        else if (!isDigits(regTel.Text.Trim()))
        {
            alert("เบอร์โทรศัพท์ไม่ถูกต้อง");
            regTel.Focus();
        }
        else if (regEmail.Text.Trim() == "")
        {
            alert("กรุณากรอกอีเมล");
            regTel.Focus();
        }
        else
        {
            string MemberID = txtUser.Text;
            SqlConnection conn = new SqlConnection(conString);
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "UPDATE Member SET " +
                               "IDNumber = '" + regIDNumber.Text + "', " +
                               "Firstname = '" + regFirstname.Text + "', " +
                               "Lastname = '" + regLastname.Text + "', " +
                               "Address = '" + regAddress.Text + "', " +
                               "Tel = '" + regTel.Text + "', " +
                               "Email = '" + regEmail.Text + "' " +
                               "WHERE MemberID = '" + MemberID + "'";
            if (conn.State == ConnectionState.Open) conn.Close();
            conn.Open();
            if (comm.ExecuteNonQuery() > 0)
            {
                alert("บันทึกข้อมูลเรียบร้อยแล้ว");
            }
            else
            {
                alert("เกิดข้อผิดพลาด");
            }
            conn.Close();
            comm.Dispose();
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        PanelSearch.Visible = true;
        PanelUserProfile.Visible = false;
        Response.Redirect("Admin_UserProfile.aspx");
    }
}