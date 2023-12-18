namespace Singleton;

// Lazy Instantiation: Create instance on first GetInstance call.
class LazyInstantiation
{
    private static LazyInstantiation instance = null;

    protected LazyInstantiation()
    {
        Console.WriteLine("Lazily creating instance 🥱");
    }
    public static LazyInstantiation GetInstance()
    {
        if (instance == null)
        {
            instance = new LazyInstantiation();
        }

        return instance;
    }

    public void Operation()
    {
        Console.WriteLine("LI nop");
    }
}

// This is "Thread Safe™"
class EagerInstantation
{
    private static EagerInstantation instance = new EagerInstantation();

    protected EagerInstantation()
    {
        Console.WriteLine("Eager to exist.");
    }
    public static EagerInstantation GetInstance()
    {
        return instance;
    }
    public void Operation() {
        Console.WriteLine("EI nop");
    }
}

class Program
{
    public static void Main(string[] args)
    {
        LazyInstantiation.GetInstance().Operation();
        LazyInstantiation.GetInstance().Operation();
        EagerInstantation.GetInstance().Operation();
    }
}
