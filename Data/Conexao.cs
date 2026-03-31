using MySql.Data.MySqlClient;
namespace crud01.Data
{
    public class Conexao
    {
        private string connectionString = "server=localhost;database=cadastro;user=root;password=l230908*;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
