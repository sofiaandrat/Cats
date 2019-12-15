using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
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
        public void Insert(string name, string email, string password, int typeId = 1)
        {
            string query = "INSERT INTO registration ('name', 'email', 'hash_password', 'typeId') VALUES (@name, @email, @hash_password, @typeId)";
            SQLiteCommand myCommand = new SQLiteCommand(query, this.myConnection);
            this.OpenConnection();
            myCommand.Parameters.AddWithValue("@name", name);
            myCommand.Parameters.AddWithValue("@email", email);
            myCommand.Parameters.AddWithValue("@hash_password", hash(password));
            myCommand.Parameters.AddWithValue("@typeId", typeId);
            int number = myCommand.ExecuteNonQuery();
            this.CloseConnection();
        }
        private string hash(string password)
        {
            return password;
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
    }
}
