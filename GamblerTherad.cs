class Program
{
    static ManualResetEvent m_ResetEvent = new ManualResetEvent(false);
    static object lockobj = new object();
    static bool to_exit = false;
    static int answer;
    static void Main()
    {
        Thread g1 = new Thread(() => hopeless_gambler("t1"));
        Thread g2 = new Thread(() => hopeless_gambler("t2"));
        g1.Start();
        g2.Start();

        answer = new Random().Next(99);
        m_ResetEvent.Set();
    }

    static void hopeless_gambler(string name)
    {
        m_ResetEvent.WaitOne();
        while (!to_exit)
        {
            lock (lockobj) {
                int guess = new Random().Next(99);
                if (guess == answer)
                {
                    Console.WriteLine("I win - " + name);
                    to_exit = true;
                }
                else
                {
                    Console.WriteLine(guess + " - " + name);
                }
            }
            Thread.Sleep(500);
        }
    }

}
