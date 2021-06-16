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
    bool chk = true;
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
    }

    protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        if (txtmsg.Text != "")
        {
            connection();

            if (txtto.Text != "")
            {
                //email
                verification_code("hairport2410@gmail.com", "kunalsachin2410", txtto.Text, txtsubject.Text, txtmsg.Text);
                lblError.Text = "";

            }
            else
            {
                lblError.Text = "Enter Email-Id";
            }



        }
        else
            lblError.Text = "Enter Message";
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
            Response.Write("<script>alert('Email Sent')</script>");
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Email Not Sent !!!')</script>");
        }
    }

    protected void btnSubmit_Click1(object sender, ImageClickEventArgs e)
    {
        btnSubmit_Click(sender, e);
    }
}
