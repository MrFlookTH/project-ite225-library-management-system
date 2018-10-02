using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["MemberID"] != null)
        {
            alert("กรุณาออกจากระบบ");
            Response.Redirect("Default.aspx");
        }
    }
    protected bool isDigits(string n)
    {
        return n.All(char.IsDigit);
    }
        
    protected void alert(string msg)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('"+ msg +"');</script>");
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (regUser.Text.Trim() == "")
        {
            alert("กรุณากรอกชื่อผู้ใช้งาน");
            regUser.Focus();
        }
        else if (regPass.Text.Trim() == "")
        {
            alert("กรุณากรอกรหัสผ่าน");
            regPass.Focus();
        }
        else if (regPassConfirm.Text != regPass.Text)
        {
            alert("รหัสผ่านไม่ตรงกัน");
            regPassConfirm.Focus();
        }
        else if (regIDNumber.Text.Trim() == "")
        {
            alert("กรุณากรอกหมายเลขบัตรประชาชน");
            regIDNumber.Focus();
        }
        else if (!isDigits(regIDNumber.Text.Trim()))
        {
            alert("หมายเลขบัตรประชาชนไม่ถูกต้อง");
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
            alert("กรุณากรอกที่อยู่");
            regAddress.Focus();
        }
        else if (!isDigits(regTel.Text.Trim()))
        {
            alert("เบอร์โทรศัพท์ไม่ถูกต้อง");
            regTel.Focus();
        }
        else if (regEmail.Text.Trim() == "")
        {
            alert("กรุณากรอกอีเมล");
            regEmail.Focus();
        }
        else
        {
            string ConString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(ConString);
            string sql = "SELECT MemberID FROM Member WHERE MemberID=@MemberID";
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.Parameters.AddWithValue("@MemberID", regUser.Text);
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                alert("ชื่อผู้ใช้ซ้ำกัน");
                regUser.Focus();
                conn.Close();
            }
            else
            {
                comm.Parameters.Clear();
                sql = "INSERT INTO Member(MemberID,Password,Firstname,Lastname,IDNumber,Address,Tel,Email) " +
                  "VALUES(@MemberID,@Password,@Firstname,@Lastname,@IDNumber,@Address,@Tel,@Email);";
                comm.CommandText = sql;
                comm.Parameters.AddWithValue("@MemberID", regUser.Text);
                comm.Parameters.AddWithValue("@Password", regPass.Text);
                comm.Parameters.AddWithValue("@Firstname", regFirstname.Text);
                comm.Parameters.AddWithValue("@Lastname", regLastname.Text);
                comm.Parameters.AddWithValue("@IDNumber", regIDNumber.Text);
                comm.Parameters.AddWithValue("@Address", regAddress.Text);
                comm.Parameters.AddWithValue("@Tel", regTel.Text);
                comm.Parameters.AddWithValue("@Email", regEmail.Text);

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();
                if (comm.ExecuteNonQuery() == 1)
                {
                    alert("สมัครสมาชิกเรียบร้อยแล้ว");
                    Response.Redirect("Default.aspx");
                    conn.Close();
                    comm.Dispose();
                }
                conn.Close();
                comm.Dispose();
            }      
        }      
    }
}