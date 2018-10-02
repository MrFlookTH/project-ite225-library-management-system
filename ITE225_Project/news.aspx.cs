using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class news : System.Web.UI.Page
{
    string conString = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                SqlConnection conn = new SqlConnection(conString);
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "SELECT Title,Description FROM News WHERE NewsID = @id";
                comm.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    LabelTitle.Text = dr.GetString(0);
                    LabelDesc.Text = dr.GetString(1);
                    dr.Close();
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