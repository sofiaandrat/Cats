using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Numerics;
using System.Text;
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
        }
        public DataTable Apdate_queue()
        {
            string query = "SELECT * FROM registration";
            SQLiteCommand myCommand = new SQLiteCommand(query, this.myConnection);
            this.OpenConnection();
            myCommand.ExecuteNonQuery();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(myCommand);
            DataTable dt = new DataTable("registration");
            adapter.Fill(dt);
            this.CloseConnection();
            return dt;
        }
    }
}
