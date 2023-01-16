namespace Lab2;

interface IHall
{
    public int GetContendersNumber();
    public int GetContendersCounter();
    public string? GetNextContender();
    public CompareValue AskFreind(int contenderA, int contenderB);
    public void PublishResult(string? chosenContender);
}

class Hall : IHall
{
    private IContenderGenerator _contenderGenerator;
    private IFreind _freind;

    private List<Contender> _contenderPool = new();
    private List<string> _contenderNames = new();
    private int _currentContender = -1;

    public Hall(IContenderGenerator contenderGenerator, IFreind freind)
    {
        _contenderGenerator = contenderGenerator;
        _contenderPool.AddRange(_contenderGenerator.Generate());
        _contenderNames.AddRange(_contenderPool.Select(contender => contender.Name));
        _freind = freind;
    }

    public int GetContendersNumber() => _contenderPool.Count;

    public int GetContendersCounter() => _currentContender;

    public string? GetNextContender()
    {
        _currentContender++;
        if (_currentContender >= _contenderNames.Count)
        {
            return null;
        }

        _freind.LearnContender(_contenderPool[_currentContender]);

        Console.WriteLine(_contenderPool[_currentContender].ToString());
        return _contenderNames[_currentContender];
    }

    public void PublishResult(string? chosenContender)
    {
        Console.WriteLine("---");
        Console.WriteLine($"{CountGoodness(chosenContender)}");
    }

    private int CountGoodness(string? chosenContender) => chosenContender != null
        ? _contenderPool[_currentContender].Goodness
        : ContenderGenerator.AloneGoodness;

    public CompareValue AskFreind(int contenderA, int contenderB) => _freind.Compare(_contenderPool[contenderA],
        _contenderPool[contenderB]);
}