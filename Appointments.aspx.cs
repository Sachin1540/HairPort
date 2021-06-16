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
using System.Drawing;
using System.IO;

using System.Data.Sql;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
public partial class Default2 : System.Web.UI.Page
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
            Response.Write("<script>alert(" + ex.ToString() + ")</script>");

        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(Page.IsPostBack == true))
        {
            connection();
            try
            {
                da = new SqlDataAdapter("select * from Cust_profile where cid='" + Session["cid"] + "'", cn);
                dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    
                    txtname.Text = dt.Rows[0]["fname"].ToString();
                    txtemail.Text = Session["LoginId"].ToString();
                   
                   
                }
                else
                {
                    txtname.Text = "";
                    txtemail.Text = "";
                }

                //fillemp
                da = new SqlDataAdapter("select * from Emp", cn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    ddlemp.Items.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ddlemp.Items.Add(dt.Rows[i]["Name"].ToString());
                    }
                }


                //fillservices
                da = new SqlDataAdapter("select * from Services", cn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    ddlservice.Items.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ddlservice.Items.Add(dt.Rows[i]["Name"].ToString());
                    }
                }

                //filltime
                ddltime.Items.Clear();
                for (int i = 9; i <= 22; i++)
                {
                    ddltime.Items.Add(i + ":00");
                }

                da = new SqlDataAdapter("select cost from Services where Name='" + ddlservice.Text + "'", cn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtcost.Text = dt.Rows[0][0].ToString();
                }

                //autogenerate
                autogenerate();
                lblid.Text = "A" + Session["count"].ToString();


            }
            catch (Exception ex) { }
        }
        else
        { }

    }
    protected void getdata()
    {
        da = new SqlDataAdapter("select * from Appointments", cn);
        dt = new DataTable();
        da.Fill(dt);
    }

    private void autogenerate()
    {
        try
        {
            int a = 0;
            da = new SqlDataAdapter("select max(srno) from Appointments", cn);
            dt = new DataTable();
            da.Fill(dt);
            int x = Convert.ToInt32(dt.Rows[0][0].ToString());
            x = x + 1;
            Session["count"] = x;
            

            da = null;
            dt = null;

        }
        catch
        {
            Session["count"] = 1;
        }
            }

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                cmd = new SqlCommand("select * from Appointments where EmailId="+ txtemail.Text);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {

                    //for sending mail
                    String v = "";
                    v = "<b>Hello " + txtname.Text + ",</b><br><br>Your Appointment has been booked.<br><br>Detail of Appointment as follows:<br><br><b>Barber Name : " + ddlemp.Text + "<br><br>Date: " + Calendar1.SelectedDate.ToShortDateString() + "<br><br>Final Approx Cost:" + lblTotal.Text + "<br><br>Thanks for booking an appointment with HairPort.<br><br>Regards,<br>Hairport.</b>";
                    verification_code("hairport2410@gmail.com", "kunalsachin2410", txtemail.Text, "Appointment Status From HairPort", v);
                }
                else
                {
                    Response.Write("<script>alert('Appointment already booked at this time.Please select different time')</script>");

                }
            }
        }
        catch
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
            Response.Write("<script>alert('Check your Email Account For Appointment Status')</script>");
            
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Email Not Sent !!!' + '" + ex.ToString() + "')</script>");

        }
    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                connection();
                //check for same slot
                da = new SqlDataAdapter("select * from Appointments where Emp='"+ ddlemp.Text +"' and ADate='"+ Calendar1.SelectedDate.ToShortDateString() +"' and Time='"+ ddltime.Text +"'", cn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //show error
                    Response.Write("<script>alert('Appointment On selected Date/Time is already booked') </script>");
                }
                else
                {
                    cmd = new SqlCommand("insert into Appointments values(" + (int)Session["count"] + ",'" + "A" + Session["count"].ToString() + "','" + txtname.Text + "','" + txtemail.Text + "','" + txtno.Text + "','" + ddlemp.Text + "','" + Calendar1.SelectedDate.ToShortDateString() + "','" + ddlservice.Text + "','" + txtcost.Text + "','" + ddltime.Text + "')", cn);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Saved Successfully') </script>");
                }

                da = new SqlDataAdapter("select sum(cast(SCost as numeric(10,0))) from Appointments where Id='" + lblid.Text + "'", cn);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lblTotal.Text = dt.Rows[0][0].ToString();
                }


            }
        }
        catch
        {

        }
    }
    protected void ddlservice_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            da=new SqlDataAdapter("select cost from Services where Name='"+ ddlservice.Text +"'",cn);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtcost.Text = dt.Rows[0][0].ToString();
            }
        }
        catch
        {
        }
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {

    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.Date.CompareTo(DateTime.Today) < 0)
        {
            e.Day.IsSelectable = false;
        }
    }
}
