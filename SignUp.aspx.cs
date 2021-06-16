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
    String Code = "";
    SqlCommand cmd = new SqlCommand();
    int count;

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
        }
        else
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
            Response.Write("<script>alert('Check your Email Account For Verification Code')</script>");
            Response.Redirect("VerifyAccount.aspx");
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Email Not Sent !!!' + '" + ex.ToString() + "')</script>");

        }
    }


    protected void btnRegister_Click(object sender, ImageClickEventArgs e)
    {
        da = new SqlDataAdapter("select Email from Login where Email='" + txtemail.Text + "'", cn);
        dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            lblemail.Text = "Email Id already exist.";
        }
        else
        {
            if (Page.IsValid == true)
            {
                lblemail.Text = "";
                String str = "";
                str = txtemail.Text;
                Code = str.Substring(1, 3);
                str = txtans.Text;
                Code = Code + str.Substring(1, 2);
                str = txtpassword.Text;
                Code = Code + str.Substring(1, 3);

                Session["SignUpEmail"] = txtemail.Text;
                Session["SignUpPass"] = txtpassword.Text;
                Session["SignUpSeqQ"] = DdlQuestion.Text;
                Session["SignUpSeqA"] = txtans.Text;
                Session["Sec_Code"] = Code;

                String VerificationCode = "Congratulations Your account has been created...<br/>Email:" + Session["SignUpEmail"].ToString();
                VerificationCode = VerificationCode + "<br />Your Verification Code is " + Code;


                verification_code("hairport2410@gmail.com", "kunalsachin2410", txtemail.Text, "Verification Code", VerificationCode);
                //                 autogenerate();
                //cmd = new SqlCommand();
                //cmd.CommandType = CommandType.Text;
                //cn.Open();
                //cmd.Connection = cn;
                //cmd.CommandText = "insert into Login values('" + Session["SignUpEmail"].ToString() + "','" + Session["SignUpPass"].ToString() + "','" + Session["SignUpSeqQ"].ToString() + "','" + Session["SignUpSeqA"].ToString() + "','" + code + "')";
                //cmd.ExecuteNonQuery();
                //Response.Write("<script>alert('Account Successfully Created') </script>");
                //cmd = null;
                //txtemail.Text = "";
                txtans.Text = "";
                DdlQuestion.SelectedIndex = 0;
                Response.Redirect("VerifyAccount.aspx");
            }
        }
    }
    protected void getdata()
    {
        da = new SqlDataAdapter("select * from Login", cn);
        dt = new DataTable();
        da.Fill(dt);
    }


    
    protected void btnreset_Click(object sender, ImageClickEventArgs e)
    {
        txtemail.Text = "";
        txtpassword.Text = "";
        txtretypepassword.Text = "";
        txtans.Text = "";
        DdlQuestion.SelectedIndex = 0;
    }

    }
