using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Dashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getData();
        }
        string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        con.Open();
        SqlCommand cmd = new SqlCommand("Select count(*) from tblFiles1", con);
        int count =Convert.ToInt32( cmd.ExecuteScalar().ToString());
        Label1.Text = count.ToString();

        SqlCommand cmd1 = new SqlCommand("Select count(*) from tbl_products", con);
        int count1 = Convert.ToInt32(cmd1.ExecuteScalar().ToString());
        Label2.Text = count1.ToString();


    }

    public void getData()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);




        con.Open();

        SqlDataAdapter da = new SqlDataAdapter("select email,Productid,Productname,size,Quantiy,Rate,Price,date from tblFinal", con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        grdView.DataSource = dt;
        grdView.DataBind();
    }
}