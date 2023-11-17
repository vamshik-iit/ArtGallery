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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterArt(object sender, EventArgs e)
        {
            try
            {
                string EMAIL = username.Text;
                string passwd = password.Text;
                string contact = Contact.Text;
                string Name = UName.Text;
                DataTable logvalid = new DataTable();
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
                reader.Fill(logvalid);
                Con.Close();

                if (logvalid.Rows.Count > 0)
                {

                    Session["USERID"] = logvalid.Rows[0]["USERID"].ToString();

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User exist with the same email. Kindly Login')", true);


                }
                else
                {

                    query = "insert into USERDATA(NAME,EMAIL,CONTACTNUMBER,PASSWORD) " +
                        "values('" + Name + "','" + EMAIL + "'," + contact + ",'" + passwd + "')";


                    try
                    {
                        OracleTransaction Transaction;
                      
                        cmd.Connection = Con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = query;
                        Con.Open();
                        Transaction = Con.BeginTransaction();
                        cmd.Transaction = Transaction;
                        cmd.ExecuteNonQuery();
                        Transaction.Commit();
                        Con.Close();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registered user as General profile. For any profile changes please contact admin with proper documentation to register as artist')", true);

                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed to register please try again or contact admin')", true);

                    }




                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}