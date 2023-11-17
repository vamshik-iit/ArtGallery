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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadArts();
        }
        private void LoadArts()
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["USERID"] == null)
                    {
                        Response.Redirect("Login.aspx",true);
                    }
                }
                DataTable ArtsData = new DataTable();
                string qry = "select a1.itemid,l.LOOKUPVALUE as TYPE,ud.name,a1.dateadded,l2.LOOKUPVALUE as CATEGEORY,a2.quantity,a2.cost from ARTS a1 " +
                    "left join artcost a2 on a1.itemid = a2.itemid " +
                    "left join lookup l on l.ID = a1.TYPE " +
                    "left join lookup l2 on l2.ID = a1.CATEGEORY " +
                    "left join userdata ud on ud.userid = a1.userid";

                ArtsData = GetData(qry);

              

                GridView1.DataSource = ArtsData;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {

            }

        }
        protected DataTable GetData(string query)
        {
            DataTable Td = new DataTable();
            try
            {


                string connectionstring = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();

                OracleConnection Con = new OracleConnection(connectionstring);
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = Con;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = query;
                Con.Open();
                OracleDataAdapter reader = new OracleDataAdapter(cmd);
                reader.Fill(Td);
                Con.Close();


            }
            catch (Exception ex)
            {

            }
            return Td;
        }
        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {

            }

        }

    }
}