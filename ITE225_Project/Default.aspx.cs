using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    string conString = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlConnection conn = new SqlConnection(conString);
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "SELECT Top 5 NewsID,Title FROM News ORDER BY NewsID DESC";
            conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            if(dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                RepeaterNews.DataSource = dt;
                RepeaterNews.DataBind();
            }
            conn.Close();
        }
    }
}