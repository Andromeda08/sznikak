namespace FatNamespace
{
    public delegate void Change(int a, int b);
    public class Square
    {
        public event Change ChangeEvnt;
        private int _side;
        public int Side
        {
            get { return _side; }
            set
            {
                if (_side != value)
                {
                    ChangeEvnt?.Invoke(_side, value);
                }
                _side = value;
            }
        }
    }
    public class Program
    {
        static void Main(String[] args)
        {
            Square s = new Square();
            s.ChangeEvnt += Thing;
            s.Side = 1;
        }
        static void Thing(int a, int b)
        {
            Console.WriteLine("{0} -> {1}", a, b);
        }
    }
}