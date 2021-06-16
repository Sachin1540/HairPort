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
    String str;
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
            Response.Write("<script>alert(" + ex.ToString() + ")</script>");

        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(Page.IsPostBack == true))
        {

            rdbVisit.SelectedIndex = 0;
            rdbRatings.SelectedIndex = 4;
        }
        else
        {
            //rdbVisit.SelectedIndex = 0;
            //rdbRatings.SelectedIndex = 4;
        }
    }
    protected void rdbVisit_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void rdbRatings_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        String cid, email;
        cid = Session["cid"].ToString();
        email = Session["LoginId"].ToString();
        if ((Page.IsValid == true) && (cid != "") && (email != ""))
        {
            str = "Email: " + email + "<br>";
            str = str + "Visit : " + rdbVisit.SelectedItem.Value.ToString() + "<br>";
            str = str + "Ratings : " + rdbRatings.SelectedItem.Value.ToString() + "<br>";
            str = str + "Improvement : " + txtimprove.Text + "<br>";
            str = str + "Description : " + txtmore.Text + "<br>";
            verification_code("hairport2410@gmail.com", "kunalsachin2410", "hairport2410@gmail.com", "Feedback", str);

            Response.Write("<script>alert('Submitted Successfully') </script>");


            rdbVisit.SelectedIndex = 0;
            rdbRatings.SelectedIndex = 4;
            txtimprove.Text = "";
            txtmore.Text = "";
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
            Response.Write("<script>alert('Email Not Sent !!!')</script>");
        }
    }

}
