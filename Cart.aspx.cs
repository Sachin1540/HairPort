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
    SqlDataAdapter da1 = new SqlDataAdapter();
    DataTable dt1 = new DataTable();
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

            //code to display cart
            try
            {
                try
                {
                    connection();
                    da1 = new SqlDataAdapter("select productid,qty from Cart where cid='" + Session["cid"].ToString() + "' ", cn);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        int cartqty = Convert.ToInt32(dt1.Rows[i]["qty"].ToString());
                        SqlCommand s = new SqlCommand("select qty from products where productid='" + dt1.Rows[i]["productid"].ToString() + "'", cn);
                        SqlDataReader f = s.ExecuteReader();
                        f.Read();
                        int availqnty = (int)f[0];
                        if (cartqty > availqnty)
                        {
                            connection();
                            cmd = new SqlCommand("delete from Cart where ProductId='" + dt1.Rows[i]["productid"].ToString() + "' and Cid='" + Session["cid"].ToString() + "' ", cn);
                            cmd.Connection = cn;
                            cmd.ExecuteNonQuery();
                        }


                    }
                    dt1 = null;
                    da1 = null;
                }
                catch { }
                connection();
                da = new SqlDataAdapter("select ProductId[Product],Name,Brand[Category],Sell_Price[Price],Summary[Description],Qty[Quantity] from Cart where Cid='" + Session["cid"].ToString() + "' ", cn);
                dt = new DataTable();
                da.Fill(dt);



                if (dt.Rows.Count > 0)
                {
                    ImageButton1.Enabled = false;
                    ImageButton1.Visible = false;
                    GridView1.DataSource = dt;
                    GridView1.DataBind();


                    //code for button visibility.
                    btnPayment.Visible = true;
                    ImageButton2.Visible = true;
                }
                else
                {
                    ImageButton1.Visible = true;
                    ImageButton2.Visible = true;
                    ImageButton1.Enabled = false;
                }
            }
            catch (Exception ex)
            {
            }

            //code for amt retrive from table

            Session["amt"] = "0";
            String sqlq = "Select * from Cart where cid='"+ Session["cid"].ToString() +"'";
            da = new SqlDataAdapter(sqlq, cn);
            dt = new DataTable();
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                if (dt.Rows.Count > 0)
                {
                    Session["price"] = dt.Rows[i]["Sell_Price"].ToString();
                }

                // total amt.
                int qty = Convert.ToInt16(dt.Rows[i]["qty"].ToString());
                long price1 = Convert.ToInt64(Session["price"].ToString());
                long tprice = qty * price1;
                long pamt = Convert.ToInt64(Session["amt"].ToString());
                Session["amt"] = pamt + tprice;
                lbltotal.Text = "Total Amount: ";
                lbltotalamt.Text = Session["amt"].ToString();
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

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridView1.SelectedRow;
        id = GridView1.SelectedRow.Cells[1].Text;
        Session["delete_id"] = id;
        deletecart();
    }

    public void deletecart()
    {
        connection();
        cmd = new SqlCommand("delete from Cart where ProductId='" + Session["delete_id"].ToString() + "' and Cid='" + Session["cid"].ToString() + "' ", cn);
        cmd.Connection = cn;
        cmd.ExecuteNonQuery();

        Session["amt"] = "0";
        String sqlq = "Select * from Cart where cid='" + Session["cid"].ToString() + "'";
        da = new SqlDataAdapter(sqlq, cn);
        dt = new DataTable();
        da.Fill(dt);

        for (int i = 0; i < dt.Rows.Count; i++)
        {

            if (dt.Rows.Count > 0)
            {
                Session["price"] = dt.Rows[i]["Sell_Price"].ToString();
            }

            // total amt.
            int qty = Convert.ToInt16(dt.Rows[i]["qty"].ToString());
            long price1 = Convert.ToInt64(Session["price"].ToString());
            long tprice = qty * price1;
            long pamt = Convert.ToInt64(Session["amt"].ToString());
            Session["amt"] = pamt + tprice;
            lbltotal.Text = "Total Amount: ";
            lbltotalamt.Text = Session["amt"].ToString();
        }

        try
        {
            da = new SqlDataAdapter("select ProductId[Product],Name,Brand[Category],Sell_Price[Price],Summary[Description],Qty[Quantity] from Cart where Cid='" + Session["cid"].ToString() + "' ", cn);
            dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
            else
            {
                Response.Redirect("Products.aspx");
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnPayment_Click(object sender, ImageClickEventArgs e)
    {
        Session["finalamount"] = lbltotalamt.Text;
        Response.Redirect("Payment.aspx");
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //Server.Transfer("Products.aspx");
    }
    protected void btnshop_Click(object sender, ImageClickEventArgs e)
    {
        Server.Transfer("Products.aspx");
    }
}
