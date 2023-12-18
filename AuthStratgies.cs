/*
 * Strategy Design Patten Example:
 * (Very much unsafe) Authentication strategies.
 */

namespace StrategyExample;

interface IStrategy
{
    public bool Authenticate(String username, String password)
    {
        return false;
    }
}

class LocalStrategy : IStrategy
{
    public bool Authenticate(String username, String password)
    {
        if (username.Equals("Andromeda") && password.Equals("Password1!"))
        {
            return true;
        }

        return false;
    }
}

class GithubStrategy : IStrategy
{
    private String _apiToken;

    public GithubStrategy(String apiToken)
    {
        _apiToken = apiToken;
    }
    public bool Authenticate(String username, String password)
    {
        return BogusServiceFunction(_apiToken, username, password);
    }

    private bool BogusServiceFunction(String apiToken, String username, String password)
    {
        return (_apiToken == "ActualToken");
    }
}

class Program
{
    public static void Main(string[] args)
    {
        IStrategy AuthStrategy = new LocalStrategy();
        if (AuthStrategy.Authenticate("Andromeda", "password1!"))
        {
            Console.WriteLine("User authenticated.");
        }

        AuthStrategy = new GithubStrategy("Safely(DefinitelyNotHardcoded)StoredToken");
        if (!AuthStrategy.Authenticate("Andromeda", "password1!"))
        {
            Console.WriteLine("Unfortunately that didn't work.");
        }
    }
}
