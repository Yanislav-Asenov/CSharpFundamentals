public class MoodFactory
{
    public Mood CreateMood(int pointsOfHappiness)
    {
        string moodName = string.Empty;

        if (pointsOfHappiness < -5)
        {
            moodName = "Angry";
        }
        else if (pointsOfHappiness <= 0)
        {
            moodName = "Sad";
        }
        else if (pointsOfHappiness <= 15)
        {
            moodName = "Happy";
        }
        else
        {
            moodName = "JavaScript";
        }

        return new Mood(moodName);
    }
}

