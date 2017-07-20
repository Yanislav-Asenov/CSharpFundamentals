public class Robot : IRobot
{
    private string id;
    private string model;

    public Robot(string model, string id)
    {
        this.Model = model;
        this.Id = id;
    }

    public string Model
    {
        get => this.model;
        set => this.model = value;
    }

    public string Id
    {
        get => this.id;
        set => this.id = value;
    }
}