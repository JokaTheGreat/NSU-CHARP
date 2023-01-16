class Princess
{
    private const int AloneGoodness = 10;
    private const double FirstContendersSkipCount = Program.ContendersCount * 0.37;
    private const double ContenderToStopFactor = 2 * 0.93;
    public static int ChooseContender(List<Contender> contenders)
    {
        int i;
        for (i = 0; i < Program.ContendersCount; i++)
        {
            Console.WriteLine(contenders[i].ToString());
            if (i > FirstContendersSkipCount)
            {
                int compareCount = 0;
                for (int j = 0; j < i; j++)
                {
                    compareCount += (int) Freind.Compare(contenders, i, j, i);
                }

                if (i * ContenderToStopFactor <= compareCount) break;
            }
        }

        var resultGoodness = i != 100 ? contenders[i].Goodness : AloneGoodness;
        Console.WriteLine("---");
        Console.WriteLine($"{resultGoodness}");
        return resultGoodness;
    }
}