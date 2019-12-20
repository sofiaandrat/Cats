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
            for (int i = 0; i < timer; i++)
            {
                myCommand2.Parameters.AddWithValue("@scheduleId", scheduleId);
                myCommand2.Parameters.AddWithValue("@time", i * time);
                myCommand2.Parameters.AddWithValue("@amount", amount);
                myCommand2.ExecuteNonQuery();
            }
            CloseConnection();
            mutex.ReleaseMutex();
        }

        public List<Event> GetEvents()
        {
            mutex.WaitOne();
            List<Event> events = new List<Event>();
            string query1 = "SELECT scheduleId, time, amount FROM event";
            SQLiteCommand myCommand = new SQLiteCommand(query1, myConnection);
            OpenConnection();
            myCommand.ExecuteNonQuery();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(myCommand);
            DataTable dt = new DataTable("events");
            adapter.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                var cells = row.ItemArray;
                Event @event = new Event(Convert.ToInt32(cells.GetValue(0)), Convert.ToInt32(cells.GetValue(1)), Convert.ToInt32(cells.GetValue(2)));
                events.Add(@event);
            }
            CloseConnection();
            for(int i = 0; i < events.Count(); i++)
            {
                string query = "SELECT feederId FROM schedule WHERE SheduleId = @scheduleId";
                SQLiteCommand myCommand1 = new SQLiteCommand(query, myConnection);
                myCommand1.Parameters.AddWithValue("@scheduleId", events[i].ScheduleId);
                OpenConnection();
                SQLiteDataReader reader1 = myCommand1.ExecuteReader();
                while (reader1.Read())
                    events[i].FeederId = reader1.GetInt32(0);
                CloseConnection();
            }
            mutex.ReleaseMutex();
            return events;
        }
    }
}
