using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Task2
{
    public partial class MainPage : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["strconn"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(Server.MapPath("Image"))) ;
            {
                Directory.CreateDirectory(Server.MapPath("Image"));
            }
            string imgurl = (Server.MapPath("Image")) + "\\" + flImage.FileName;
            string dbpath = "~/Image/" + flImage.FileName;
            flImage.SaveAs(imgurl);
            SqlCommand cmd = new SqlCommand("insert into product(ProductImage) " +
                "values(@pimg)", conn);
            cmd.Parameters.AddWithValue("@pimg", dbpath);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}