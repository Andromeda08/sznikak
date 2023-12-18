namespace Program
{
    public delegate void ChangedDelegate(int x, int y);
    class Person
    {
        public event ChangedDelegate AgeChanged;
        private int _age;
        public int Age
        {
            get { return _age; }
            set { 
                if (_age != value)
                {
                    AgeChanged?.Invoke(_age, value);
                }
                _age = value;
            }
        }
        public Person(int age)
        {
            _age = age;
        }
    }

    class Program
    {
        public static void Main(String[] args)
        {
            Person person = new Person(18);
            person.AgeChanged += Event;
            person.Age = 19;
        }

        private static void Event(int old_age, int new_age)
        {
            Console.WriteLine("Old {0} | New {1}", old_age, new_age);
        }
    }
}
