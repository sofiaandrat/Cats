using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DataBaseUser:DataBase
    {
        public DataBaseUser()
        {
            myConnection = new SQLiteConnection("Data Source=users.sqlite3");
        }

        public void Insert(User user)
        {
            string query = "INSERT INTO users ('name', 'email', 'hash_password', 'typeId') VALUES (@name, @email, @hash_password, @typeId)";
            SQLiteCommand myCommand = new SQLiteCommand(query, this.myConnection);
            this.OpenConnection();
            myCommand.Parameters.AddWithValue("@name", user.Name);
            myCommand.Parameters.AddWithValue("@email", user.Email);
            myCommand.Parameters.AddWithValue("@hash_password", user.Hash_password);
            myCommand.Parameters.AddWithValue("@typeId", user.TypeId);
            myCommand.ExecuteNonQuery();
            this.CloseConnection();
        }

        public void Insert(string name, string email, string password, int typeId = 1)
        {
            string query = "INSERT INTO registration ('name', 'email', 'hash_password', 'typeId') VALUES (@name, @email, @hash_password, @typeId)";
            SQLiteCommand myCommand = new SQLiteCommand(query, this.myConnection);
            this.OpenConnection();
            myCommand.Parameters.AddWithValue("@name", name);
            myCommand.Parameters.AddWithValue("@email", email);
            myCommand.Parameters.AddWithValue("@hash_password", hash(password));
            myCommand.Parameters.AddWithValue("@typeId", typeId);
            myCommand.ExecuteNonQuery();
            this.CloseConnection();
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
            string query1 = "SELECT name FROM users WHERE name = @name OR email = @email";
            SQLiteCommand myCommand = new SQLiteCommand(query1, this.myConnection);
            string query2 = "SELECT name FROM registration WHERE name = @name OR email = @email";
            SQLiteCommand myCommand1 = new SQLiteCommand(query2, this.myConnection);
            this.OpenConnection();
            myCommand.Parameters.AddWithValue("@name", name);
            myCommand.Parameters.AddWithValue("@email", email);
            myCommand1.Parameters.AddWithValue("@name", name);
            myCommand1.Parameters.AddWithValue("@email", email);
            SQLiteDataReader reader = myCommand.ExecuteReader();
            SQLiteDataReader reader1 = myCommand1.ExecuteReader();
            if (!reader.Read() || !reader1.Read())
                return false;
            return true;
        }

        public int Login(string password, string login)
        {
            string hash_password = hash(password);
            string query = "SELECT typeId FROM users WHERE name = @login AND hash_password = @hash_password";
            SQLiteCommand myCommand = new SQLiteCommand(query, this.myConnection);
            this.OpenConnection();
            myCommand.Parameters.AddWithValue("@login", login);
            myCommand.Parameters.AddWithValue("@hash_password", hash_password);
            SQLiteDataReader reader = myCommand.ExecuteReader();
            if (reader.Read())
                return (int)reader.GetInt32(0);
            else
                return 0;
        }

        public void Delete(string login)
        {
            string query = "DELETE FROM registration WHERE name = @login";
            SQLiteCommand myCommand = new SQLiteCommand(query, this.myConnection);
            this.OpenConnection();
            myCommand.Parameters.AddWithValue("@login", login);
            myCommand.ExecuteNonQuery();
        }
    }
}
