using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftHA
{
    class Character 
    {

        public string name { get; set; }
        public int health { get; set; }
        public int points { get; set; }
        public int level { get; set; }
        public int wins { get; set; }
        public int loses { get; set; }

        public Character(string name)
        {
            this.name = name;
            health = 100;
            points = 0;
            wins = 0;
            loses = 0;
            level = 1;
        }
        public void Battle(Character opponent, bool win)
        {
            if (win)
            {
                wins++;
                points += opponent.level * 10;
                if (points % 100 == 0)
                {
                    level++;
                }
            }
            else
            {
                loses++;
                health -= opponent.level * 5;
                if (health < 0)
                {
                    health = 0;
                }
            }
        }
    }
}
