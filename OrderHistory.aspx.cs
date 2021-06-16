using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Data.SqlClient;
public partial class Default2 : System.Web.UI.Page
{
    SqlDataAdapter da = new SqlDataAdapter();
    DataTable dt = new DataTable();
    String str = "";
    int count = 0;
    String email1 = null;

    SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    public void connection()
    {
        try
        {
            cn.Close();
            cn.Open();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.ToString() + "')</script>");

        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(Page.IsPostBack == true))
        {
            connection();
            //email();
            da = new SqlDataAdapter("select OrderId[ID],ProductId[Product ID],ProductName[Name],qty[Quantity],Total_Amount[Total],Booking_Date[Date],PaymentMode[Mode] from [Order] where email='" + Session["LoginId"] + "' order by orderId Desc", cn);
            dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
            }
        }
    }
    protected void email()
    {
        connection();
        da = new SqlDataAdapter("select Email from Login where code='" + Session["Cid"].ToString() + "' ", cn);
        dt = new DataTable();
        da.Fill(dt);
        email1 = dt.Rows[0]["Email"].ToString();

    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("cart.aspx");
    }
}
