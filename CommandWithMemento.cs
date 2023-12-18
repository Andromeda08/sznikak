namespace WarningNoCommandProcessor;

// Probably you should consider:
// - Separate files
// - A command processor lol

interface ICommand
{
    public void Execute() {}
    public void UnExecute() {}
}
class IncrementCommand : ICommand
{
    private State _state = null;
    private StateMemento _memento = null;
    public IncrementCommand(State state)
    {
        this._state = state;
    }
    public void Execute()
    {
        _memento = _state.CreateMemento();
        _state.Increment();
    }
    public void UnExecute()
    {
        _state.RestoreFromMemento(_memento);
    }
}
class StateMemento
{
    private int _count;
    public int Count
    {
        get => _count;
        set => _count = value;
    }

    public StateMemento(int c)
    {
        this.Count = c;
    }
}
class State
{
    private ICommand _cmd = null;
    private int _counter = 0;

    public State()
    {
        _cmd = new IncrementCommand(this);
    }
    public void Count()
    {
        Console.WriteLine(_counter);
    }
    public void Increment()
    {
        _counter++;
    }
    public void DoButtonClick()
    {
        _cmd.Execute();
    }
    public void UndoButtonClick()
    {
        _cmd.UnExecute();
    }
    public StateMemento CreateMemento()
    {
        return new StateMemento(_counter);
    }
    public void RestoreFromMemento(StateMemento memento)
    {
        this._counter = memento.Count;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        State state = new State();
        state.Count();
        state.DoButtonClick();
        state.Count();
        state.UndoButtonClick();
        state.Count();
    }
}
