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
    SqlCommand cmd = new SqlCommand();

    String id = "";

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


            //code to display Order Details wid customer
            try
            {
                da = new SqlDataAdapter("select distinct(OrderId),Email,ProductId as 'Id',ProductName as 'Name',Total_Amount as 'Total',Booking_Date as 'BDate' from [Order]", cn);
                dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                    lbl1.Visible = false;
                }
                else
                {
                    lbl1.Visible = true;
                }
            }
            catch (Exception ex)
            {
            }



        }
    }
}

