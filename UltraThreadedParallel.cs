namespace UltraThreadedAstroParallelPissProgramming
{
    class App
    {
        private static List<int> list = new List<int>();
        private static EventWaitHandle ewh = new AutoResetEvent(false);
        private static object lockobj = new object();
        private static int ultra_sum = 0;
        static void Main()
        {
            Console.WriteLine("You're not prepared!");
            for (int i = 0; i < 500; i++)
            {
                list.Add(new Random().Next(0, 50));
            }
            Thread t1 = new Thread(() => average("T1"));
            Thread t2 = new Thread(() => average("T2"));
            t1.Start();
            t2.Start();
            ewh.WaitOne();

            Console.WriteLine("They are prepared!");

            t1.Join();
            t2.Join();
            Console.WriteLine("Sum : " + ultra_sum + "\t=>\tAverage : " + ultra_sum / 500);
        }

        static void average(string name)
        {
            Console.WriteLine("I'm prepared - " + name);
            Thread.Sleep(500);  // Hard worker
            ewh.Set();

            bool counting = true;
            while (counting)
            {
                lock (lockobj)
                {
                    if (list.Count > 0)
                    {
                        int last = list[list.Count - 1];
                        list.RemoveAt(list.Count - 1);
                        ultra_sum += last;
                    }
                    if (list.Count == 0)
                    {
                        counting = false;
                    }
                }
            }
        }
    }
}
