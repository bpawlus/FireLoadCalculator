using SQLiteNetExtensions.Attributes;

namespace FireLoadCalculator.Models
{
    public class RoomMaterials
    {
        [ForeignKey(typeof(Room))]
        public int RoomId { get; set; }

        [ForeignKey(typeof(Material))]
        public int MaterialId { get; set; }
        public float MaterialWeight { get; set; }
        public uint MaterialCount { get; set; }
    }
}
