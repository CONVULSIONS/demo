using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Demo.Data
{
    public static class Database
    {
        private static string _connectionString = "Server=localhost\\SQLEXPRESS;Database=Тест;Trusted_Connection=True;";
        private static SqlConnection _connection;
        private static SqlCommand _command = new SqlCommand("", _connection);


        public static void OpenConnection()
        {
            try
            {
                _connection = new SqlConnection(_connectionString);
                _connection.Open();
            }
            catch
            {
                MessageBox.Show("Ошибка подключения к бд! зиг хайль");
            }
        }
        public static void CloseConnection()
        {
            try
            {
                if (_connection != null && _connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка отключения от бд! зиг хайль");
            }
        }
        public static void SetQuery(string queryText)
        {
            _command.CommandText = queryText;
        }

        public static void AddParameter(string name, object value)
        {
            _command.Parameters.AddWithValue(name, value);
        }

        public static void ClearParameters()
        {
            _command.Parameters.Clear();
        }

        public static void Execute()
        {
            OpenConnection();
            _command.Connection = _connection;
            _command.ExecuteNonQuery();
        }

        public static SqlDataReader ExecuteReader()
        {
            OpenConnection();
            _command.Connection = _connection;
            return _command.ExecuteReader();
        }

        public static object ExecuteScalar()
        {
            OpenConnection();
            _command.Connection = _connection;
            return _command.ExecuteScalar();
        }
    }
}
