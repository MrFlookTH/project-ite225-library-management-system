using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Category : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var _CatID = Request.QueryString["id"];
        if (_CatID != null)
        {
            string conString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(conString);
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "SELECT Name FROM Categories WHERE CatID = @CatID";
            comm.Parameters.AddWithValue("@CatID", _CatID);
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                Label1.Text = reader.GetString(0);
            }
            reader.Close();

            comm.CommandText = "SELECT B.BookID,B.Title,A.Name FROM Book B " +
                                "INNER JOIN Author A ON A.AuthorID = B.AuthorID " +
                                "WHERE B.CatID = @CatID ";
            reader = comm.ExecuteReader();
            DataTable dt = new DataTable();
            if (reader.HasRows)
            {
                dt.Load(reader);
                Repeater1.DataSource = dt;
                LabelCount.Text = dt.Rows.Count.ToString();
                Repeater1.DataBind();
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
            conn.Close();
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
        
    }
}