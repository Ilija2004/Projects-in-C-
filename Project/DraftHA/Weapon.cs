using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftHA
{
    class Weapon
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int HitPoints { get; set; }

        public Weapon(string name, int hitPoints)
        {
            Name = name;
            Damage = 0;
            HitPoints = hitPoints;
        }
    }
}
