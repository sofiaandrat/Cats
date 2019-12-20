using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
    public class DataBaseForTester:DataBase, IDataBaseForTester
    {
        public DataBaseForTester()
        {
            myConnection = new SQLiteConnection("Data Source=users.sqlite3");
            mutex = new Mutex();
        }
        public DataTable TakeData()
        {
            DataTable data = new DataTable();
            DataTable feeders = new DataTable();
            mutex.WaitOne();
            string query = "SELECT id FROM users";
            SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
            OpenConnection();
            myCommand.ExecuteNonQuery();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(myCommand);
            adapter.Fill(data);
            CloseConnection();
            DataBaseFeeder dataBaseFeeder = new DataBaseFeeder();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (data.Rows[i] is DataRow row_selected)
                {
                    int userId = Convert.ToInt32(row_selected["id"].ToString());
                    feeders.Merge(dataBaseFeeder.update(userId));
                }
            }
            mutex.ReleaseMutex();
            return feeders;
        }
    }
}
