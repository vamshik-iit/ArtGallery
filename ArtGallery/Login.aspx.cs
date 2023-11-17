using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtGallery
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void LoginArt(object sender, EventArgs e)
        {
            try
            {
                string EMAIL = username.Text;
                string passwd = password.Text;
                DataTable ArtGalleryLoginTable = new DataTable();
                string query = "";
                string connectionstring = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();

                OracleConnection Con = new OracleConnection(connectionstring);
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = Con;
                cmd.CommandType = CommandType.Text;
                query = "select * from USERDATA where EMAIL='" + EMAIL + "' and PASSWORD='" + passwd + "'";

                cmd.CommandText = query;
                Con.Open();
                OracleDataAdapter reader = new OracleDataAdapter(cmd);
                reader.Fill(ArtGalleryLoginTable);
                Con.Close();

                if (ArtGalleryLoginTable.Rows.Count > 0)
                {

                    Session["USERID"] = ArtGalleryLoginTable.Rows[0]["USERID"].ToString();

                    if (ArtGalleryLoginTable.Rows[0]["USERTYPE"].ToString() == "Admin")
                    {
                        Session["Role"] = "Admin";
                    }
                    else if (ArtGalleryLoginTable.Rows[0]["USERTYPE"].ToString() == "General")
                    {
                        Session["Role"] = "General";
                    }

                    else
                    {
                        Session["Role"] = "Artist";
                    }

                    Response.Redirect("search.aspx");

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Login')", true);


                }

            }
            catch (Exception ex)
            {

            }
        }

    }
}