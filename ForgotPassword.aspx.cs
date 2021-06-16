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
    String sq, sa, email;
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
            connection();
        }

    }

    protected void btnSendMail_Click(object sender, ImageClickEventArgs e)
    {
        if (Page.IsValid == true)
        {
            try
            {

                email = txtEmailID.Text;




                da = new SqlDataAdapter("select * from Login where Email='" + txtEmailID.Text + "'", cn);
                dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Session["Email"] = dt.Rows[0]["Email"].ToString();
                    Session["epwd"] = dt.Rows[0]["Password"].ToString();
                    if (txtEmailID.Text.Equals(Session["Email"].ToString()))
                    {
                        lblEsend.Text = "";
                        //Send password
                        verification_code("hairport2410@gmail.com", "kunalsachin2410", txtEmailID.Text, "Password Recovery", "Your Password: " + Session["epwd"].ToString());
                        Response.Write("<script>alert('Check your Email Account For Password')</script>");
                        Response.Redirect("Login.aspx");
                    }
                    else
                        lblEsend.Text = "Invalid EmailID";

                }
            }
            catch (Exception xe)
            { }

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
            Response.Write("<script type=text/javascript>alert('Email Sent !!!')</script>");
        }
        catch (Exception ex)
        {
            Response.Write("<script type=text/javascript>alert('Email Not Sent !!!')</script>");
        }
    }

    protected void btnSendSec_Question_Click(object sender, ImageClickEventArgs e)
    {
        if (Page.IsValid == true)
        {
            try
            {
                sq = DdlSecurityQuestion.Text;
                sa = txtAnswer.Text;
                email = txtfemail.Text;




                da = new SqlDataAdapter("select * from Login where Email='" + txtfemail.Text + "'", cn);
                dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Session["Email"] = dt.Rows[0]["Email"].ToString();
                    Session["SecQ"] = dt.Rows[0]["sq"].ToString();
                    Session["SecA"] = dt.Rows[0]["Sa"].ToString();
                }
                else
                {

                }
                if (txtfemail.Text.Equals(Session["Email"].ToString()))
                {
                    lblfemail.Text = "";

                    if (sq.Equals(Session["SecQ"].ToString()) && (sa.Equals(Session["SecA"].ToString())))
                    {
                        lblfsend.Text = "";
                        String passwd = dt.Rows[0]["Password"].ToString();

                        //Passwd
                        Response.Write("<script type=text/javascript>alert(" + passwd + ") </script>");
                    }
                    else
                        lblfsend.Text = "Please Check Your Security Question and Answer";
                }
                else
                {
                    lblfemail.Text = "Enter Correct Email ID";
                }



            }
            catch (Exception xe)
            { }

        }

    }

}
