﻿using System;
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
    String pwd, passwd;
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
        lblerror.Text = "";
        if (!(Page.IsPostBack == true))
        {
            connection();
            try
            {
                da = new SqlDataAdapter("select Password from Login where Email='" + Session["LoginId"] + "'", cn);
                dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Session["pwd"] = dt.Rows[0]["Password"].ToString();
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
    protected void ImgChangePass_Click(object sender, ImageClickEventArgs e)
    {
        if (Page.IsValid == true)
        {
            passwd = txtOldPass.Text;
            if (passwd.Equals(Session["pwd"].ToString()))
            {
                lblerror.Text = "";
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = "update Login set Password='" + txtNewPass.Text + "' where Email='" + Session["LoginId"] + "'";
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Updated Successfully') </script>");
                Server.Transfer("Login.aspx");
                cmd = null;

            }
            else
            {
                lblerror.Text = "Old Password Does Not Match. Please Enter It Again.";
                txtOldPass.Text = "";
                txtOldPass.Focus();
            }

        }
    }
    protected void CVPass_ServerValidate(object source, ServerValidateEventArgs args)
    {
        string str = txtNewPass.Text;
        if (str.Length < 6)
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }
}
