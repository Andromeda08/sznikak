namespace CatRPG {
    public delegate void KittenEvent(int happiness_factor);
    class Kitten
    {
        public event KittenEvent KittenPurrEvent;
        private int _happiness_factor;
        public int Count
        {
            get { return _happiness_factor; }
            set
            {
                _happiness_factor = value;
                if (_happiness_factor >= 12)
                {
                    KittenPurrEvent(Count);
                }
            }
        }

        public void Stroke()
        {
            Count += 3;
            Console.WriteLine("The kitten relishes in enjoyment as you stroke it...");
        }
        public void Feed()
        {
            Count += 4;
            Console.WriteLine("As you feed the kitten it grows ever so slightly...");
        }
    }
    class App
    {
        static void Main()
        {
            Kitten kitten = new Kitten();
            kitten.KittenPurrEvent += announce_purr;
            kitten.Stroke();
            kitten.Feed();
            kitten.Stroke();
            kitten.Feed();
        }

        static void announce_purr(int happiness_factor)
        {
            Console.WriteLine("The kitten purrrrrrrrrrrs....\nIt's very satisfied.");
        }
    }
}
