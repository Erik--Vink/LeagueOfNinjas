using LeagueOfNinjas.Model.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinjas.Model
{
    public class Shop
    {
        public List<Shoulder> _shoulders;

        public List<Shoulder> Shoulders
        {
            get { return _shoulders; }
            set { _shoulders = value; }
        }
    }
}
