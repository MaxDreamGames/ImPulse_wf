using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;
using MySql.Data.MySqlClient;
using Serilog;

namespace I_mPulse
{
    internal class DatabaseManager
    {
        FileIniDataParser parser = new FileIniDataParser();
        IniData data;

        public DatabaseManager()
        {
            string path = Path.GetFullPath("Resourses\\config.ini");

            data = parser.ReadFile(path);
        }
        public MySqlConnection GetConnection(string host, int port, string database, string username, string password)
        {
            string connectionString = $"Server={host};Database={database};port={port};User Id={username};password={password};charset=utf8";
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }

        public MySqlConnection Connect(bool isAdmin)
        {
            MySqlConnection sqlConnection = GetConnection(data["MainDatabase"]["host"], int.Parse(data["MainDatabase"]["port"]), data["MainDatabase"]["database"], data["MainDatabase"]["username"], data["MainDatabase"]["password"]);
            if (isAdmin)
            {
                sqlConnection = GetConnection(data["MainDatabase"]["host"], int.Parse(data["MainDatabase"]["port"]), data["MainDatabase"]["database"], data["MainAdminDatabase"]["username"], data["MainAdminDatabase"]["password"]);
            }
            sqlConnection.Open();
            return sqlConnection;
        }

        public DataTable Request(string request, bool isAdmin = false)
        {
            try
            {
                MySqlConnection connection = Connect(isAdmin);
                MySqlCommand cmd = new MySqlCommand(request, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex.Message + ex.StackTrace);
                if (MessageBox.Show(ex.Message + ex.StackTrace, "Ошибка базы данных", MessageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) == DialogResult.Cancel)
                    Application.Exit();
                return null;
            }
        }
    }
}
