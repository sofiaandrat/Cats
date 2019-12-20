using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
    public class DataBaseUser:DataBase, IDataBaseUser
    {
        public DataBaseUser()
        {
            myConnection = new SQLiteConnection("Data Source=users.sqlite3");
            mutex = new Mutex();
        }

        public void Insert(User user)
        {
            mutex.WaitOne();
            string query = "INSERT INTO users ('name', 'email', 'hash_password', 'typeId') VALUES (@name, @email, @hash_password, @typeId)";
            SQLiteCommand myCommand = new SQLiteCommand(query, this.myConnection);
            OpenConnection();
            myCommand.Parameters.AddWithValue("@name", user.Name);
            myCommand.Parameters.AddWithValue("@email", user.Email);
            myCommand.Parameters.AddWithValue("@hash_password", user.Hash_password);
            myCommand.Parameters.AddWithValue("@typeId", user.TypeId);
            myCommand.ExecuteNonQuery();
            CloseConnection();
            mutex.ReleaseMutex();
        }

        public void Insert(string name, string email, string password, int typeId = 3)
        {
            mutex.WaitOne();
            string query = "INSERT INTO registration ('name', 'email', 'hash_password', 'typeId') VALUES (@name, @email, @hash_password, @typeId)";
            SQLiteCommand myCommand = new SQLiteCommand(query, this.myConnection);
            OpenConnection();
            myCommand.Parameters.AddWithValue("@name", name);
            myCommand.Parameters.AddWithValue("@email", email);
            myCommand.Parameters.AddWithValue("@hash_password", hash(password));
            myCommand.Parameters.AddWithValue("@typeId", typeId);
            myCommand.ExecuteNonQuery();
            CloseConnection();
            mutex.ReleaseMutex();
        }

        private string hash(string password)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(password);
            MemoryStream stream = new MemoryStream(byteArray);
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(stream);
            return Encoding.UTF8.GetString(md5data);
        }

        public bool IsItFree(string name, string email)
        {
            mutex.WaitOne();
            string query1 = "SELECT name FROM users WHERE name = @name OR email = @email";
            SQLiteCommand myCommand = new SQLiteCommand(query1, this.myConnection);
            string query2 = "SELECT name FROM registration WHERE name = @name OR email = @email";
            SQLiteCommand myCommand1 = new SQLiteCommand(query2, this.myConnection);
            OpenConnection();
            myCommand.Parameters.AddWithValue("@name", name);
            myCommand.Parameters.AddWithValue("@email", email);
            myCommand1.Parameters.AddWithValue("@name", name);
            myCommand1.Parameters.AddWithValue("@email", email);
            SQLiteDataReader reader = myCommand.ExecuteReader();
            SQLiteDataReader reader1 = myCommand1.ExecuteReader();
            bool flag = true;
            if (!reader.Read() || !reader1.Read())
                flag = false;
            CloseConnection();
            mutex.ReleaseMutex();
            return flag;
        }

        public List <int> Login(string password, string login)
        {
            mutex.WaitOne();
            string hash_password = hash(password);
            string query = "SELECT typeId, id FROM users WHERE name = @login AND hash_password = @hash_password";
            SQLiteCommand myCommand = new SQLiteCommand(query, this.myConnection);
            OpenConnection();
            myCommand.Parameters.AddWithValue("@login", login);
            myCommand.Parameters.AddWithValue("@hash_password", hash_password);
            SQLiteDataReader reader = myCommand.ExecuteReader();
            List<int> data;
            if (reader.Read())
                data = new List<int>() { (int)reader.GetInt32(0), (int)reader.GetInt32(1) };
            else
               data = new List<int>() { 0, 0 };
            CloseConnection();
            mutex.ReleaseMutex();
            return data;
        }

        public string TakeALogin(int userId)
        {
            mutex.WaitOne();
            string query = "SELECT name FROM users WHERE id = @id";
            SQLiteCommand myCommand = new SQLiteCommand(query, this.myConnection);
            OpenConnection();
            myCommand.Parameters.AddWithValue("@id", userId);
            SQLiteDataReader reader = myCommand.ExecuteReader();
            string login = "";
            while (reader.Read())
                login += reader.GetString(0);
            CloseConnection();
            mutex.ReleaseMutex();
            return login;
        }

        public DataTable UsersList()
        {
            mutex.WaitOne();
            string query = "SELECT name, email FROM users";
            SQLiteCommand myCommand = new SQLiteCommand(query, this.myConnection);
            OpenConnection();
            myCommand.ExecuteNonQuery();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(myCommand);
            DataTable dt = new DataTable("users");
            adapter.Fill(dt);
            CloseConnection();
            mutex.ReleaseMutex();
            return dt;
        }
    }
}
