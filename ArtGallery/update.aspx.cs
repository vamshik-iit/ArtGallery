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
    public partial class update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Fetch(object sender, EventArgs e)
        {
            try
            {
                string Item = itemid.Text;
                string QuantityAvl = Quantity.Text;
                string Costper1 = Cost.Text;
                string userid = Session["USERID"].ToString();
                string query = "";
                if (Session["Role"].ToString() == "Admin")
                {
                    query = "select * from artcost where ITEMID=" + Item + "";
                }
                else
                {
                    query = "select * from arts a1 left join artcost a2 on a1.ITEMID=a2.ITEMID" +
                        " where ITEMID=" + Item + " and a1.USERID=" + userid + "";
                }
                DataTable dt = new DataTable();
                dt = GetData(query);
                Quantity.Text = dt.Rows[0]["QUANTITY"].ToString();
                Cost.Text = dt.Rows[0]["COST"].ToString();
            }
            catch (Exception ex)
            {

            }
        }
        protected void Update(object sender, EventArgs e)
        {
            try
            {
                string Item = itemid.Text;
                string QuantityAvl = Quantity.Text;
                string Costper1 = Cost.Text;
                string userid = Session["USERID"].ToString();
                string query = "";
                if (Session["Role"].ToString() == "Admin")
                {
                    query = "select * from artcost where ITEMID=" + Item + "";
                }
                else
                {
                    query = "select * from arts a1 left join artcost a2 on a1.ITEMID=a2.ITEMID" +
                        " where ITEMID=" + Item + " and a1.USERID=" + userid + "";
                }
                DataTable dt = new DataTable();
                dt = GetData(query);
               if(dt.Rows.Count > 0)
                {
                    query = "update artcost set QUANTITY=" + QuantityAvl + ",COST=" + Costper1 + " where ITEMID=" + Item + "";

                    if (insup(query))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Item updated')", true);

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please try again')", true);

                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please try again')", true);

                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void Delete(object sender, EventArgs e)
        {
            try
            {
                string Item = itemid.Text;
                string QuantityAvl = Quantity.Text;
                string Costper1 = Cost.Text;
                string userid = Session["USERID"].ToString();
                string query = "";
                if (Session["Role"].ToString() == "Admin")
                {
                    query = "select * from artcost where ITEMID=" + Item + "";
                }
                else
                {
                    query = "select * from arts a1 left join artcost a2 on a1.ITEMID=a2.ITEMID" +
                        " where ITEMID=" + Item + " and a1.USERID=" + userid + "";
                }
                DataTable dt = new DataTable();
                dt = GetData(query);
                if (dt.Rows.Count > 0)
                {
                    query = "delete from artcost where ITEMID=" + Item + "";

                    if (insup(query))
                    {
                        query = "delete from arts where ITEMID=" + Item + "";
                        if (insup(query))
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Item deleted')", true);

                        }

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please try again')", true);

                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please try again')", true);

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


        protected Boolean insup(string query)
        {
            try
            {


                string connectionstring = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
                OracleConnection Con = new OracleConnection(connectionstring);
                OracleCommand cmd = new OracleCommand();
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

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

    }
}