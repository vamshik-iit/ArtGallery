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
    public partial class upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Type.Items.Clear();
                Cat.Items.Clear();
                UpdateDropdownList();
            }
            if (Session["Role"].ToString() == "Admin")
            {
                username.Enabled = true;
            }
            else
            {
                username.Text = Session["USERID"].ToString();
            }
        }


        protected void UpdateDropdownList()
        {
            try
            {

                DataTable Td = new DataTable();
                Td = GetData("select * from LookUp where LOOKUPTYPE='Type'");
                for (int i = 0; i < Td.Rows.Count; i++)
                {

                    Type.Items.Insert(i, Td.Rows[i]["ID"].ToString() + "-"+ Td.Rows[i]["LOOKUPVALUE"].ToString());
                }

                Td = GetData("select * from LookUp where LOOKUPTYPE='Cat'");
                for (int i = 0; i < Td.Rows.Count; i++)
                {

                    Cat.Items.Insert(i, Td.Rows[i]["ID"].ToString() + "-" + Td.Rows[i]["LOOKUPVALUE"].ToString());
                }
            }
            catch(Exception ex)
            {

            }
        }
        protected void Upload(object sender, EventArgs e)
        {
            try
            {
                string userid = username.Text;
                string QuantityAvl = Quantity.Text;
                string Costper1 = Cost.Text;
                string type = "";
                string cat = "";
                string TypeItem = Type.SelectedValue.ToString();
                string[] strlist = TypeItem.Split('-');
                type = strlist[0];
                TypeItem = Cat.SelectedValue.ToString();
                strlist=TypeItem.Split('-');
                cat = strlist[0];
                string insquery1 = "insert into ARTS(TYPE,USERID,CATEGEORY)" +
                    "values(" + type + "," + userid + "," + cat + ")";

               
                if (insup(insquery1))
                {
                    string sel1 = "select * from (select * from ARTS where TYPE=" + type + " and USERID =" + userid + " order by DATEADDED desc) where rownum=1";
                    DataTable dt = new DataTable();
                    dt = GetData(sel1);
                    string ITEMID = dt.Rows[0]["ITEMID"].ToString();

                    string insquery2 = "update ARTCOST set QUANTITY=" + QuantityAvl + ",COST=" + Costper1 + "" +
                        " where ITEMID=" + ITEMID + "";

                    if (insup(insquery2))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Item added')", true);

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected DataTable GetData( string query)
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
            catch(Exception ex)
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