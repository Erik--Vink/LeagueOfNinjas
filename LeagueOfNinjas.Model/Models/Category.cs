using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinjas.Model.Models
{
    public class Category
    {
        [Key]
        public string CategoryName { get; set; }
        public virtual ICollection<Equip> Equips { get; set; }
    }
}
