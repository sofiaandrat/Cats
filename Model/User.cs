using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class User
    {
        private int userId;
        public int UserId
        {
            get { return userId; }
        }
        private string name;
        public string Name
        {
            get { return name; }
        }                
        private string email;
        public string Email
        {
            get { return email; }
        }
        private string hash_password;
        public string Hash_password
        {
            get { return hash_password; }
        }
        private int typeId;
        public int TypeId
        {
            get { return typeId; }
        }
        public User(int userId, string name, string email, string hash_password, int typeId)
        {
            this.userId = userId;
            this.name = name;
            this.email = email;
            this.hash_password = hash_password;
            this.typeId = typeId;
        }
    }
}
