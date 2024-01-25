using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireLoadCalculator.Models
{
    public class RoomMaterialsDTO
    {
        public RoomMaterialsDTO(string _name, float _weight, uint _count)
        {   
            MaterialName = _name;
            MaterialWeight = _weight;
            MaterialCount = _count;
        }

        public string MaterialName { get; set; }
        public float MaterialWeight { get; set; }
        public uint MaterialCount { get; set; }
    }
}
