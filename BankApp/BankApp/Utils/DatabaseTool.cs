using Microsoft.Data.Sqlite;

namespace BankApp.Utils
{
    public class DatabaseTool
    {
        private SqliteConnection? _sqlite_conn;

        public SqliteConnection CreateConnection()
        {
            SqliteConnection sqlite_conn;
            _sqlite_conn = new SqliteConnection("Data Source=bankDB.db;");
            try
            {
                _sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return _sqlite_conn;
        }
    }
}
