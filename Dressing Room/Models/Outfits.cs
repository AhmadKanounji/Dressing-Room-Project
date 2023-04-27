using SQLite;
using SQLiteNetExtensions.Attributes;


namespace Dressing_Room.Models
{
    [Table("Outfits")]
    public class Outfits
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Clothes))]
        public int TopID { get; set; }

        [ForeignKey(typeof(Clothes))]
        public int PantsID { get; set; }

        [ForeignKey(typeof(Clothes))]
        public int JacketID { get; set; }

        [ForeignKey(typeof(Clothes))]
        public int ShoesID { get; set; }

        [ForeignKey(typeof(Clothes))]
        public int AccessoriesID { get; set; }

        [ForeignKey(typeof(User))]
        public string UserID { get; set; }

        public int Likes { get; set; }
        public byte[] ProfilePhoto { get; set; }
    }
}