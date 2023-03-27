using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace threads27_03
{
    internal class Player
    {
        private String name;
        private int health;
        private List<IObservable> observers;

        public Player(string name, int health)
        {
            this.name = name;
            this.health = health;
        }

        public string Name { get => name; set => name = value; }
        public int Health { get => health; set => health = value; }
        
        public void GetDamaged(int amount)
        {
            if (observers.Count > 0)
            {
                Thread event_notif = new Thread(new ParameterizedThreadStart(() => NotifyDamage(amount)));
            }
        }

        public void BecomeObserver(IObservable obj)
        {
            this.observers.Add(obj);
        }

        private void NotifyDamage(int damage)
        {

        }
    }
}
