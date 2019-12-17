using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
    public class DataBaseFeeder:DataBase, IDataBaseFeeder
    {
        private static Mutex mutex;
        public DataBaseFeeder()
        {
            myConnection = new SQLiteConnection("Data Source=users.sqlite3");
            mutex = new Mutex();
        }

        

        public void AddFeeder(int UserId, int amount, string tag)
        {
            mutex.WaitOne();
            string query = "INSERT INTO feeder ('userId', 'amount') VALUES (@userId, @amount)";
            SQLiteCommand myCommand = new SQLiteCommand(query, this.myConnection);
            this.OpenConnection();
            myCommand.Parameters.AddWithValue("@userId", UserId);
            myCommand.Parameters.AddWithValue("@amount", amount);
            myCommand.ExecuteNonQuery();
            this.CloseConnection();
            string query1 = "SELECT feederId FROM feeder";
            SQLiteCommand myCommand1 = new SQLiteCommand(query1, this.myConnection);
            this.OpenConnection();
            SQLiteDataReader reader = myCommand1.ExecuteReader();
            int feederId = 0;
            while (reader.Read())
                feederId = reader.GetInt32(0);
            this.CloseConnection();
            if (tag != "")
            {
                string query2 = "INSERT INTO tags ('feederId', 'tagStr') VALUES (@feederId, @tagStr)";
                SQLiteCommand myCommand2 = new SQLiteCommand(query2, this.myConnection);
                this.OpenConnection();
                myCommand2.Parameters.AddWithValue("@feederId", feederId);
                myCommand2.Parameters.AddWithValue("@tagStr", tag);
                myCommand2.ExecuteNonQuery();
                this.CloseConnection();
            }
            mutex.ReleaseMutex();
        }
    }
}
