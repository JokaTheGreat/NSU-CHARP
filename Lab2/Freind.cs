namespace Lab2;

interface IFreind
{
    public void LearnContender(Contender contender);
    public CompareValue Compare(Contender contenderA, Contender contenderB);
}

class Freind : IFreind
{
    private List<Contender> _familiarContenders = new();

    public void LearnContender(Contender contender) => _familiarContenders.Add(contender);

    public CompareValue Compare(Contender contenderA, Contender contenderB)
    {
        if (!_familiarContenders.Contains(contenderA) || !_familiarContenders.Contains(contenderB))
        {
            return CompareValue.Idk;
        }

        return contenderA.Goodness < contenderB.Goodness ? CompareValue.Worse : CompareValue.Better;
    }
}