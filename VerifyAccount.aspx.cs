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
            Response.Write("<script>alert('" + ex.ToString() + "')</script>");

        }
    }

    protected void getdata()
    {
        da = new SqlDataAdapter("select * from Login", cn);
        dt = new DataTable();
        da.Fill(dt);
    }

    private void autogenerate()
    {
        getdata();
        count = dt.Rows.Count;
        if (count == 0 || count == 1)
        {
            count = 1;
        }
        else
        {
            count += 1;
        }

        da = null;
        dt = null;
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

    protected void btnProceed_Click(object sender, ImageClickEventArgs e)
    {
        String temp = txtVerify.Text;
        if (temp.Equals(Session["Sec_Code"]))
        {
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            cn.Open();
            autogenerate();
            cmd.CommandText = "insert into Login values('" + Session["SignUpEmail"].ToString() + "','" + Session["SignUpPass"].ToString() + "','" + Session["SignUpSeqQ"].ToString() + "','" + Session["SignUpSeqA"].ToString() + "','" + count + "')";
            cmd.ExecuteNonQuery();
            cmd = null;
            Response.Write("<script>alert('Account Created,Please Login') </script>");
            Response.Redirect("HomeBL.aspx");
        }
        else
        {
            lblverify.Text = "Invalid Code try again.";
        }
    }
}
