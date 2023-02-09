using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftHA
{
    class Mage : Character
    {
        public Wand Wand { get; set; }

        public Mage(String name, Wand wand) : base(name)
        {
            Wand = wand;
        }
        public virtual void Battle(Character opponent, bool win)
        {
            base.Battle(opponent, win);
            if (win)
            {
                opponent.health -= Wand.HitPoints + (Wand.PowerLevel * Wand.CurrentStamina);
                if (Wand.CurrentStamina != 0)
                {
                    Wand.CurrentStamina--;
                }
            }
        }
    }
}
