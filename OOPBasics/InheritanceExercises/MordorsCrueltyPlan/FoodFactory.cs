public class FoodFactory
{
    public Food CreateFood(string foodName)
    {
        foodName = foodName.ToLower();
        int pointsOfHappiness = -1;
        switch (foodName)
        {
            case "cram":
                pointsOfHappiness = 2;
                break;
            case "lembas":
                pointsOfHappiness = 3;
                break;
            case "apple":
                pointsOfHappiness = 1;
                break;
            case "melon":
                pointsOfHappiness = 1;
                break;
            case "honeycake":
                pointsOfHappiness = 5;
                break;
            case "mushrooms":
                pointsOfHappiness = -10;
                break;
        }

        return new Food(pointsOfHappiness);
    }
}

