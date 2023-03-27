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
        Dead
    }
    internal interface IObservable
    {
        public void DamageHappened(EventType type, int damage);   
    }
}
