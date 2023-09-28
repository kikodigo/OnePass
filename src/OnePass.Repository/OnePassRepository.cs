using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using OnePass.Repository.Interfaces;

namespace OnePass.Repository
{
    public class OnePassRepository : IOnePassRepository
    {
        private readonly ILogger<OnePassRepository> _logger;
        private readonly MySqlConnection _mySqlConnection;

        public OnePassRepository(ILogger<OnePassRepository> logger,
                                 MySqlConnection mySqlConnection)
        {
            _logger = logger;
            _mySqlConnection = mySqlConnection;
        }

        public async Task conectDb()
        {
            _mySqlConnection.Open();
            Console.WriteLine(_mySqlConnection.State.ToString());
            _logger.LogInformation($"Log gerado via MS Logging {_mySqlConnection.State.ToString()}");
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
