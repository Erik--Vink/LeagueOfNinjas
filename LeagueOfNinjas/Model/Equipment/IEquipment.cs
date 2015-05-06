using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinjas.Model.Equipment
{
    public interface IEquipment
    {
        public int Id { get; set; }
        int Price { get; set; }
        public int Strength { get; set; }
        public int Agillity { get; set; }
        public int Intelligence { get; set; }
        public string Name { get; set; }
    }
}
