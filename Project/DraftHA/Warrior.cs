using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftHA
{
    class Warrior : Character
    {
        public Weapon Weapon { get; set; }

        public Warrior(string name, Weapon weapon) : base(name)
        {
            Weapon = weapon;

        }
        public virtual void Battle(Character opponent, bool win)
        {
            base.Battle(opponent, win);
            if (win)
            {
                opponent.health -= Weapon.HitPoints;
            }
            else
            {
                Weapon.Damage += opponent.level * 2;
                if (Weapon.Damage >= 100)
                {
                    Weapon.HitPoints = 0;
                }
            }
        }
    }
}
