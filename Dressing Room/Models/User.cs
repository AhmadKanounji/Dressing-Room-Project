using System;
using SQLite;
namespace Dressing_Room.Models
{
    public class User
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public byte[] Source { get; set; }

    }
}

