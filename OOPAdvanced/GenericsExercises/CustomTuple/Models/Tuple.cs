public class Tuple<Item1, Item2>
{
    private Item1 item1;
    private Item2 item2;

    public Tuple(Item1 item1, Item2 item2)
    {
        this.item1 = item1;
        this.item2 = item2;
    }

    public override string ToString()
    {
        return $"{this.item1} -> {this.item2}";
    }
}