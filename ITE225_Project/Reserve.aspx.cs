using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Reserve : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string BookID = Request.QueryString["BookID"];
            if (BookID != null && Session["MemberID"] != null)
            {
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "SELECT Borrowing.BorrowID,Borrowing.BookID,Book.Title,Borrowing.BorrowDate,Borrowing.ReturnDate FROM Borrowing " +
                                "INNER JOIN Book ON Borrowing.BookID = Book.BookID WHERE Borrowing.BookID = @BookID AND Borrowing.Returned = 'false'";
                comm.Parameters.Add("@BookID",SqlDbType.Int).Value = BookID;
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                if(dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    RepeaterBorrowing.DataSource = dt;
                    RepeaterBorrowing.DataBind();
                }
                conn.Close();
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }       
    }

}