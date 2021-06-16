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
            Response.Write("<script>alert('Error in connection')<'/'script>");
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        connection();
    }
    protected void btnLogin_Click(object sender, ImageClickEventArgs e)
    {
        da = new SqlDataAdapter("select Email,Password from Login where Email='" + txtemail.Text + "' and Password='" + txtpassword.Text + "'", cn);
        dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count == 0)
        {
            //if Id & Password is not found in database
            txtpassword.Text = "";
            Response.Write("<script>alert('Either Username or password does not match.')</script>");
            txtpassword.Focus();
        }
        else
        {
            String save = "";
            save = dt.Rows[0]["Password"].ToString();
            if (save == txtpassword.Text)
            {
                //Show other page
                da = new SqlDataAdapter("select code from Login where Email='" + txtemail.Text + "'", cn);
                dt = new DataTable();
                da.Fill(dt);

                Session["cid"] = dt.Rows[0]["code"].ToString();
                Session["LoginId"] = txtemail.Text;
                //Session["LoginPass"] = txtpassword.Text;

                if (txtemail.Text == "noreplyhairport@gmail.com")
                    Response.Redirect("AdminProducts.aspx");
                else
                    Response.Redirect("Profile.aspx");
            }
            else
            {
                //error code
                Response.Write("<script>alert('Either Username or password does not match.')</script>");
                txtpassword.Text = "";
                txtpassword.Focus();
            }
        }
    }
}
