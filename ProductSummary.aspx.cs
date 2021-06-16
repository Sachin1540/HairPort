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
    String product_name = "";
    String table = "";
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
        if (!(Page.IsPostBack == true))
        {
            connection();
            if (Request.QueryString["pname"] == null)
            {
                throw new ArgumentException("No parameter specified");
            }
            else
            {
                product_name = Convert.ToString(Request.QueryString["pname"]);

                try
                {
                    da = new SqlDataAdapter("select * from Products where ProductId='" + product_name + "' ", cn);
                    dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        Session["proid"] = dt.Rows[0]["ProductId"].ToString();
                        table = table + "<table broder='1'><tr><td>Product ID:</td><td valign='top'>" + dt.Rows[0]["ProductId"].ToString() + "<br /></td></tr><tr><td>&nbsp;</td></tr>";
                        table = table + "<tr><td width='150px'>Product Name:</td><td>" + dt.Rows[0]["Name"].ToString() + "<br /></td></tr><tr><td>&nbsp;</td></tr>";
                        table = table + "<tr><td>Category:</td><td>" + dt.Rows[0]["Brand"].ToString() + "</td></tr><tr><td>&nbsp;</td></tr>";
                        table = table + "<tr><td valign='top'>Description:<br />&nbsp;</td><td>" + dt.Rows[0]["Summary"].ToString() + "<br /><br /></td></tr><tr><td>&nbsp;</td></tr>";
                        table = table + "<tr><td>Price:</td><td>" + dt.Rows[0]["Sell"].ToString() + "</td></tr></table>";

                        lbltext.Text = table;

                        table = "<table><tr><td valign='top'><div id='dynamicimg1'><img src='" + "images/" + dt.Rows[0]["ProductId"].ToString() + ".jpg" + "' '/></div></td></tr></table>";
                        lblimage.Text = table;

                        table = "";
                        da = null;
                        dt = null;


                        //fill qty.
                        da = new SqlDataAdapter("select Qty from Products where ProductId='" + product_name + "' ", cn);
                        dt = new DataTable();
                        da.Fill(dt);

                        String temp = dt.Rows[0]["Qty"].ToString();
                        int temp1 = Convert.ToInt16(temp);
                        if (temp1 > 0)
                        {

                            DdlQty.Visible = true;
                            btnCart.Visible = true;
                            for (int i = 1; i <= temp1; i++)
                            {
                                DdlQty.Items.Add(i.ToString());
                            }
                        }
                        else
                        {
                            DdlQty.Visible = false;
                            Response.Write("<script>alert('Product Out Of Stock') </script>");
                            btnCart.Visible = false;
                            txtlbl.Text = "";

                        }

                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
    private void autogenerate()
    {
        int a = 0;
        da = new SqlDataAdapter("select * from Cart", cn);
        dt = new DataTable();
        da.Fill(dt);
        Session["count"] = dt.Rows.Count;
        if (a.Equals(Session["count"]))
        {
            Session["count"] = 1;
        }
        else
        {
            Session["count"] = (int)Session["count"] + 1;
        }

        da = null;
        dt = null;
    }

    protected void btnCart_Click(object sender, ImageClickEventArgs e)
    {
        // Session["count"] = "1";
        Session["qty"] = DdlQty.Text;
        connection();
        Session["amt"] = "0";

        try
        {
            da = new SqlDataAdapter("select distinct(ProductId),Name,Brand,Sell,Summary from Products where ProductId='" + Session["proid"].ToString() + "' ", cn);
            dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {

                Session["Name"] = dt.Rows[0]["Name"].ToString();
                Session["Brand"] = dt.Rows[0]["Brand"].ToString();
                Session["Sell"] = dt.Rows[0]["Sell"].ToString();
                Session["Summary"] = dt.Rows[0]["Summary"].ToString();
            }
        }
        catch (Exception ex)
        {
        }

        // code for insert record.
        try
        {
            autogenerate();
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            String count = Session["count"].ToString();
            String custid = Session["cid"].ToString();
            String price = Session["Sell"].ToString();


            try
            {
                cn.Open();
            }
            catch
            {
                cn.Close();
                cn.Open();
            }
            SqlCommand query = new SqlCommand("select * from cart where cid = @cid and productid = @pid", cn);
            query.Parameters.AddWithValue("@cid",custid);
            query.Parameters.AddWithValue("@pid", Session["proid"].ToString());
            SqlDataReader sdr = query.ExecuteReader();
            if (sdr.HasRows)
            {
                cmd.CommandText = "update cart set qty = @qty where cid = @cid and productid = @pid";
                cmd.Parameters.AddWithValue("@qty", Session["qty"].ToString());
                cmd.Parameters.AddWithValue("@cid", custid);
                cmd.Parameters.AddWithValue("@pid", Session["proid"].ToString());
            }
            else
                cmd.CommandText = "insert into Cart values('" + count + "','" + Session["proid"].ToString() + "','" + Session["Name"].ToString() + "','" + Session["Brand"].ToString() + "','" + price + "','" + Session["Summary"].ToString() + "','" + custid + "'," + Convert.ToInt16(Session["qty"].ToString()) + ")";
            sdr.Close();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        catch (Exception ex)
        {
        }

        Response.Redirect("Cart.aspx");
    }

}
