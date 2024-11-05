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
        string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        con.Open();

        SqlDataAdapter cmd = new SqlDataAdapter("select * from tblFinal", con);

        DataTable dt = new DataTable();

        cmd.Fill(dt);

        orders.DataSource = dt;
        orders.DataBind();
    }

    protected void orders_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "lnkbtnEdit")
        {
            Session["Email"] = e.CommandArgument.ToString();

            Response.Redirect("order_details.aspx");
        }
    }
}