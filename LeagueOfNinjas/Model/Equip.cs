using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinjas.Model
{
    public class Equip
    {
        public int Gold { get; set; }
        public int Strength { get; set; }
        public int Agillity { get; set; }
        public int Intelligence { get; set; }
        public virtual Category Category { get; set; }

    }
}
