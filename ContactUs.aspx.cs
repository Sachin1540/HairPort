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
    SqlCommand cmd = new SqlCommand();

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
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "insert into Contact values('" + txtname.Text + "','" + txtmobileno.Text + "','" + txtemail.Text + "','" + txtsubject.Text + "','" + txtmessage.Text + "')";
        cmd.ExecuteNonQuery();
        cmd = null;
        Response.Write("<script>alert('Submitted Successfully')</script>");
        Server.Transfer("ContactUs.aspx");


    }
}
