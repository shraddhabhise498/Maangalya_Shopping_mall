using Instamojo.NET.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BuyingRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        String name = Request.Form["fname"];
        String lname = Request.Form["lname"];
        String email = Request.Form["email"];
        String password = Request.Form["password"];

        string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "Insert into Man_Account values('" + name + "','" + lname + "','" + email + "','" + password + "')";
        cmd.ExecuteNonQuery();


        String home = Request.Form["home"];
        String address = Request.Form["address"];
        String zipcode = Request.Form["zipcode"];
        String country = Request.Form["country"];
        String city = Request.Form["city"];
        String state = Request.Form["state"];
        String msg = "-";

        String mobile=Request.Form["Phone"];

        SqlCommand cmd2 = new SqlCommand("Select MAX(person_id) from Man_Account");
        cmd2.Connection = con;
        int id = Convert.ToInt32(cmd2.ExecuteScalar().ToString());





        SqlCommand cmd1 = new SqlCommand();
        cmd1.Connection = con;
        cmd1.CommandText = "Insert into tblProfile values('" + id + "','" + name + "','" + lname + "','" + mobile + "','" + email + "','" + msg + "','" + home + "','" + address + "','" + zipcode + "','" + country + "','" + city + "','" + state + "')";
        cmd1.ExecuteNonQuery();
        string Username = "rahulpawar";
        string pass = "Rahul@123";
        string APIKey = "ROYALS";
        WebClient client = new WebClient();
        String Message = "You have Successfully Registered with Maangalya Shopping Mall";
        string baseurl = "http://www.smssigma.com/API/WebSMS/Http/v1.0a/index.php?username=" + Username + "&password=" + pass + "&sender=" + APIKey + "&to=" + mobile + "&message='" + Message + "'&reqid=1&format={json|text}&route_id=7&msgtype=unicode";
        Stream data = client.OpenRead(baseurl);

        StreamReader reader = new StreamReader(data);
        string ResponseID = reader.ReadToEnd();
        data.Close();
        reader.Close();


        ModalPopupExtender1.Show();

        decimal amount = 0;
        decimal amount1 = 0;
        String Mycurrentsession = Session["SES"].ToString();
        SqlDataAdapter da2 = new SqlDataAdapter("Select * from tblCart where Sessionid='" + Mycurrentsession + "'", con);
        DataTable dt2 = new DataTable();
        da2.Fill(dt2);
        int length = dt2.Rows.Count;
        for (int i = 0; i < length; i++)

        {

            amount = Convert.ToDecimal(dt2.Rows[i][6].ToString());
            amount1 += amount;
        }

        Application["MobileNo"] = mobile;
        Application["Email"] = email;
        Application["FullName"] = name+" "+lname;
        Application["Amount"] = amount1;

        string str = amount1.ToString();


        Response.Redirect("~/Payment1.aspx");
    }
}