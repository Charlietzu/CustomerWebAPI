using MySql.Data.MySqlClient;
using System.Data;

namespace CustomerWebAPI.Util
{
    public class DAL
    {
        private static string Server = "localhost";
        private static string DataBase = "dbcustomer";
        private static string User = "root";
        private static string Password = "";
        private MySqlConnection Connection;

        private string ConnectionString = $"Server={Server};Database={DataBase};Uid={User};Pwd={Password};Sslmode=none;charset=utf8;";

        public DAL()
        {
            Connection = new MySqlConnection(ConnectionString);
            Connection.Open();
        }

        public void RunSQLCommand(string sql)
        {
            MySqlCommand Command = new MySqlCommand(sql, Connection);
            Command.ExecuteNonQuery();
        }

        public DataTable GetDataTable(string sql)
        {
            MySqlCommand Command = new MySqlCommand(sql, Connection);
            MySqlDataAdapter DataAdapter = new MySqlDataAdapter(Command);
            DataTable Dados = new DataTable();
            DataAdapter.Fill(Dados);
            return Dados;
        }
    }
}
