class Program
{
    public const int ContendersCount = 100;
    private const int MaxGoodness = ContendersCount;
    private const int MinGoodness = 50;
    private static List<Contender> contenders;
    
    private static void Shuffle<T>(IList<T> list)
    {
        var random = new Random();
        int n = list.Count;
        while (n > 1)
        {
            int k = random.Next(n--);
            (list[k], list[n]) = (list[n], list[k]);
        }
    }
    
    private static void Init()
    {
        var firstNames = new[]{"Никита", "Вадим", "Игорь", "Кирилл", "Матвей", 
            "Владимир", "Михаил", "Александр", "Максим", "Дмитрий"};
        var lastNames = new[]{"Иванов", "Петров", "Лобанов", "Киреев", "Мандрыко", 
            "Чернов", "Латыш", "Баранов", "Копылов", "Куликов"};
        int goodness = MaxGoodness;
        
        contenders = new List<Contender>();

        foreach (string firstName in firstNames)
        {
            foreach (string lastName in lastNames)
            {
                contenders.Add(new Contender { Name = $"{firstName} {lastName}", Goodness = goodness > MinGoodness ? goodness-- : 0 });
            }
        }

        Shuffle(contenders);
    }
    
    public static void Main()
    {
        Init();
        Princess.ChooseContender(contenders);
    }
}
