using SQLite;
using SQLiteNetExtensions.Attributes;


namespace Dressing_Room.Models
{
    [Table("Clothes")]
    public class Clothes
    {
        [PrimaryKey, AutoIncrement]
        public int CID { get; set; }

        public string Type { get; set; }

        public string Color { get; set; }

        public string Categories { get; set; }

        public byte[] Source { get; set; }

        [ForeignKey(typeof(User))]
        public string UserID { get; set; }
    }
}
