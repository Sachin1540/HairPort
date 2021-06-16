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
using System.Net;
using System.Net.Mail;

public partial class Default2 : System.Web.UI.Page
{
    SqlDataAdapter da = new SqlDataAdapter();
    DataTable dt = new DataTable();
    SqlDataAdapter da1 = new SqlDataAdapter();
    DataTable dt1 = new DataTable();
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
            Ddlyear.Items.Clear();
            for (int i = 1; i <= 20; i++)
            {
                Ddlyear.Items.Add((Convert.ToInt16(DateTime.Today.Year - 1) + i).ToString());
            }

            // call auto generate for order ID
            autogenerate();
            lblorderid.Text = Session["count"].ToString();
            
            lblcid.Text = Session["cid"].ToString();
            lbltotalamt.Text = Session["finalamount"].ToString();

            //code for customer id.

            //code to display total amount
        }
    }

    private void autogenerate()
    {
        int a = 0;
        da = new SqlDataAdapter("select max(Orderid) from [Order]", cn);
        dt = new DataTable();
        da.Fill(dt);
        Session["count"] = dt.Rows[0][0].ToString();
        try
        {
            if (a.Equals(Session["count"]))
            {
                Session["count"] = 1;
            }
            else
            {
                Session["count"] = Convert.ToInt32(Session["count"].ToString()) + 1;
            }
        }
        catch
        {
            Session["count"] = 1;
        }
        da = null;
        dt = null;
    }

    protected void BtnBack_Click(object sender, ImageClickEventArgs e)
    {

        Response.Redirect("Cart.aspx");
    }

    public void order_mail(String sender, String pass, String tos, String subject, String message)
    {
        try
        {
            NetworkCredential loginInfo = new NetworkCredential();
            loginInfo = new NetworkCredential(sender, pass);
            MailMessage msg = new MailMessage();
            msg = new MailMessage();
            msg.From = new MailAddress(sender);
            msg.To.Add(new MailAddress(tos));
            msg.Subject = subject;
            msg.Body = message;
            msg.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = loginInfo;
            client.Send(msg);

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Email Not Sent !!!' + '" + ex.ToString() + "')</script>");

        }
    }

    protected void btnbook_Click(object sender, ImageClickEventArgs e)
    {
        String month, year;
        month = DateTime.Now.Date.Month.ToString();
        year = DateTime.Now.Date.Year.ToString();

        if (((txtn1.Text.Length) + (txtn2.Text.Length) + (txtn3.Text.Length) + (txtn4.Text.Length)) < 16)
        {
            lblerror.Text = "Enter proper 16 digit Card Number.";

        }
        else
        {
            if (Convert.ToInt32(Ddlyear.Text) == Convert.ToInt32(year))
            {
                if (Convert.ToInt32(Ddlmonth.Text) < Convert.ToInt32(month))
                {
                    lblerror.Text = "Your card is Expired.";
                }
                else
                {
                    lblerror.Text = "";
                }
            }
            else
            {
                lblerror.Text = "";
            }
        }
        if (lblerror.Text == "")
        {
            //code for save
            //String details = "";
            try
            {
                da = new SqlDataAdapter("select * from Cart where cid='" + Session["cid"].ToString() + "' ", cn);
                dt = new DataTable();
                da.Fill(dt);
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    int qty = Convert.ToInt16(dt.Rows[i]["qty"].ToString());
                    long price1 = Convert.ToInt64(dt.Rows[i]["Sell_Price"].ToString());
                    long tprice = qty * price1;
                
                    String pname = dt.Rows[i]["Name"].ToString();


                    try
                    {
                        cn.Open();
                    }
                    catch{
                        cn.Close();
                        cn.Open();
                    }
                    SqlCommand query = new SqlCommand("select saddress from cust_profile where cid = @cid",cn);
                    query.Parameters.AddWithValue("@cid", lblcid.Text);
                    SqlDataReader sdr = query.ExecuteReader();
                    sdr.Read();
                    String address = sdr[0].ToString();
                    

                    String str = "insert into [Order] values('" + lblorderid.Text + "','" + lblcid.Text + "','" + dt.Rows[i]["ProductId"].ToString() + "','" + pname + "','" + tprice + "','" + DateTime.Today.Date.ToShortDateString() + "','" + DateTime.Today.AddDays(1).ToShortDateString() + "','" + DdlMode.Text + "','" + txtn1.Text + txtn2.Text + txtn3.Text + txtn4.Text + "','" + Ddlmonth.Text + "','" + Ddlyear.Text + "','" + Session["LoginId"] + "','" + qty + "','"+address+"','open')";
                    
                    cmd = new SqlCommand(str, cn);
                    cmd.CommandType = CommandType.Text;
                    try
                    {
                        cn.Close();
                        cn.Open();
                    }
                    catch (Exception ex) { }
                    cmd.Connection = cn;
                    cmd.ExecuteNonQuery();

                    String totalqty = null;
                    SqlCommand s = new SqlCommand("select qty from products where productid='" + dt.Rows[i]["ProductId"].ToString() + "'", cn);
                    SqlDataReader sd = s.ExecuteReader();
                    sd.Read();
                    totalqty = sd[0].ToString();
                    int ans = Convert.ToInt32(totalqty) - Convert.ToInt32(qty);
                    str = "Update [Products] set Qty=" + ans + "  where ProductId='" + dt.Rows[i]["ProductId"].ToString() + "'";
                    cmd = new SqlCommand(str, cn);
                    cmd.CommandType = CommandType.Text;
                    try
                    {
                        cn.Close();
                        cn.Open();
                    }
                    catch (Exception ex) { }
                    cmd.Connection = cn;
                    cmd.ExecuteNonQuery();

                    
                    //email
                    
                    //details = details + "Order Id:" + lblorderid.Text + "<br/>";
                    //details = details + "Product Id:" + dt.Rows[i]["ProductId"].ToString() + "<br/>";
                    //details = details + "Product Name:" + pname + "<br/>";
                    //details = details + "Total Amount:" + tprice + "<br/>";
                    //details = details + "Order Date:" + DateTime.Today.Date + "<br/>";
                    //details = details + "Delivery Date:" + DateTime.Today.AddDays(3) + "<br/>";
                    //details = details + "Quantity: " + dt.Rows[i]["qty"].ToString() + "<br/>";

                    
                    try
                    {


                        str = "Delete from [Cart]  where Cid='" + Session["cid"].ToString() + "' and ProductId='" + dt.Rows[i]["ProductId"].ToString() + "'";
                        cmd = new SqlCommand(str, cn);
                        cmd.CommandType = CommandType.Text;
                        try
                        {
                            cn.Close();
                            cn.Open();
                        }
                        catch (Exception ex) { }
                        cmd.Connection = cn;
                        cmd.ExecuteNonQuery();

                       
                    }
                    catch (Exception ex) { }

                    //delete qty
                    //try
                    //{
                    //    String totalqty = null;

                    //    da1 = new SqlDataAdapter("select Qty from Products where ProductId='" + dt.Rows[i]["ProductId"].ToString() + "' ", cn);
                    //    dt1 = new DataTable();
                    //    da1.Fill(dt1);
                    //    if (dt1.Rows.Count > 0)
                    //    {
                    //        totalqty = dt1.Rows[0]["Qty"].ToString();
                    //    }
                    //    String qty1 = Session["qty"].ToString();
                    //    int ans = Convert.ToInt32(totalqty) - Convert.ToInt32(qty1);
                    //    str = "Update [Products] set Qty=" + ans + "  where ProductId='" + dt.Rows[i]["ProductId"].ToString() + "'";
                    //    cmd = new SqlCommand(str, cn);
                    //    cmd.CommandType = CommandType.Text;
                    //    try
                    //    {
                    //        cn.Close();
                    //        cn.Open();
                    //    }
                    //    catch (Exception ex) { }
                    //    cmd.Connection = cn;
                    //    cmd.ExecuteNonQuery();


                    //}
                    //catch (Exception ex)
                    //{ }
                }
//                order_mail("hairport2410@gmail.com", "kunalsachin2410", Session["LoginId"].ToString(), "Order Details", details);
                Response.Write("<script type=text/javascript>alert('Order Placed, For Details Check Your Mail Box') </script>");

            }
            catch (Exception ex)
            { }
            Response.Redirect("Invoice.aspx");
        }
    }
}
