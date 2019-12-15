using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class DataBaseFeeder:DataBase, IDataBaseFeeder
    {
        public DataBaseFeeder()
        {
            myConnection = new SQLiteConnection("Data Source=users.sqlite3");
        }

        public void AddFeeder(int UserId, int amount, string tag)
        {
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
            SQLiteDataReader reader = myCommand.ExecuteReader();
            int feederId = reader.GetInt32(reader.FieldCount - 1);
            this.CloseConnection();
            if (tag != "")
            {
                string query2 = "INSERT INTO tags ('feederId', 'tagStr') VALUES (@feederId, @tagStr)";
                SQLiteCommand myCommand2 = new SQLiteCommand(query2, this.myConnection);
                this.OpenConnection();
                myCommand.Parameters.AddWithValue("@feederId", feederId);
                myCommand.Parameters.AddWithValue("@tagStr", tag);
                myCommand.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
    }
}
