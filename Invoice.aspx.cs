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
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;
public partial class Default2 : System.Web.UI.Page
{
    SqlDataAdapter da = new SqlDataAdapter();
    DataTable dt = new DataTable();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da1 = new SqlDataAdapter();
    DataTable dt1 = new DataTable();

    String id = "";
    String res = "";
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
            try
            {
                da=new SqlDataAdapter("select * from [Order] where Orderid='"+ Session["count"].ToString() +"'",cn);
                dt = new DataTable();
                da.Fill(dt);

da1=new SqlDataAdapter("select * from cust_Profile where cid='"+ Session["cid"].ToString() +"'",cn);
                dt1 = new DataTable();
                da1.Fill(dt1);

                if(dt.Rows.Count>0)
                {
                    
                res = res + "<html><body><center>";
                res = res + "<table border='1' cellpadding='3' cellspacing='5' color='black'>";
                res = res + "<tr>";
                res = res + "<td colspan='3' align='center' valign='middle'><font size='6'>HAIRPORT-INVOICE</font></td>";
                res = res + "</tr>";
                res = res + "<tr>";
                res = res + "<td width='530'>";
                res = res + "<font size='5'>Customer Name and Address</font><br /><br />";
                res = res + "<font size='4'>" + dt1.Rows[0]["fname"].ToString() + "</font><br />";
                res = res + dt1.Rows[0]["saddress"].ToString();
                res = res + "</td>";
                res = res + "<td align='center' width='200' valign='top'><font size='4'>Order Date<br />" + dt.Rows[0]["Booking_Date"].ToString() + "</font></td>";
                res = res + "<td align='center' width='270' valign='top'>Hair-Port, Ulhasnagar<br/><b>Note:<b/>Order Once Placed Can Not Be Cancelled</td>";
                res = res + "</tr>";
                res = res + "<tr>";
                res = res + "<td align='left' width='150' valign='top'><font size='4'>Order ID: " + dt.Rows[0]["Orderid"].ToString() + " </font></td>";
                res = res + "<td colspan='2'><font size='4'>Delivery Date: " + dt.Rows[0]["Delivery_Date"].ToString() + "</font></td>";
                res = res + "</tr>";
                res = res + "</table>";
                res = res + "<br />";

                res = res + "<table border='1' cellpadding='3' cellspacing='5' color='black'>";
                res = res + "<tr>";
                res = res + "<td width='500' align='left'><font size='5'>Item Description</font></td>";
                res = res + "<td width='150' align='center'><font size='5'>Quantity</font></td>";
                res = res + "<td width='160' align='center'><font size='5'>Price/Unit</font></td>";
                res = res + "<td width='190' align='center'><font size='5'>Total Amount</font></td>";
                res = res + "</tr>";
                res = res + "<tr>";
                res = res + "<td valign='top'>";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
    res = res + "<font size='4'>" + dt.Rows[i][3].ToString() + "<br />" + "</font>";
                }
                    res = res + "<br /><br /><br /></td>";

                res = res + "<td align='center' valign='top'><font size='4'>";
                    for (int i = 0; i < dt.Rows.Count; i++)
                {
                    res = res + "<font size='4'>" + dt.Rows[i][12].ToString() + "<br />" + "</font>";
                }
                    res = res + "</font></td>";

                res = res + "<td align='center' valign='top'><font size='4'>";
                    for (int i = 0; i < dt.Rows.Count; i++)
                {
                    res = res + "<font size='4'>" + (Convert.ToInt32(dt.Rows[i][4].ToString())/Convert.ToInt32(dt.Rows[i][12].ToString())) + "<br />" + "</font>";
                }
                    res = res + "</font></td>";

                res = res + "<td align='center' valign='top'><font size='4'>";
                       for (int i = 0; i < dt.Rows.Count; i++)
                {
                    res = res + "<font size='4'>" + dt.Rows[i][4].ToString() + "<br />" + "</font>";
                }
                    res = res + "</font></td>";
                res = res + "</tr>";

                res = res + "<tr>";
                res = res + "<td colspan='3' align='right'><font size='5'>Grand Total</font></td>";
                res = res + "<td><font size='4'>" + "Rs." + Session["finalamount"].ToString() + "/-" + "</font></td>";
                res = res + "</tr></table><br />";

                res = res + "</center></body></html>";
                }
                lblmsg.Text = res;
                order_mail("hairport2410@gmail.com", "kunalsachin2410", Session["LoginId"].ToString(), "Order Details", res);
                Response.Write("<script type=text/javascript>alert('Order Placed, For Details Check Your Mail Box') </script>");

            }
            catch (Exception ex) { }

        }
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
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        
    }
    protected void Unnamed1_Click1(object sender, EventArgs e)
    {

    }
}
