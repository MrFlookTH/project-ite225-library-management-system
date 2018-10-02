using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Account : System.Web.UI.Page
{
    static string conString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
    SqlConnection conn = new SqlConnection(conString);
    protected string ProcessStatus(object ReturnDate, object Returned)
    {
        DateTime rDate = Convert.ToDateTime(ReturnDate);
        bool r = Convert.ToBoolean(Returned);
        if (r == true)
        {
            //return "<p style=\"text-align:center;\">&#10004;</p>";
            return "<p style=\"color:gray\">ส่งคืนแล้ว</p>";
        }
        else if (DateTime.Today > rDate)
        {
            return "<p style=\"color:red\">ล่าช้า</p>";
        }
        else
        {
            return "<p style=\"color:green\">ปกติ</p>";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["MemberID"] != null)
        {
            if (!Page.IsPostBack)
            {
                LoadRecommend();
                LoadBorrowData("Borrowed");
            }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

    private void LoadRecommend()
    {
        //หนังสือแนะนำ
        SqlCommand comm = new SqlCommand();
        comm.Connection = conn;
        comm.CommandText = "SELECT Top 5 BookID,Title FROM Book " +
                           "ORDER BY NEWID(); ";
        conn.Open();
        SqlDataReader reader = comm.ExecuteReader();
        DataTable dt = new DataTable();
        dt.Load(reader);
        RepeaterBookRecommend.DataSource = dt;
        RepeaterBookRecommend.DataBind();
        conn.Close();
    }

    private void LoadBorrowData(string value)
    {
        SqlCommand comm = new SqlCommand();
        comm.Connection = conn;
        comm.CommandType = CommandType.Text;
        if (value == "Borrowed")
        {
            comm.CommandText = "SELECT Borrowing.BorrowID,Borrowing.BookID,Book.Title,Borrowing.BorrowDate,Borrowing.ReturnDate,Borrowing.Returned FROM Borrowing " +
                                "INNER JOIN Book ON Borrowing.BookID = Book.BookID WHERE Borrowing.MemberID = @MemberID AND Borrowing.Returned = 'False' " +
                                "ORDER BY Borrowing.BorrowID DESC";
        }
        else if (value == "Late")
        {
            comm.CommandText = "SELECT Borrowing.BorrowID,Borrowing.BookID,Book.Title,Borrowing.BorrowDate,Borrowing.ReturnDate,Borrowing.Returned FROM Borrowing " +
                                "INNER JOIN Book ON Borrowing.BookID = Book.BookID WHERE Borrowing.MemberID = @MemberID AND Borrowing.Returned = 'False' AND Borrowing.ReturnDate < GETDATE() " +
                                "ORDER BY Borrowing.BorrowID DESC";
        }
        else if (value == "Returned")
        {
            comm.CommandText = "SELECT Borrowing.BorrowID,Borrowing.BookID,Book.Title,Borrowing.BorrowDate,Borrowing.ReturnDate,Borrowing.Returned FROM Borrowing " +
                                "INNER JOIN Book ON Borrowing.BookID = Book.BookID WHERE Borrowing.MemberID = @MemberID AND Borrowing.Returned = 'True' " +
                                "ORDER BY Borrowing.BorrowID DESC";
        }
        else if (value == "All")
        {
            comm.CommandText = "SELECT Borrowing.BorrowID,Borrowing.BookID,Book.Title,Borrowing.BorrowDate,Borrowing.ReturnDate,Borrowing.Returned FROM Borrowing " +
                                "INNER JOIN Book ON Borrowing.BookID = Book.BookID WHERE Borrowing.MemberID = @MemberID " +
                                "ORDER BY Borrowing.BorrowID DESC";
        }
        
        comm.Parameters.AddWithValue("@MemberID", Session["MemberID"]);
        conn.Open();
        SqlDataReader reader = comm.ExecuteReader();
        DataTable dt = new DataTable();
        if (reader.HasRows)
        {
            dt.Load(reader);
            RepeaterBorrow.DataSource = dt;
            RepeaterBorrow.DataBind();
            PanelAlertBorrow.Visible = false;
        }
        else
        {
            RepeaterBorrow.DataSource = null;
            RepeaterBorrow.DataBind();
            PanelAlertBorrow.Visible = true;
        }
        reader.Close();
        dt.Dispose();
    }

    protected void ddlBorrow_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadBorrowData(ddlBorrow.SelectedValue.ToString());
    }
}