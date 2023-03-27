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
        private List<IObservable> observers = new List<IObservable>();
        private ReaderWriterLockSlim _locker = new ReaderWriterLockSlim();
        bool dead = false;

        internal void GetDamaged()
        {
            throw new NotImplementedException();
        }

        public Player(string name, int health)
        {
            this.name = name;
            this.health = health;
        }

        public string Name { get => name; set => name = value; }
        public int Health { get => health; set => health = value; }

        public void GetDamaged(int amount)
        {
            lock (this)
            {
                if (health <= 0) return;
                if (health < amount) amount = health;
                this.Health = this.Health - amount;
                Thread event_notif = new Thread(() => NotifyDamage(EventType.Damaged, amount, this.Health));
                if (observers.Count > 0)
                {
                    event_notif.Start();
                }
                event_notif.Join();
            }
        }

        public void GetHealed(int amount)
        {
            lock (this)
            {
                if (this.Health <= 0) return;
                this.Health = this.Health + amount;
                Thread event_notif = new Thread(() => NotifyHealed(EventType.Healed, amount, this.Health));
                if (observers.Count > 0)
                {
                    event_notif.Start();
                }
                event_notif.Join();
            }
        }

        public int ReadHealth()
        {
            try
            {
                _locker.EnterReadLock();
                return this.Health;

            }
            finally
            {
                _locker.ExitReadLock();
            }


        }

        public void BecomeObserver(IObservable obj)
        {
            this.observers.Add(obj);
        }

        private void NotifyDamage(EventType type, int damage, int health)
        {
            foreach (var observer in observers)
            {
                observer.DamageHappened(type, damage, health);
            }
        }

        private void NotifyHealed(EventType type, int healed, int health)
        {
            foreach (var observer in observers)
            {
                observer.HealHappened(type, healed, health);
            }
        }
    }
}
