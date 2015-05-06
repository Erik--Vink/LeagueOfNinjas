using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinjas.Model.Equipment
{
    public class Shoulder : IEquipment
    {
        private int _price;
        private int _str;
        private int _dex;
        private int _int;

        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int Strength
        {
            get { return _str; }
            set { _str = value; }
        }

        public int Agillity
        {
            get { return _dex; }
            set { _dex = value; }
        }

        public int Intelligence
        {
            get { return _int; }
            set { _int = value; }
        }
    }
}
