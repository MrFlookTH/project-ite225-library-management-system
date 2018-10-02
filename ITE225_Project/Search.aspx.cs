using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void alert(string msg)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + msg + "');</script>");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string conString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
        SqlConnection conn = new SqlConnection(conString);
        SqlCommand comm = new SqlCommand();
        comm.Connection = conn;
        comm.CommandType = CommandType.Text;
        comm.CommandText = "SELECT B.BookID,B.ISBN,B.Title,A.Name 'AName',P.Name 'PName' FROM Book B " +
                            "INNER JOIN Author A ON B.AuthorID = A.AuthorID " +
                            "INNER JOIN Publisher P ON B.PublisherID = P.PublisherID ";
        if (DropDownList1.SelectedValue == "Title")
        {
            comm.CommandText += "WHERE B.Title LIKE '%" + TextBoxSearch.Text + "%' ";
        }
        else if (DropDownList1.SelectedValue == "Author")
        {
            comm.CommandText += "WHERE A.Name LIKE '%" + TextBoxSearch.Text + "%' ";
        }
        else if (DropDownList1.SelectedValue == "Publisher")
        {
            comm.CommandText += "WHERE P.Name LIKE '%" + TextBoxSearch.Text + "%' ";
        }
        else if (DropDownList1.SelectedValue == "ISBN")
        {
            comm.CommandText += "WHERE B.ISBN = '" + TextBoxSearch.Text + "' ";
        }
        else if (DropDownList1.SelectedValue == "BookID")
        {
            comm.CommandText += "WHERE B.BookID ='" + TextBoxSearch.Text + "' ";
        }
        switch (DropDownList2.SelectedValue)
        {
            case "1": comm.CommandText += "AND B.CatID = 1"; break;
            case "2": comm.CommandText += "AND B.CatID = 2"; break;
            case "3": comm.CommandText += "AND B.CatID = 3"; break;
            case "4": comm.CommandText += "AND B.CatID = 4"; break;
            case "5": comm.CommandText += "AND B.CatID = 5"; break;
            case "6": comm.CommandText += "AND B.CatID = 6"; break;
            case "7": comm.CommandText += "AND B.CatID = 7"; break;
            case "8": comm.CommandText += "AND B.CatID = 8"; break;
            case "9": comm.CommandText += "AND B.CatID = 9"; break;
            case "10": comm.CommandText += "AND B.CatID = 10"; break;
        }

        conn.Open();
        SqlDataReader reader = comm.ExecuteReader();
        if (reader.HasRows)
        {
            DataTable dt = new DataTable();
            dt.Load(reader);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            PanelResult.Visible = true;
        }
        else
        {
            PanelResult.Visible = false;
            alert("ไม่พบข้อมูล");
        }
    }
}