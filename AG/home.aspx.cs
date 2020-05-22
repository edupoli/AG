using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace AG
{
    public partial class _Default : Page
    {
        string queryInsert;
        public string nomeProjeto = string.Empty;
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            nomeProjeto = Session["projeto"].ToString();

            Timer1.Enabled = true;
            Timer1.Interval = 10000;
            if (!Page.IsPostBack)
            {
                string connectionString = "Server=10.0.3.119;Database=gen_config;User Id=Sercomtel;Password=genesys@2019";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd;
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter();
                string sql = "SELECT [number_],[prop_value],[prop_name],[group_dbid] FROM [gen_config].[dbo].[Consulta_IP] where [prop_value] = '*' and [group_dbid] = '203'";
                cmd = new SqlCommand(sql, con);
                da.SelectCommand = cmd;
                da.Fill(dt);

                string conec = "SERVER=10.0.2.9;UID=ura;PWD=ask123;DATABASE=ag;Allow User Variables=True;Pooling=False";
                MySqlConnection conLocal = new MySqlConnection(conec);
                string query = "CREATE TEMPORARY TABLE IF NOT EXISTS disponiveis(numero varchar(45) DEFAULT NULL)";
                MySqlCommand command;
                conLocal.Open();
                command = new MySqlCommand(query, conLocal);
                command.ExecuteNonQuery();

                foreach (DataRow item in dt.Rows)
                {
                    string ag = item["number_"].ToString();
                    queryInsert = "INSERT INTO ag.disponiveis(numero) VALUES(@ag)";
                    MySqlCommand cmdInsert = new MySqlCommand(queryInsert, conLocal);
                    cmdInsert.Parameters.AddWithValue("@ag", ag);
                    cmdInsert.ExecuteNonQuery();
                }

                string projetoID = Session["projetoID"].ToString();
                DataTable dtTemp = new DataTable();
                MySqlDataAdapter daTemp = new MySqlDataAdapter();
                string sqlTemp = "select disponiveis.numero from disponiveis inner join ag on disponiveis.numero = ag.numero and ag.projetoID = " + projetoID;
                MySqlCommand cmdTemp = new MySqlCommand(sqlTemp, conLocal);
                daTemp.SelectCommand = cmdTemp;
                daTemp.Fill(dtTemp);
                int num = dtTemp.Rows.Count;
                dt.Clear();
                dt.Dispose();
                GridView1.DataSource = dtTemp;
                GridView1.DataBind();
                dtTemp.Clear();
                dtTemp.Dispose();
            }
        }

             
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            string connectionString = "Server=10.0.3.119;Database=gen_config;User Id=Sercomtel;Password=genesys@2019";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "SELECT [number_],[prop_value],[prop_name],[group_dbid] FROM [gen_config].[dbo].[Consulta_IP] where [prop_value] = '*' and [group_dbid] = '203'";
            cmd = new SqlCommand(sql, con);
            da.SelectCommand = cmd;
            da.Fill(dt);

            string conec = "SERVER=10.0.2.9;UID=ura;PWD=ask123;DATABASE=ag;Allow User Variables=True;Pooling=False";
            MySqlConnection conLocal = new MySqlConnection(conec);
            string query = "CREATE TEMPORARY TABLE IF NOT EXISTS disponiveis(numero varchar(45) DEFAULT NULL)";
            MySqlCommand command;
            conLocal.Open();
            command = new MySqlCommand(query, conLocal);
            command.ExecuteNonQuery();

            foreach (DataRow item in dt.Rows)
            {
                string ag = item["number_"].ToString();
                queryInsert = "INSERT INTO ag.disponiveis(numero) VALUES(@ag)";
                MySqlCommand cmdInsert = new MySqlCommand(queryInsert, conLocal);
                cmdInsert.Parameters.AddWithValue("@ag", ag);
                cmdInsert.ExecuteNonQuery();
            }

            string projetoID = Session["projetoID"].ToString();
            DataTable dtTemp = new DataTable();
            MySqlDataAdapter daTemp = new MySqlDataAdapter();
            string sqlTemp = "select disponiveis.numero from disponiveis inner join ag on disponiveis.numero = ag.numero and ag.projetoID = " + projetoID;
            MySqlCommand cmdTemp = new MySqlCommand(sqlTemp, conLocal);
            daTemp.SelectCommand = cmdTemp;
            daTemp.Fill(dtTemp);
            int num = dtTemp.Rows.Count;
            dt.Clear();
            dt.Dispose();
            GridView1.DataSource = dtTemp;
            GridView1.DataBind();
            dtTemp.Clear();
            dtTemp.Dispose();
        }
    }

    
}