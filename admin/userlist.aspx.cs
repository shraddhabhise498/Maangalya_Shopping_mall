using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_userlist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getData();
        }
    }
    public void getData()
    {
         
        String name = Request.Form["FName"];
        String Lname = Request.Form["LName"];
        String Email = Request.Form["Email"];
         
        string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        con.Open();


         

        SqlDataAdapter da = new SqlDataAdapter("select person_id,FirstName,LastName,Email from Man_Account", con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        grdView.DataSource = dt;
        grdView.DataBind();
    }
    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        /* This condition work when click on edit button */
      
        /* This condition work when click on delete button */
        if (e.CommandName == "lnkbtnDelete")
        {
            int id = int.Parse(e.CommandArgument.ToString());
            string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            var name = this.Request.Form["lblID"];

           // String name = Request.Form["FName"];
            String Lname = Request.Form["LName"];
            String Email = Request.Form["Email"];
            String Password = Request.Form["Password"];
            String Password1 = Request.Form["password1"];
            String s = Request.Form["gender"];
            String s1 = Request.Form["gender1"];
            String s2 = Request.Form["gender2"];

            String s3 = Request.Form["gender3"];
            String s4 = Request.Form["gender4"];
            String s5 = Request.Form["gender5"];
            String s6 = Request.Form["gender6"];
            String s7 = Request.Form["gender7"];
        




            SqlCommand cmd = new SqlCommand("delete from Man_Account where Person_id='" + id + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            getData(); /* Reload gridview */
        }
    }
}