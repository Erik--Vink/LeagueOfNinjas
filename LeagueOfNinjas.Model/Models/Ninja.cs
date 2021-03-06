﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinjas.Model.Models
{
    public class Ninja
    {
        [Key]
        public int NinjaId { get; set; }

        public double Budget { get; set; }

        public virtual ICollection<Equip> Equips { get; set; }

        public Ninja()
        {
            Equips = new HashSet<Equip>();
        }
    }
}
