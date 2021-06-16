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
using System.IO;
using System.Data.SqlClient;

public partial class Default2 : System.Web.UI.Page
{
	
    SqlDataAdapter da = new SqlDataAdapter();
    DataTable dt = new DataTable();
    String str = "";
    int count = 0;

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
            //check profile
            chkprofile();


            forallBrands();
            


        }
    }
    public void chkprofile()
    {
        try
        {
            da = new SqlDataAdapter("select * from cust_profile where cid='"+ Session["cid"].ToString() +"'", cn);
            dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
            }
            else
            {
                Response.Redirect("Profile.aspx");
            }
        }
        catch (Exception ex) { }
    }
    protected void forallBrands()
    {
        try
        {
            da = new SqlDataAdapter("select ProductId,Name,sell from Products", cn);
            dt = new DataTable();
            da.Fill(dt);

            str = str + "<table cellspacing='6px'><tr>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                if (count >= 4)
                {
                    str = str + "<tr><td>";
                    count = 0;
                }
                else
                {
                    str = str + "<td>";
                }

                count += 1;

                str = str + "<a href='ProductSummary.aspx?pname=" + dt.Rows[i]["ProductId"].ToString() + " ' ><img src='" + "images/" + dt.Rows[i]["ProductId"].ToString() + ".jpg" + "' width='190px' height='220px' '/></a><br/><center>" + dt.Rows[i]["Name"].ToString() + "<br/>Rs." + dt.Rows[i]["sell"].ToString() + "</center></td>";



            }
            str = str + "</tr></table>";
        }
        catch (Exception ex)
        { }
        lbldisply.Text = str;
    }

    protected void DdlBrand_SelectedIndexChanged(object sender, EventArgs e)
    {  
        if (DdlBrand.Text != "All")
        {
            try
            {
                da = new SqlDataAdapter("select ProductId,Name,sell from Products where Brand='" + DdlBrand.Text + "'", cn);
                dt = new DataTable();
                da.Fill(dt);

                str = str + "<table cellspacing='6px'><tr>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    if (count >= 4)
                    {
                        str = str + "<tr><td>";
                        count = 0;
                    }
                    else
                    {
                        str = str + "<td>";
                    }

                    count += 1;
                    str = str + "<a href='ProductSummary.aspx?pname=" + dt.Rows[i]["ProductId"].ToString() + " ' ><img src='" + "images/" + dt.Rows[i]["ProductId"].ToString() + ".jpg" + "' width='200px' height='220px' '/></a><br/><center>" + dt.Rows[i]["Name"].ToString() + "<br/>Rs." + dt.Rows[i]["sell"].ToString() + "</center></td>";
                }
                str = str + "</tr></table>";
            }
            catch (Exception ex)
            { }
            lbldisply.Text = str;
        }

        if (DdlBrand.Text == "All")
        {
            forallBrands();
        }

    }
 
}

