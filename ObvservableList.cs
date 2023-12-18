namespace BigNamespace
{
    public delegate void Added(int item, int count);
    public class ObservableList
    {
        private List<int> _items = new List<int>();
        public event Added addEvent;
        public void Add(int item)
        {
            _items.Add(item);
            addEvent?.Invoke(item, _items.Count);
        }
        public int ElementAt(int idx)
        {
            return _items[idx];
        }
    }
    public class Program
    { 
        static void Main(String[] args)
        {
            ObservableList list = new ObservableList();
            list.addEvent += EventFn;
            list.Add(1);
            list.Add(2);
        }
        static void EventFn(int item, int count)
        {
            Console.WriteLine("Added {0} | Size {1}", item, count);
        }
    }
}