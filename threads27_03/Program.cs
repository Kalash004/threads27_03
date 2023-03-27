namespace threads27_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Kal", 1000);
            Thread damager = new Thread(() => Damage(player, 10));
            Thread healer = new Thread(() => Heal(player, 10));
            Reader reader = new Reader(player);
            damager.Start();
            healer.Start();

            string path = "dluznici.csv";
            List<String[]> list = ArrayIt(path);
            int[] ids = GetIds(list);
            ThreadedQuickSort<int> sort = new ThreadedQuickSort<int>();
            sort.QuickSort(ids);

        }

        private static int[] GetIds(List<String[]> list)
        {
            int [] ids = new int[list.Count];
            int i = 0;
            foreach (var obj in list)
            {
                ids[i] = int.Parse(obj[0]);
                i++;
            }
            return ids;
        }

        public static void Find(int id, string path)
        {
        }

        public static List<String[]> ArrayIt(string path)
        {
            List<String[]> list = new List<string[]>();
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] columns = line.Split(',');
                list.Add(columns);
            }
            return list;
        }

        public static void Damage(Player plr, int testamount)
        {
            for (int i = 0; i < testamount; i++)
            {
                plr.GetDamaged(RandomAmount(10, 50));
            }
        }

        public static void Heal(Player plr, int testamount)
        {
            for (int i = 0; i < testamount; i++)
            {
                plr.GetHealed(RandomAmount(10, 50));
            }
        }

        public static int RandomAmount(int low, int max)
        {
            return new Random().Next(low, max);
        }


    }
}