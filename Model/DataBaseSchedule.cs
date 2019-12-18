using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
    public class DataBaseSchedule:DataBase, IDataBaseSchedule
    {
        public DataBaseSchedule()
        {
            mutex = new Mutex();
            myConnection = new SQLiteConnection("Data Source=users.sqlite3");
        }

        public void AddSchedule(int amount, int timer, string name, int feederId)
        {
            mutex.WaitOne();
            string query = "INSERT INTO schedule ('feederId', 'Name') VALUES (@feederId, @name)";
            SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
            this.OpenConnection();
            myCommand.Parameters.AddWithValue("@feederId", feederId);
            myCommand.Parameters.AddWithValue("@name", name);
            myCommand.ExecuteNonQuery();
            CloseConnection();
            string query1 = "SELECT SheduleId FROM schedule";
            SQLiteCommand myCommand1 = new SQLiteCommand(query1, myConnection);
            OpenConnection();
            SQLiteDataReader reader = myCommand1.ExecuteReader();
            int scheduleId = 0;
            while (reader.Read())
                scheduleId = reader.GetInt32(0);
            CloseConnection();
            int time = 24 * 60 / timer;
            string query2 = "INSERT INTO event ('scheduleId', 'time', 'amount') VALUES (@scheduleId, @time, @amount)";
            SQLiteCommand myCommand2 = new SQLiteCommand(query2, myConnection);
            OpenConnection();
            for (int i = 0; i < timer; i += time)
            {
                myCommand2.Parameters.AddWithValue("@scheduleId", scheduleId);
                myCommand2.Parameters.AddWithValue("@time", i);
                myCommand2.Parameters.AddWithValue("@amount", amount);
                myCommand2.ExecuteNonQuery();
            }
            CloseConnection();
            mutex.ReleaseMutex();
        }
    }
}
