using System;
using System.Text;

public class Mission : IMission
{
    private string codeName;
    private string state;

    public Mission(string codeName, string state)
    {
        this.CodeName = codeName;
        this.State = state;
    }

    public string CodeName
    {
        get => this.codeName;
        private set => this.codeName = value;
    }

    public string State
    {
        get => this.state;
        private set
        {
            if (value != "inProgress" && value != "Finished")
            {
                throw new ArgumentException("Invalid mission state");
            }

            this.state = value;
        }
    }

    public void CompleteMission()
    {
        this.State = "Finished";
    }

    public override string ToString()
    {
        return $"Code Name: {this.CodeName} State: {this.State}";
    }
}