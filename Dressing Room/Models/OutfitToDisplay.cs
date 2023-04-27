using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dressing_Room.Models
{
    [Table("OutfitToDisplay")]
    public class OutfitToDisplay
    {
        public int Id { get; set; }
        public byte[] Tops { get; set; }
        public byte[] Pants { get; set; }
        public byte[] Shoes { get; set; }
        public byte[] Jackets { get; set; }
        public byte[] Accessories { get; set; }
        public string UserName { get; set; }
        public int Likes { get; set; }

        public byte[] ProfilePhoto { get; set; }
    }
}