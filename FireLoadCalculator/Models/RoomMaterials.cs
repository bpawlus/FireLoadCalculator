using SQLiteNetExtensions.Attributes;
using System.Xml.Linq;

namespace FireLoadCalculator.Models
{
    public class RoomMaterials
    {
        public RoomMaterials() { }
        public RoomMaterials(int _rid, int _mid, float _weight, uint _count)
        {
            RoomId = _rid;
            MaterialId = _mid;
            MaterialWeight = _weight;
            MaterialCount = _count;
        }


        [ForeignKey(typeof(Room))]
        public int RoomId { get; set; }

        [ForeignKey(typeof(Material))]
        public int MaterialId { get; set; }
        public float MaterialWeight { get; set; }
        public uint MaterialCount { get; set; }
    }
}
