using System.Collections.Generic;
using System.Text;

public abstract class Race
{
    private const int FirstPlacePrizePercents = 50;
    private const int SecondPlacePrizePercents = 30;
    private const int ThirdPlacePrizePercents = 20;

    private int length;
    private string route;
    protected int prizePool;
    protected IDictionary<int, Car> participants = new Dictionary<int, Car>();

    protected Race(int length, string route, int prizePool)
    {
        this.length = length;
        this.route = route;
        this.prizePool = prizePool;
    }

    public IDictionary<int, Car> Participants => this.participants;
    protected int FirstPlaceMoney => (this.prizePool * FirstPlacePrizePercents) / 100;
    protected int SecondPlaceMoney => (this.prizePool * SecondPlacePrizePercents) / 100;
    protected int ThirdPlaceMoney => (this.prizePool * ThirdPlacePrizePercents) / 100;

    protected abstract IList<Car> Winners { get; }

    public abstract int GetCarPerformance(Car car);

    public void AddParicipant(int id, Car participant)
    {
        this.participants.Add(id, participant);
    }

    public bool CanStartRace()
    {
        return this.participants.Count > 0;
    }

    public string StartRace()
    {
        StringBuilder raceResult = new StringBuilder();
        raceResult.AppendLine($"{this.route} - {this.length}");

        for (int i = 0; i < this.Winners.Count; i++)
        {
            var car = this.Winners[i];
            int moneyWon = 0;

            if (i == 0)
            {
                moneyWon = this.FirstPlaceMoney;
            }
            else if (i == 1)
            {
                moneyWon = this.SecondPlaceMoney;
            }
            else
            {
                moneyWon = this.ThirdPlaceMoney;
            }

            raceResult.AppendLine($"{i + 1}. {car.Brad} {car.Model} {this.GetCarPerformance(car)}PP - ${moneyWon}");
        }

        return raceResult.ToString().Trim();
    }
}