using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeagueOfNinjas.Model.Models
{
    public class Equip
    {
        [Key]
        public int EquipId { get; set; }

        public string EquipName { get; set; }

        public double Price { get; set; }

        public int Strength { get; set; }

        public int Intelligence { get; set; }
        public int Agillity { get; set; }
        public string CategoryName { get; set; }

        [ForeignKey("CategoryName")]
        public virtual Category Category { get; set; }
        public virtual ICollection<Ninja> Ninjas { get; set; }

        public Equip()
        {
            Ninjas = new HashSet<Ninja>();
        }

    }
}
