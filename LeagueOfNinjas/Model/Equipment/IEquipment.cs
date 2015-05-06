using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinjas.Model.Equipment
{
    public interface IEquipment
    {
        int Price { get; set; }
        public int Strength { get; set; }
        public int Agillity { get; set; }
        public int Intelligence { get; set; }
    }
}
