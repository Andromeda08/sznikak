namespace Program
{
    public delegate void YearOfBirthChanged();
    public class Person
    {
        public event YearOfBirthChanged YearOfBirthChanged;
        private int yearOfBirth;
        public int YearOfBirth {
            get { return yearOfBirth; }
            set
            {
                if (value >= 1900)
                {
                    yearOfBirth = value;
                    YearOfBirthChanged();
                }
            }
        } 
        public int Age {
            get {
                // Why limit yourself to fixed Year, when you can see sharp?
                return DateTime.Now.Year - yearOfBirth;
            }
        }
        
        public Person(int yob)
        {
            YearOfBirthChanged += pain;
            this.yearOfBirth = yob;
        }

        static void pain()
        {
            Console.WriteLine("HOW");
        }
    }
    public class App
    {
        static void Main(string[] args)
        {
            Person p1 = new Person(2001);
            Person p2 = new Person(2012);
            p1.YearOfBirth = 2004;
        }
    }
}
