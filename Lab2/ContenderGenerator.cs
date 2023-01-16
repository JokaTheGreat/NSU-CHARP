namespace Lab2;

interface IContenderGenerator
{
    public List<Contender> Generate();
}

public class ContenderGenerator : IContenderGenerator
{
    private const int ContendersCount = 100;
    private const int MaxGoodness = ContendersCount;
    private const int MinGoodness = 50;
    public const int AloneGoodness = 10;

    private readonly string[] _contenderFirstNames =
    {
        "Никита", "Вадим", "Игорь", "Кирилл", "Матвей",
        "Владимир", "Михаил", "Александр", "Максим", "Дмитрий"
    };

    private readonly string[] _contenderLastNames =
    {
        "Иванов", "Петров", "Лобанов", "Киреев", "Мандрыко",
        "Чернов", "Латыш", "Баранов", "Копылов", "Куликов"
    };

    private List<Contender> _contenderList = new();

    public List<Contender> Generate()
    {
        for (int i = 0; i < ContendersCount; i++)
        {
            int currentGoodness = MaxGoodness - i > MinGoodness ? MaxGoodness - i : 0;
            _contenderList.Add(new Contender($"{_contenderFirstNames[i % 10]} {_contenderLastNames[i / 10]}",
                currentGoodness));
        }

        ShuffleContenders();

        return _contenderList;
    }

    private void ShuffleContenders()
    {
        var random = new Random();
        int n = _contenderList.Count;
        while (n > 1)
        {
            int k = random.Next(n--);
            (_contenderList[k], _contenderList[n]) = (_contenderList[n], _contenderList[k]);
        }
    }
}