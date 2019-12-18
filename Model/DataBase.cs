using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.IO;
using System.Threading;

namespace Model
{
    public abstract class DataBase
    {
        protected SQLiteConnection myConnection;
        protected Mutex mutex;

        public DataBase()
        {
        }

        public void OpenConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Open)
            {
                myConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Closed)
            {
                myConnection.Close();
            }
        }
    }
}
