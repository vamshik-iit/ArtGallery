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
    public partial class userpurchase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"].ToString() == "Admin")
            {
                username.Enabled = true;
                user.Visible = true;
            }
            else
            {
                username.Text = Session["USERID"].ToString();
            }
            LoadArts();
        }

        protected void Fetch(object sender, EventArgs e)
        {
            LoadArts();
        }
        private void LoadArts()
        {
            try
            {
                string user = username.Text;
                DataTable ArtsData = new DataTable();
                ArtsData = GetData("select * from ARTISTBALANCEBOOK where USERID=" + user + "");
                if (ArtsData.Rows.Count > 0)
                {
                    GridView1.DataSource = ArtsData;
                    GridView1.DataBind();
                }
                else
                {
                    Recordsdiv.Visible = true;
                }

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