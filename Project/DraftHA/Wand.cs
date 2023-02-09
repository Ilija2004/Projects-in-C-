using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftHA
{
    class Wand
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int PowerLevel { get; set; }
        public int CurrentStamina { get; set; }

        public Wand(string name, int hitPoints)
        {
            Name = name;
            HitPoints = hitPoints;

        }
    }
}
