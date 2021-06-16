using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class TPaspx : System.Web.UI.Page
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
            Response.Write("<script>alert('" + ex.ToString() + "')</script>");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]

    public List<string> GetListofProducts(string prefixText)

    {
        {

            cn.Open();
            SqlCommand cmd = new SqlCommand("select Name from Products where Name like '" + prefixText + "%' ", cn);
            cmd.Parameters.AddWithValue("@Name", prefixText);
            da.Fill(dt);

            List<string> ProductNames = new List<string>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ProductNames.Add(dt.Rows[i]["Products"].ToString());
            }
            return ProductNames;
        }

    }




    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ProductSummary.aspx");
    }
}
