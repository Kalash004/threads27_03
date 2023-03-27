using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace threads27_03
{
    enum EventType
    {
        Damaged,
        Healed
    }
    internal interface IObservable
    {
        public void DamageHappened(EventType type, int damage, int hp_left);
        public void HealHappened(EventType type, int heal_amount, int hp_left);
    }
}
