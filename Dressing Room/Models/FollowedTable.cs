using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dressing_Room.Models
{
    public class FollowedTable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Follower { get; set; }
        public string Followed { get; set; }
    }
}
