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

public partial class Default2 : System.Web.UI.Page
{
    SqlDataAdapter da = new SqlDataAdapter();
    DataTable dt = new DataTable();
    SqlCommand cmd = new SqlCommand();
    int count = 0;
    String i;

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

            clearAll();

            disable();

            btnNew.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnModify.Enabled = false;
            btnRemove.Enabled = false;

            getdata();
            if (dt.Rows.Count > 0)
            {
                gridfill();
            }

        }
        else
        {
        }
    }

    protected void getdata()
    {
        da = new SqlDataAdapter("select * from Products", cn);
        dt = new DataTable();
        da.Fill(dt);
    }

    private void autogenerate()
    {
        int a = 0;
        getdata();
        Session["count"] = dt.Rows.Count;
        if (a.Equals(Session["count"]))
        {
            Session["count"] = 1;
        }
        else
        {
            Session["count"] = (int)Session["count"] + 1;
        }

        da = null;
        dt = null;
    }

    public void clearAll()
    {
        lblid.Text = "";
        txtname.Text = "";
        txtcost.Text = "";
        DdlBrand.SelectedIndex = 0;
        ddlcategory.SelectedIndex = 0;
        txtqty.Text = "";
        txtsell.Text = "";
        txtsummary.Text = "";
        Image1.ImageUrl = "~/images/Products/NAvail.jpg";
    }
    public void disable()
    {
        txtname.Enabled = false;
        txtcost.Enabled = false;
        DdlBrand.Enabled = false;
        txtqty.Enabled = false;
        txtsell.Enabled = false;
        txtsummary.Enabled = false;
        ddlcategory.Enabled = false;
    }
    public void enable()
    {
        txtname.Enabled = true;
        txtcost.Enabled = true;
        DdlBrand.Enabled = true;
        txtqty.Enabled = true;
        txtsell.Enabled = true;
        txtsummary.Enabled = true;
        ddlcategory.Enabled = true;
    }
    protected void display()
    {
        lblid.Text = dt.Rows[0]["ProductId"].ToString();
        txtname.Text = dt.Rows[0]["Name"].ToString();
        DdlBrand.Text = dt.Rows[0]["Brand"].ToString();
        txtsummary.Text = dt.Rows[0]["Summary"].ToString();
        txtcost.Text = dt.Rows[0]["Cost"].ToString();
        txtsell.Text = dt.Rows[0]["Sell"].ToString();
        txtqty.Text = dt.Rows[0]["Qty"].ToString();
        ddlcategory.Text = dt.Rows[0]["cat"].ToString();
        //image
        string image;
        image = FileUpload1.FileName;
        Image1.ImageUrl = "~/images/" + lblid.Text + ".jpg";
    }

    protected void btnNew_Click(object sender, ImageClickEventArgs e)
    {
        enable();
        Session["save_code"] = "true";
        autogenerate();
        lblid.Text = "P" + Session["count"].ToString();
        btnNew.Enabled = false;
        btnSave.Enabled = true;
        btnCancel.Enabled = true;
        btnModify.Enabled = false;
        btnRemove.Enabled = false;
    }

    protected void btnModify_Click(object sender, ImageClickEventArgs e)
    {
        enable();
        Session["save_code"] = "false";

        btnNew.Enabled = false;
        btnSave.Enabled = true;
        btnCancel.Enabled = true;
        btnModify.Enabled = false;
        btnRemove.Enabled = false;
    }

    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        disable();
        clearAll();
        Session["save_code"] = "";
        btnNew.Enabled = true;
        btnSave.Enabled = false;
        btnCancel.Enabled = false;
        btnModify.Enabled = false;
        btnRemove.Enabled = false;
        
    }

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (Page.IsValid == true)
        {
            String t = "true";
            //image


            if (t.Equals(Session["save_code"].ToString()))
            {
                string image;
                image = FileUpload1.FileName;
                FileUpload1.SaveAs(Server.MapPath("~") + "/images/" + lblid.Text + ".jpg");
                if (FileUpload1.HasFile)
                {
                    try
                    {
                        //a_pic.ImageUrl = FileUpload1.PostedFile.FileName
                        Image1.ImageUrl = "~/images/" + lblid.Text + ".jpg";
                    }

                    catch (Exception ex) { }

                }
                //code for new record
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = "insert into Products values(" + (int)Session["count"] + ",'" + "P" + Session["count"].ToString() + "','" + txtname.Text + "','" + DdlBrand.Text + "','" + txtsummary.Text + "','" + lblid.Text + "'," + txtcost.Text + "," + txtsell.Text + "," + txtqty.Text + ",'"+ ddlcategory.Text +"')";
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Saved Successfully') </script>");
                cmd = null;

                clearAll();
                disable();
                gridfill();
                btnNew.Enabled = true;
                btnModify.Enabled = false;
                btnSave.Enabled = false;
                btnRemove.Enabled = false;
                btnCancel.Enabled = false;
            }
            else
            {
                string image;
                image = FileUpload1.FileName;
                FileUpload1.SaveAs(Server.MapPath("~") + "/images/" + lblid.Text + ".jpg");
                if (FileUpload1.HasFile)
                {
                    try
                    {
                        //a_pic.ImageUrl = FileUpload1.PostedFile.FileName
                        Image1.ImageUrl = "~/images/" + lblid.Text + ".jpg";
                    }

                    catch (Exception ex) { }

                }
                //code for modify i.e. update.
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = "update Products set Name='" + txtname.Text + "',cat='"+ ddlcategory.Text +"',Brand='" + DdlBrand.Text + "',Summary='" + txtsummary.Text + "',Picture='" + lblid.Text + "',Cost=" + txtcost.Text + ",Sell=" + txtsell.Text + ",Qty=" + txtqty.Text + " where ProductId='" + lblid.Text + "' ";
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Updated Successfully') </script>");
                cmd = null;

                clearAll();
                disable();
                gridfill();
                btnNew.Enabled = true;
                btnModify.Enabled = false;
                btnSave.Enabled = false;
                btnRemove.Enabled = false;
                btnCancel.Enabled = false;
                
            }
            Response.Redirect("AdminProducts.aspx");
        }
    }

    protected void btnRemove_Click(object sender, ImageClickEventArgs e)
    {
        if (lblid.Text != "")
        {
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = "Delete from Products where ProductId='" + lblid.Text + "' ";
            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('Removed Successfully') </script>");
            cmd = null;

            clearAll();
            disable();

            btnNew.Enabled = true;
            btnModify.Enabled = false;
            btnSave.Enabled = false;
            btnRemove.Enabled = false;
            btnCancel.Enabled = false;
        }
    }
    public void gridfill()
    {
        String sqlq = "select * from Products";
        da = new SqlDataAdapter(sqlq, cn);
        dt = new DataTable();
        da.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridView1.SelectedRow;
        i = GridView1.SelectedRow.Cells[2].Text;

        try
        {
            da = new SqlDataAdapter("select * from Products where ProductId='" + i + "' ", cn);
            dt = new DataTable();
            da.Fill(dt);
            display();
            btnNew.Enabled = false;
            btnModify.Enabled = true;
            btnSave.Enabled = false;
            btnRemove.Enabled = true;
            btnCancel.Enabled = true;
        }
        catch (Exception ex)
        {

        }
    }

    public static Boolean IsNumeric(string stringToTest)
    {
        int result;
        return int.TryParse(stringToTest, out result);
    }
    protected void CVCost_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if ((IsNumeric(txtcost.Text)) == false)
        {
            args.IsValid = false;
        }
        else
        {
            //  args.IsValid = true;
        }
    }

    protected void CVSell_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if ((IsNumeric(txtsell.Text)) == false)
        {
            args.IsValid = false;
        }
        else
        {
            // args.IsValid = true;
        }
    }
    protected void cvqty_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if ((IsNumeric(txtsell.Text)) == false)
        {
            args.IsValid = false;
        }
        else
        {
            // args.IsValid = true;
        }
    }
}
