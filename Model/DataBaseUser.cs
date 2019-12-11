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
            DataBaseUser objectDataBase = new DataBaseUser();
            string query = "INSERT INTO registration ('name', 'email', 'hash_password', 'typeId') VALUES (@name, @email, @hash_password, @typeId)";
            SQLiteCommand myCommand = new SQLiteCommand(query, objectDataBase.myConnection);
            objectDataBase.OpenConnection();
            myCommand.Parameters.AddWithValue("@name", name);
            myCommand.Parameters.AddWithValue("@email", email);
            myCommand.Parameters.AddWithValue("@hash_password", hash(password));
            myCommand.Parameters.AddWithValue("@typeId", typeId);
            int number = myCommand.ExecuteNonQuery();
            objectDataBase.CloseConnection();
        }
        private string hash(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            return savedPasswordHash;
        }
        public bool IsItFree()
        {
            DataBaseUser objectDataBase = new DataBaseUser();
            string query = "SELECT * FROM users WHERE name = name OR email = email";
            SQLiteCommand myCommand = new SQLiteCommand(query, objectDataBase.myConnection);
            objectDataBase.OpenConnection();
            if (!myCommand.ExecuteReader().Read())
                return false;
            return true;
        }
    }
}
