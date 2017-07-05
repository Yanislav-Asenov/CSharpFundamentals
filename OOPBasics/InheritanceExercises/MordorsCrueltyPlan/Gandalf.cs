public class Gandalf
{
    public int TotalPointsOfHappiness { get; set; }

    public void Eat(Food food)
    {
        this.TotalPointsOfHappiness += food.PointsOfHappiness;
    }
}

