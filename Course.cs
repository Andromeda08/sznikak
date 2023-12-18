namespace Course
{
    public delegate void StudentRegisteredDelegate(string studentName, int studentCount);
    class Course
    {
        public event StudentRegisteredDelegate StudentRegistered;
        public int StudentCount { get; set; }
        public void Register(string studentName)
        {
            StudentCount++;
            StudentRegistered(studentName, StudentCount);
        }
    }
    class App
    {
        static void Main(string[] args)
        {
            Course c = new Course();
            c.StudentRegistered += response;
            c.Register("Follow");
            c.Register("@bigfootjinx");
        }
        static void response(string studentName, int studentCount)
        {
            Console.WriteLine(studentName);
        }
    }
}
