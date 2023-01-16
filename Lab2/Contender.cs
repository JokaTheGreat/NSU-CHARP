namespace Lab2;

public readonly struct Contender
{
    public string Name { get; }
    public int Goodness { get; }

    public Contender(string name, int goodness)
    {
        Name = name;
        Goodness = goodness;
    }

    public override string ToString()
    {
        return $"{Name}, {Goodness}";
    }
}