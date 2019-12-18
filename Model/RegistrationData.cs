using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using System.Windows;

namespace Model
{
    public class RegistrationData:DataBase
    {
        private ArrayList queue = new ArrayList();
        public RegistrationData()
        {
            myConnection = new SQLiteConnection("Data Source=users.sqlite3");
            mutex = new Mutex();
        }
        public DataTable Apdate_queue()
        {
            mutex.WaitOne();
            string query = "SELECT * FROM registration";
            SQLiteCommand myCommand = new SQLiteCommand(query, this.myConnection);
            this.OpenConnection();
            myCommand.ExecuteNonQuery();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(myCommand);
            DataTable dt = new DataTable("registration");
            adapter.Fill(dt);
            this.CloseConnection();
            mutex.ReleaseMutex();
            return dt;
        }

        public void Delete(string login)
        {
            mutex.WaitOne();
            string query = "DELETE FROM registration WHERE name = @login";
            SQLiteCommand myCommand = new SQLiteCommand(query, this.myConnection);
            this.OpenConnection();
            myCommand.Parameters.AddWithValue("@login", login);
            myCommand.ExecuteNonQuery();
            this.CloseConnection();
            mutex.ReleaseMutex();
        }
    }
}
