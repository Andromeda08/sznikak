class Program
{
    static ManualResetEvent m_ResetEvent = new ManualResetEvent(false);
    static List<int> int_list = new List<int>();
    static object lockobj = new object();
    static Random random = new Random();
    static void Main(string[] args)
    {
        Thread w = new Thread(() => worker());
        w.Start();
        Thread.Sleep(random.Next(0, 10) * 1000);
        lock (lockobj)
        {
            if (int_list.Count < 50)
            {
                int_list.Add(-1);
            }
        }
        m_ResetEvent.WaitOne();
        Console.WriteLine("Thank you 💀");
    }

    static void worker()
    {
        bool generating = true;
        while (generating)
        {
            lock (lockobj)
            {
                if (int_list.Count == 199) generating = false;
                int_list.Add(random.Next(0, 10));
            }
            Thread.Sleep(100);
        }
        m_ResetEvent.Set();
        Thread.Sleep(10 * 1000);      
    }
}
