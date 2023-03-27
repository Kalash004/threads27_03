using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace threads27_03
{
    internal class Reader : IObservable
    {
        public Reader (Player plr)
        {
            plr.BecomeObserver(this);
        }
        public void DamageHappened(EventType type, int damage, int hp_left)
        {
            Console.WriteLine($"Damaged : {damage} Hp left : {hp_left}");
        }

        public void HealHappened(EventType type, int heal_amount, int hp_left)
        {
            Console.WriteLine($"Healed : {heal_amount} Hp left : {hp_left}");
        }
    }
}
