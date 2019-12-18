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
    public class DataBaseTags:DataBase, IDataBaseTags
    {
        public DataBaseTags() 
        {
            mutex = new Mutex();
            myConnection = new SQLiteConnection("Data Source=users.sqlite3");
        }
        public DataTable showTags(int feederId)
        {
            mutex.WaitOne();
            string query = "SELECT tagId, tagStr FROM tags WHERE feederId = @feederId";
            SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
            myCommand.Parameters.AddWithValue("@feederId", feederId);
            OpenConnection();
            myCommand.ExecuteNonQuery();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(myCommand);
            DataTable dt = new DataTable("tags");
            adapter.Fill(dt);
            CloseConnection();
            mutex.ReleaseMutex();
            return dt;
        }

        public void AddTag(int feederId, string tagStr)
        {
            mutex.WaitOne();
            string query = "INSERT INTO tags ('feederId', 'tagStr') VALUES (@feederId, @tagStr)";
            SQLiteCommand myCommand = new SQLiteCommand(query, this.myConnection);
            this.OpenConnection();
            myCommand.Parameters.AddWithValue("@feederId", feederId);
            myCommand.Parameters.AddWithValue("@tagStr", tagStr);
            myCommand.ExecuteNonQuery();
            this.CloseConnection();
            mutex.ReleaseMutex();
        }

        public void deleteTag(int tagId)
        {
            mutex.WaitOne();
            string query = "DELETE FROM tags WHERE tagId = @tagId";
            SQLiteCommand myCommand = new SQLiteCommand(query, this.myConnection);
            this.OpenConnection();
            myCommand.Parameters.AddWithValue("@tagId", tagId);
            myCommand.ExecuteNonQuery();
            this.CloseConnection();
            mutex.ReleaseMutex();
        }
    }
}
