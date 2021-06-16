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
                    Ddltitle.Text = dt.Rows[0]["title"].ToString();
                    txtfname.Text = dt.Rows[0]["fname"].ToString();
                    txtlname.Text = dt.Rows[0]["lname"].ToString();
                    txtmname.Text = dt.Rows[0]["mname"].ToString();
                    DdlGender.Text = dt.Rows[0]["gender"].ToString();
                    txtaddress.Text = dt.Rows[0]["address"].ToString();
                    txtpincode.Text = dt.Rows[0]["pincode"].ToString();
                    txtshipingadd.Text = dt.Rows[0]["saddress"].ToString();
                    Session["fname"] = txtfname.Text;
                    Session["save"] = "false";
                }
                else
                {
                    Ddltitle.Text = "";
                    txtfname.Text = "";
                    txtlname.Text = "";
                    txtmname.Text = "";
                    DdlGender.Text = "";
                    txtaddress.Text = "";
                    txtpincode.Text = "";
                    txtshipingadd.Text = "";
                    Session["save"] = "true";
                }
            }
            catch (Exception ex) { }
        }
        else
        { }
    }
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (Page.IsValid == true)
        {
            try
            {
                da = new SqlDataAdapter("select * from Cust_profile where cid='" + Session["cid"] + "'", cn);
                dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Session["save"] = "false";
                }
                else
                {
                    Session["save"] = "true";
                }
            }
            catch (Exception xe)
            { }


            string tmp = "true";
            if (tmp.Equals(Session["save"]))
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = "insert into Cust_profile values('" + Session["cid"].ToString() + "','" + Ddltitle.Text + "','" + txtfname.Text + "','" + txtlname.Text + "','" + txtmname.Text + "','" + DdlGender.Text + "','" + txtaddress.Text + "','" + txtpincode.Text + "','" + txtshipingadd.Text + "')";
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Saved Successfully') </script>");
                cmd = null;
            }
            else
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = "update Cust_profile set title='" + Ddltitle.Text + "',fname='" + txtfname.Text + "',lname='" + txtlname.Text + "',mname='" + txtmname.Text + "',gender='" + DdlGender.Text + "',address='" + txtaddress.Text + "',pincode='" + txtpincode.Text + "',saddress='" + txtshipingadd.Text + "' where cid=" + Session["cid"].ToString() + " ";
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Updated Successfully') </script>");
                cmd = null;
            }
        }
    }

    //checkbox

    protected void ChkAddress_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkAddress.Checked == true)
        {
            txtshipingadd.Text = txtaddress.Text;
        }
        else
        {
            txtshipingadd.Text = "";
        }
    }
    protected void txtaddress_TextChanged(object sender, EventArgs e)
    {
        if (ChkAddress.Checked == true)
        {
            txtshipingadd.Text = txtaddress.Text;
        }
        else
        {

        }
    }
    protected void btnReset_Click(object sender, ImageClickEventArgs e)
    {
        Ddltitle.SelectedIndex = 0;
        txtfname.Text = "";
        txtmname.Text = "";
        txtlname.Text = "";
        DdlGender.SelectedIndex = 0;
        txtaddress.Text = "";
        txtpincode.Text = "";
        txtshipingadd.Text = "";
        ChkAddress.Checked = false;
    }
}
