using MySql.Data.MySqlClient;
using OnePass.Repository.Interfaces;

namespace OnePass.Repository
{
    public class OnePassRepository: IOnePassRepository
    {

        private readonly MySqlConnection _mySqlConnection;

        private readonly string _connectionString = "Server=ragnatech.com.br;Database=ragnat92_estoque_system;Uid=ragnat92_master_user;Pwd=Chinelo00123@;";

        public OnePassRepository(MySqlConnection mySqlConnection) 
        {
            _mySqlConnection = mySqlConnection;
        }

        public void conectDb() 
        {
            _mySqlConnection.Open();
            Console.WriteLine(_mySqlConnection.State.ToString());
        }

        //MySqlConnection connection = new MySqlConnection(connectionString);

        //connection.Open();

        //    MySqlCommand comando = new MySqlCommand("SELECT `item` FROM `estoque` where `id` = 1", connection);
        //MySqlDataReader dr = comando.ExecuteReader();
        //DataTable dt = new DataTable();
        //dt.Load(dr);

        //    MessageBox.Show(dt.Rows[0]["item"].ToString());

        //    connection.Close();
    }
}
