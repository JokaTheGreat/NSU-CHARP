class Freind
{
    public static CompareValue Compare(List<Contender> contenders, int contenderAId, int contenderBId, int currentContenderId)
    {
        if (currentContenderId < contenderAId || currentContenderId < contenderBId)
        {
            return CompareValue.Idk;
        }

        return contenders[contenderAId].Goodness < contenders[contenderBId].Goodness ? CompareValue.Worse : CompareValue.Better;
    }
}