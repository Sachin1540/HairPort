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
using System.Data.Sql;
using System.Data.SqlClient;

public partial class Default2 : System.Web.UI.Page
{
    SqlDataAdapter da = new SqlDataAdapter();
    DataTable dt = new DataTable();
    String Code = "";
    SqlCommand cmd = new SqlCommand();
    int count;

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
            Response.Write("<script>alert(" + ex.ToString() + ")</script>");

        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(Page.IsPostBack == true))
        {
            connection();
        }
        else
        { }
    }


    protected void IMGYES_Click(object sender, ImageClickEventArgs e)
    {
        cmd = null;
        cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "Delete from Login where code=" + Session["cid"] + "";
        cmd.ExecuteNonQuery();
        cmd = null;

        cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.Connection = cn;
        cmd.CommandText = "Delete from Cust_Profile where cid=" + Session["cid"] + "";
        cmd.ExecuteNonQuery();
        cmd = null;

        Response.Redirect("HomeBL.aspx");
    }
    protected void IMGNO_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Products.aspx");
    }
}
