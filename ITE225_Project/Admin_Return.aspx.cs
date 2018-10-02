using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_Return : System.Web.UI.Page
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (LoadProfile() == true)
        {
            if (LoadBorrow() == true)
            {
                //if(LoadReserve == true)
            }
            else
            {
                PanelAlert.Visible = true;
            }
        }
        else
        {
            alert("ไม่พบข้อมูลผู้ใช้งาน");
        }
    }
    protected bool LoadBorrow()
    {
        SqlConnection conn = new SqlConnection(conString);
        SqlCommand comm = new SqlCommand();
        comm.Connection = conn;
        comm.CommandType = CommandType.Text;
        comm.CommandText = "SELECT Borrowing.BorrowID,Borrowing.BookID,Book.Title,Borrowing.BorrowDate,Borrowing.ReturnDate FROM Borrowing " +
                               "INNER JOIN Book ON Borrowing.BookID = Book.BookID WHERE Borrowing.MemberID = @MemberID AND Borrowing.Returned = 'false' " +
                               "ORDER BY Borrowing.BorrowID DESC";
        comm.Parameters.AddWithValue("@MemberID", txtUser.Text);
        conn.Open();
        SqlDataReader reader = comm.ExecuteReader();
        DataTable dt = new DataTable();
        if (reader.HasRows)
        {
            PanelBorrow.Visible = true;
            dt.Load(reader);
            RepeaterBorrow.DataSource = dt;
            RepeaterBorrow.DataBind();
            conn.Close();
            return true;
        }
        else
        {
            conn.Close();
            return false;
        }
    }
    protected bool LoadProfile()
    {
        SqlConnection conn = new SqlConnection(conString);
        SqlCommand comm = new SqlCommand();
        SqlDataReader reader;
        comm.Connection = conn;
        comm.CommandType = CommandType.Text;
        comm.CommandText = "SELECT IDNumber,Firstname,Lastname FROM Member " +
                           "WHERE MemberID = @MemberID";
        comm.Parameters.AddWithValue("@MemberID", txtUser.Text);
        conn.Open();
        reader = comm.ExecuteReader();
        if (reader.HasRows)
        {
            PanelSearch.Visible = false;
            PanelUserProfile.Visible = true;
            reader.Read();
            regUser.Text = txtUser.Text;
            regIDNumber.Text = reader.GetString(0);
            regName.Text = reader.GetString(1) + " ";
            regName.Text += reader.GetString(2);
            reader.Close();
            conn.Close();
            comm.Parameters.Clear();
            comm.Dispose();
            return true;
        }
        else
        {
            conn.Close();
            comm.Parameters.Clear();
            comm.Dispose();
            return false;
        }
        
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        PanelSearch.Visible = true;
        PanelUserProfile.Visible = false;
        PanelBorrow.Visible = false;
        PanelAlert.Visible = false;
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {     
        SqlConnection conn = new SqlConnection(conString);
        SqlCommand comm = new SqlCommand();
        comm.Connection = conn;
        comm.CommandType = CommandType.Text;
        conn.Open();
        foreach (RepeaterItem i in RepeaterBorrow.Items)
        {         
            CheckBox cb = (CheckBox)i.FindControl("chkBorrowID");
            if (cb.Checked && cb.Enabled == true)
            {
                HiddenField hiddenBorrowID = (HiddenField)i.FindControl("HiddenBorrowID");
                HiddenField hiddenBookID = (HiddenField)i.FindControl("HiddenBookID");
                comm.CommandText = "UPDATE Borrowing SET " +
                                   "Returned = 'True'" +
                                   "WHERE BorrowID = @BorrowID";
                comm.Parameters.AddWithValue("@BorrowID",hiddenBorrowID.Value);
                comm.ExecuteNonQuery();

                comm.CommandText = "UPDATE Book SET Status = '1' WHERE BookID = @BookID";
                comm.Parameters.AddWithValue("@BookID", hiddenBookID.Value);
                if (comm.ExecuteNonQuery() == 0)
                {
                    alert("เกิดข้อผิดพลาด");
                }
                else
                {
                    cb.Enabled = false;
                    alert("คืนหนังสือแล้ว");
                }
                comm.Parameters.Clear();
            }
        }
        //Response.Redirect("Admin_Return.aspx");
        conn.Close();
    }
}