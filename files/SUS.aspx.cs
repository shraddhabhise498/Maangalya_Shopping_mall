using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class SUS : System.Web.UI.Page
{
     
    protected void Page_Load(object sender, EventArgs e)
    {
         String size = null;
        //Datetime dt = new Datetime.Now;

        //DateTime.Now.ToString("dd/MM/yyyy");
        try
        {

            string[] merc_hash_vars_seq;
            string merc_hash_string = string.Empty;
            string merc_hash = string.Empty;
            string order_id = string.Empty;
            string hash_seq = "key|txnid|amount|productinfo|firstname|email|udf1|udf2|udf3|udf4|udf5|udf6|udf7|udf8|udf9|udf10";

            

                merc_hash_vars_seq = hash_seq.Split('|');
                Array.Reverse(merc_hash_vars_seq);
                merc_hash_string = ConfigurationManager.AppSettings["SALT"] + "|" + Request.Form["status"];


                foreach (string merc_hash_var in merc_hash_vars_seq)
                {
                    merc_hash_string += "|";
                    merc_hash_string = merc_hash_string + (Request.Form[merc_hash_var] != null ? Request.Form[merc_hash_var] : "");

                }
                merc_hash = Generatehash512(merc_hash_string).ToLower();



               
                    //if hash value match for before transaction data and after transaction data
                    //that means success full transaction  , see more in response
                    order_id = Request.Form["txnid"];


                     string email = Application["Email"].ToString();
            String Mycurrentsession = Session["SES"].ToString();
                    decimal amount = 0;
                    decimal amount1 = 0;
                    int productid = 0;
                    int quantitiy = 0;
                    decimal rate = 0;
                    decimal finalprice = 0;
                    
            String productname = null;
                    Label1.Text = "Thank You Your Payment Successfull";

                    string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    SqlDataAdapter da2 = new SqlDataAdapter("Select * from tblCart where Sessionid='" + Mycurrentsession + "'", con);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    int length = dt2.Rows.Count;
                    for (int i = 0; i < length; i++)

                    {
                        productname = dt2.Rows[i][2].ToString();
                        productid = Convert.ToInt32(dt2.Rows[i][1].ToString());
                        amount = Convert.ToDecimal(dt2.Rows[i][6].ToString());
                        size = dt2.Rows[i][3].ToString();
                        quantitiy = Convert.ToInt32(dt2.Rows[i][4].ToString());
                        rate = Convert.ToDecimal(dt2.Rows[i][5].ToString());
                        finalprice = Convert.ToDecimal(dt2.Rows[i][6].ToString());
                              
                        
                        SqlCommand cmd = new SqlCommand();
                DateTime time = DateTime.Now;
                cmd.CommandText = "Insert into tblFinal values('" + email + "','" + productid + "','" + productname + "','" + size + "','" + quantitiy + "','" + rate + "','" + finalprice + "','"+time+"') ";
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();

                //'"+ dt + "'


            }

            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandText = ("Delete from tblCart WHERE sessionid=  '" + Mycurrentsession + "'");
            cmd2.Connection = con;
            cmd2.ExecuteNonQuery();



        }


        catch (Exception ex)
        {
            Response.Write("<span style='color:red'>" + ex.Message + "</span>");

        }



        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "15;url=Default.aspx";
        this.Page.Controls.Add(meta);



    }





    public string Generatehash512(string text)
    {

        byte[] message = Encoding.UTF8.GetBytes(text);

        UnicodeEncoding UE = new UnicodeEncoding();
        byte[] hashValue;
        SHA512Managed hashString = new SHA512Managed();
        string hex = "";
        hashValue = hashString.ComputeHash(message);
        foreach (byte x in hashValue)
        {
            hex += String.Format("{0:x2}", x);
        }
        return hex;

    }
}

