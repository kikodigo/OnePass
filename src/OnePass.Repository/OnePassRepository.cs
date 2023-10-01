using Dapper;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using OnePass.Domain.Data;
using OnePass.Domain.Request;
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

        public async Task<string> conectDb()
        {
            try
            {
                _mySqlConnection.Open();

                Console.WriteLine(_mySqlConnection.State.ToString());

                _logger.LogInformation($"Log gerado via MS Logging {_mySqlConnection.State.ToString()}");

                return _mySqlConnection.State.ToString();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Não foi possivel conectar no banco {ex.Message}");

                throw;
            }
            finally
            {
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    _mySqlConnection.Close();
                }
            }
        }

        public async Task<EstoqueItem> GetItem(int itemId)
        {
            _mySqlConnection.Open();

            var estoqueItem = _mySqlConnection.QueryFirstOrDefault<EstoqueItem>("SELECT * FROM estoque WHERE id = @id", new { id = itemId });

            _mySqlConnection.Close();

            return estoqueItem;
        }

        public async Task<bool> CreateLoginMasterAsync(MasterLoginRequest masterLoginRequest)
        {
            _mySqlConnection.Open();

            var result = _mySqlConnection.Query($"INSERT INTO `login_master` (`id`, `user`, `password`, `active`) VALUES (NULL, '{masterLoginRequest.User}', '{masterLoginRequest.Password}', '1');");

            return true;
        }

        //MySqlConnection connection = new MySqlConnection(connectionString);

        //connection.Open();

        //    MySqlCommand comando = new MySqlCommand("SELECT `item` FROM `estoque` where `id` = 1", connection);
        //MySqlDataReader dr = comando.ExecuteReader();
        //DataTable dt = new DataTable();
        //dt.Load(dr);

        //    MessageBox.Show(dt.Rows[0]["item"].ToString());

        //    connection.Close();

        //INSERT INTO `login_master` (`id`, `user`, `password`, `active`) VALUES (NULL, 'user', 'bla', '1');
    }
}
