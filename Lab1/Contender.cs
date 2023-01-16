public struct Contender
{
    public string Name { get; set; }
    public int Goodness { get; set; }

    public override string ToString()
    {
        return $"{Name}, {Goodness}";
    }
}