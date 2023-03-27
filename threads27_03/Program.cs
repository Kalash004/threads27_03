namespace threads27_03
{
    internal class Program:IObservable
    {
        static void Main(string[] args)
        {
            Player player = new Player("Kal",1000);
            Thread damager = new Thread(() => Damage(player,10));
            Thread healer = new Thread(() => Heal(player,10));
            Reader reader = new Reader(player);
            damager.Start();
            healer.Start();
        }

        public static void Damage(Player plr, int testamount)
        {
            for (int i = 0; i < testamount; i++) { 
                plr.GetDamaged(RandomAmount(10,50));
            }
        }

        public static void Heal(Player plr, int testamount)
        {
            for (int i = 0; i < testamount; i++) {
                plr.GetHealed(RandomAmount(10,50));
            }
        }

        public static int RandomAmount(int low, int max)
        {
            return new Random().Next(low, max);
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