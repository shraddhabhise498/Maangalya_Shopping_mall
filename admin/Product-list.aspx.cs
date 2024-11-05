using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class admin_Product_list : System.Web.UI.Page
{
    public string id12;


    protected void Page_Load(object sender, EventArgs e)
    {


        string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        con.Open();
        String cat = "Mens Wear";

        SqlDataAdapter da9 = new SqlDataAdapter("Select * from tbl_products where Cat_Name='" + cat + "'", con);
        DataTable dt9 = new DataTable();
        da9.Fill(dt9);
        int length9 = dt9.Rows.Count;
        if (dt9.Rows.Count > 0)
        {

            for (int i = 0; i < length9; i++)
            {
                if (i == 0)
                {
                    String firsturl = dt9.Rows[i][11].ToString();
                    String secondurl = dt9.Rows[i][12].ToString();
                    id12 = dt9.Rows[i][0].ToString();

                    string physicalPath = Convert.ToString(firsturl);
                    string imagesPhysicalPath = Server.MapPath("~/Files/");

                    if (physicalPath.StartsWith(imagesPhysicalPath, StringComparison.OrdinalIgnoreCase))
                    {
                        string relativePath = physicalPath.Substring(imagesPhysicalPath.Length);

                        Image1.ImageUrl = "~/Files/" + relativePath.Replace('\\', '/');
                        Label1.Text = dt9.Rows[i][1].ToString();
                        Label2.Text = dt9.Rows[i][9].ToString();
                        Label3.Text = "₹" + dt9.Rows[i][2].ToString();



                    }



                }

                if (i == 1)
                {
                    String firsturl = dt9.Rows[i][11].ToString();
                    String secondurl = dt9.Rows[i][12].ToString();
                    id12 = dt9.Rows[i][0].ToString();

                    string physicalPath = Convert.ToString(firsturl);
                    string imagesPhysicalPath = Server.MapPath("~/Files/");

                    if (physicalPath.StartsWith(imagesPhysicalPath, StringComparison.OrdinalIgnoreCase))
                    {
                        string relativePath = physicalPath.Substring(imagesPhysicalPath.Length);

                        Image3.ImageUrl = "~/Files/" + relativePath.Replace('\\', '/');
                        Label4.Text = dt9.Rows[i][1].ToString();
                        Label6.Text = dt9.Rows[i][9].ToString();
                        Label5.Text = "₹" + dt9.Rows[i][2].ToString();



                    }



                }
                if (i == 2)
                {
                    String firsturl = dt9.Rows[i][11].ToString();
                    String secondurl = dt9.Rows[i][12].ToString();
                    id12 = dt9.Rows[i][0].ToString();

                    string physicalPath = Convert.ToString(firsturl);
                    string imagesPhysicalPath = Server.MapPath("~/Files/");

                    if (physicalPath.StartsWith(imagesPhysicalPath, StringComparison.OrdinalIgnoreCase))
                    {
                        string relativePath = physicalPath.Substring(imagesPhysicalPath.Length);

                        Image2.ImageUrl = "~/Files/" + relativePath.Replace('\\', '/');
                        Label7.Text = dt9.Rows[i][1].ToString();
                        Label8.Text = dt9.Rows[i][9].ToString();
                        Label9.Text = "₹" + dt9.Rows[i][2].ToString();



                    }



                }
                if (i == 3)
                {
                    String firsturl = dt9.Rows[i][11].ToString();
                    String secondurl = dt9.Rows[i][12].ToString();
                    id12 = dt9.Rows[i][0].ToString();

                    string physicalPath = Convert.ToString(firsturl);
                    string imagesPhysicalPath = Server.MapPath("~/Files/");

                    if (physicalPath.StartsWith(imagesPhysicalPath, StringComparison.OrdinalIgnoreCase))
                    {
                        string relativePath = physicalPath.Substring(imagesPhysicalPath.Length);

                        Image4.ImageUrl = "~/Files/" + relativePath.Replace('\\', '/');
                        Label10.Text = dt9.Rows[i][1].ToString();
                        Label12.Text = dt9.Rows[i][9].ToString();
                        Label11.Text = "₹" + dt9.Rows[i][2].ToString();



                    }



                }




            }
        }
    }
}