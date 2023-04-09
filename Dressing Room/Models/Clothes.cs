using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;
using ForeignKeyAttribute = SQLiteNetExtensions.Attributes.ForeignKeyAttribute;

namespace Dressing_Room.Models
{
        public class Clothes
        {

            [PrimaryKey,AutoIncrement]
            public int CID { get; set; }
            public string Type { get; set; }
            public string Color { get; set; }
            public string Categories { get; set; }
            public string Source { get; set; }


        //[ForeignKey(typeof(User))]
           // public int UserID { get; set; }

          //  [ManyToOne(nameof(UserID))]
           // public User User { get; set; } 



        }
}
