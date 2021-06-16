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
using System.Net;
using System.Net.Mail;
public partial class Default2 : System.Web.UI.Page
{


    SqlDataAdapter da = new SqlDataAdapter();
    DataTable dt = new DataTable();
    SqlCommand cmd = new SqlCommand();


    int i;

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
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        connection();
        GridViewRow row = GridView1.SelectedRow;
        i = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
        try
        {
            da = new SqlDataAdapter("select productid[ID],productname[Name],qty[Quantity],Total_Amount[Total] from [Order] where orderid=" + i + " ", cn);
            dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Label1.Text = "Details Of Order ID: "+i;
                Session["Orderid"] = i;
                Button1.Visible = true;
                GridView2.DataSource = dt;
                GridView2.DataBind();


            }
        }
        catch (Exception ex)
        {
        }

    }
    public void verification_code(String sender, String pass, String tos, String subject, String message)
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
    protected void Button1_Click(object sender, EventArgs e)
    {

        try
        {
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn; connection();
            cmd.CommandText = "update [Order] set [ordstatus] = 'done' where [orderid] = " + (int)Session["Orderid"] + "";
            cmd.ExecuteNonQuery();
            cn.Close();
            connection();
            SqlCommand s=new SqlCommand("select email from [Order] where orderid=" + (int)Session["Orderid"] + "",cn);
            SqlDataReader sdr=s.ExecuteReader();
            sdr.Read();
            String email=sdr[0].ToString();
            String msg = "Your Order Is Out For Delivery <br/>Order ID:" + Session["Orderid"];
            verification_code("hairport2410@gmail.com", "kunalsachin2410", email, "Delivery Details", msg);
            Server.Transfer("OrderList.aspx");
        }
        catch { }
    }
}
