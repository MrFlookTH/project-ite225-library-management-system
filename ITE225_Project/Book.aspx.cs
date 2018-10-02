using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Book : System.Web.UI.Page
{
    string conString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
    int BorrowDays;
    protected void alert(string msg)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + msg + "');</script>");
    }
    private void SelectBorrowDays()
    {
        SqlConnection conn = new SqlConnection(conString);
        SqlCommand comm = new SqlCommand();
        comm.Connection = conn;
        comm.CommandType = CommandType.Text;
        comm.CommandText = "SELECT Value FROM Setting WHERE Property = 'BorrowDays'";
        conn.Open();
        SqlDataReader reader = comm.ExecuteReader();
        reader.Read();
        BorrowDays = Convert.ToInt32(reader.GetString(0));
        reader.Close();
        conn.Close();
    }
    private void LoadBorrowerData()
    {
        SqlConnection conn = new SqlConnection(conString);
        SqlCommand comm = new SqlCommand();
        comm.Connection = conn;
        comm.CommandType = CommandType.Text;
        comm.CommandText = "SELECT B.BorrowID, M.FirstName, M.LastName, B.BorrowDate, B.ReturnDate, B.Remark FROM Borrowing B " +
                           "INNER JOIN Member M ON M.MemberID = B.MemberID " +
                           "WHERE B.BookID = @BookID";
        comm.Parameters.AddWithValue("@BookID", BorrowBookID.Text);
        conn.Open();
        SqlDataReader reader = comm.ExecuteReader();
        if (reader.HasRows)
        {
            reader.Read();
            txtBorrowerID.Text = reader.GetString(0);
            txtBorrowerName.Text = reader.GetString(1) + " ";
            txtBorrowerName.Text += reader.GetString(2);
            txtBorrowerTitle.Text = BorrowBookTitle.Text;
            txtBorrowerDate.Text = reader.GetDateTime(3).ToLongDateString();
            txtBorrowerReturn.Text = reader.GetDateTime(4).ToLongDateString();
            txtBorrowerRemark.Text = reader.GetString(5);
        }
        conn.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            SelectBorrowDays();
            BorrowDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            BorrowReturn.Text = DateTime.Now.AddDays(BorrowDays).ToString("dd/MM/yyyy");

            var _BookID = Request.QueryString["BookID"];
            if (_BookID != null)
            {
                SqlConnection conn = new SqlConnection(conString);
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "SELECT B.BookID,B.ISBN,B.Title,B.Description,C.Name,B.Page,A.Name,P.Name,B.CatID,B.Status FROM Book B " +
                                   "INNER JOIN Categories C ON B.CatID = C.CatID " +
                                   "INNER JOIN Author A ON B.AuthorID = A.AuthorID " +
                                   "INNER JOIN Publisher P ON B.PublisherID = P.PublisherID " +
                                   "WHERE B.BookID = @BookID";
                comm.Parameters.AddWithValue("@BookID", _BookID);
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    ImageBook.ImageUrl = "image/book/" + reader.GetInt32(0) + ".jpg";
                    LabelBookID.Text = reader.GetInt32(0).ToString();
                    LabelTitle.Text = reader.GetString(2);
                    BorrowBookTitle.Text = reader.GetString(2);
                    LabelDesc.Text = reader.GetString(3);
                    LabelISBN.Text = reader.GetString(1);
                    BorrowBookID.Text = reader.GetInt32(0).ToString();
                    BorrowISBN.Text = reader.GetString(1);
                    LabelCategory.Text = reader.GetString(4);
                    LabelPage.Text = reader.GetString(5);
                    LabelAuthor.Text = reader.GetString(6);
                    LabelPublisher.Text = reader.GetString(7);
                    if(reader.GetString(9) == "1")
                    {
                        LabelStatus.ForeColor = System.Drawing.Color.Green;
                        LabelStatus.Text = "Available";
                        if (Session["AdminID"] != null)
                        {
                            btnBorrowModal.Visible = true;
                            btnReserveModal.Visible = false;
                        }
                        else
                        {
                            Label1.ForeColor = System.Drawing.Color.Green;
                            Label1.Visible = true;
                        }

                    }
                    else if (reader.GetString(9) == "0")
                    {
                        LabelStatus.ForeColor = System.Drawing.Color.Red;
                        LabelStatus.Text = "Checked Out";
                        btnBorrowModal.Visible = false;
                        /*
                        if (Session["MemberID"] != null || Session["AdminID"] != null)
                        {
                            btnReserveModal.Visible = true;
                        }*/
                        if(Session["AdminID"] != null)
                        {
                            LoadBorrowerData();
                            btnBorrowerData.Visible = true;
                        }
                        
                    }
                    else
                    {
                        /* ระบบจองหนังสือ
                        LabelStatus.ForeColor = System.Drawing.Color.Orange;
                        LabelStatus.Text = "Reserved";
                        btnBorrowModal.Visible = false;
                        if (Session["MemberID"] != null)
                        {
                            btnReserveModal.Visible = false;
                        }
                        if (Session["AdminID"] != null)
                        {
                            btnReserverData.Visible = true;
                        }
                        */
                    }

                    int CatID = reader.GetInt32(8);

                    reader.Close();
                    comm.CommandText = "SELECT Top 5 BookID,Title FROM Book " +
                                       "WHERE CatID = @CatID " +
                                       "ORDER BY NEWID(); ";
                    comm.Parameters.AddWithValue("@CatID",CatID);
                    DataTable dt = new DataTable();
                    reader = comm.ExecuteReader();
                    dt.Load(reader);
                    RepeaterBookRelated.DataSource = dt;
                    RepeaterBookRelated.DataBind();
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
    protected void btnBorrowSave_Click(object sender, EventArgs e)
    {
        string conString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
        SqlConnection conn = new SqlConnection(conString);
        SqlCommand comm = new SqlCommand();
        comm.Connection = conn;
        comm.CommandType = CommandType.Text;
        //Select BorrowMax
        comm.CommandText = "SELECT Value FROM Setting WHERE Property = 'BorrowMax'";
        conn.Open();
        SqlDataReader reader = comm.ExecuteReader();
        reader.Read();
        int BorrowMax = Convert.ToInt32(reader.GetString(0));
        reader.Close();
        //Check Member exist
        comm.CommandText = "SELECT COUNT(*) FROM Member WHERE MemberID = @MemberID";
        comm.Parameters.AddWithValue("@MemberID",BorrowUser.Text);
        reader = comm.ExecuteReader();
        reader.Read();
        if (reader.GetInt32(0) > 0)
        {
            reader.Close();
            //เช็คจำนวนเล่มที่ยังไม่ได้คืน
            comm.CommandText = "SELECT COUNT(*) FROM Borrowing WHERE MemberID = @MemberID AND Returned = 'false'";
            reader = comm.ExecuteReader();
            reader.Read();
            if (reader.GetInt32(0) < BorrowMax)
            {
                reader.Close();
                //เช็คว่ายืมเล่มนี้ไปหรือยัง
                comm.CommandText = "SELECT COUNT(*) FROM Borrowing WHERE MemberID = @MemberID AND Returned = 'false' AND BookID = @BookID";
                comm.Parameters.AddWithValue("@BookID", BorrowBookID.Text);
                reader = comm.ExecuteReader();
                reader.Read();
                if (reader.GetInt32(0) == 0)
                {
                    reader.Close();
                    //บันทึกข้อมูล
                    comm.CommandText = "INSERT INTO Borrowing(BorrowID,MemberID,BookID,BorrowDate,ReturnDate,Remark,Returned) " +
                                       "VALUES(@BorrowID,@MemberID,@BookID,@BorrowDate,@ReturnDate,@Remark,@Returned)";
                    string BorrowID = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
                    comm.Parameters.AddWithValue("@BorrowID", BorrowID);
                    comm.Parameters.AddWithValue("@BorrowDate", DateTime.Now);
                    SelectBorrowDays();
                    comm.Parameters.AddWithValue("@ReturnDate", DateTime.Now.AddDays(BorrowDays));
                    comm.Parameters.AddWithValue("@Remark", BorrowRemark.Text);
                    comm.Parameters.AddWithValue("@Returned", false);
                    comm.ExecuteNonQuery();

                    //เปลี่ยนสถานะหนังสือ
                    comm.CommandText = "UPDATE Book SET Status = '0' WHERE BookID = @BookID";
                    if (comm.ExecuteNonQuery() > 0)
                    {
                        alert("บันทึกข้อมูลเรียบร้อยแล้ว");
                        Response.Redirect(Page.Request.Url.ToString(), true);
                    }
                    else
                    {
                        alert("เกิดข้อผิดพลาด");
                    }
                }
                else
                {
                    alert("คุณยืมหนังสือเล่มนี้แล้ว");
                }         
            }
            else if (reader.GetInt32(0) == BorrowMax)
            {
                alert("ไม่อนุญาตให้ยืมหนังสือเกิน " + BorrowMax + " เล่ม");
            }
        }
        else
        {
            alert("ไม่พบข้อมูลผู้ใช้งาน");
        }
        comm.Parameters.Clear();
        comm.Dispose();
        conn.Close();
    }

    protected void btnReserveModal_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(conString);
        SqlCommand comm = new SqlCommand();
        comm.Connection = conn;
        comm.CommandType = CommandType.Text;
        comm.CommandText = "INSERT INTO Reserving(MemberID,BookID,ReserveDate,Status) " +
                            "VALUES(@MemberID,@BookID,GETDATE(),'true')";
        comm.Parameters.Add("@MemberID", SqlDbType.NVarChar).Value = Session["MemberID"];
        comm.Parameters.Add("@BookID", SqlDbType.NVarChar).Value = LabelBookID.Text;
        conn.Open();
        if (comm.ExecuteNonQuery() == 1)
        {
            comm.CommandText = "UPDATE Book SET Status = '2' WHERE BookID = @BookID";
            comm.ExecuteNonQuery();
            Response.Redirect("Book.aspx?BookID=" + LabelBookID.Text);
        }
        conn.Close();
        
    }
}