using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class JobCollection
{
    private IDictionary<string, IJob> jobsByName;

    public JobCollection()
    {
        this.jobsByName = new Dictionary<string, IJob>();
    }

    public void Add(IJob job)
    {
        this.jobsByName.Add(job.Name, job);
        job.JobDone += this.OnJobDone;
    }

    public string GetJobsStatus()
    {
        StringBuilder result = new StringBuilder();
        foreach (var job in this.jobsByName)
        {
            result.AppendLine(job.Value.ToString());
        }

        return result.ToString().Trim();
    }

    public void PassWeek()
    {
        foreach (var job in this.jobsByName)
        {
            job.Value.Update();
        }

        this.jobsByName = this.jobsByName.Where(j => !j.Value.IsJobDone).ToDictionary(x => x.Key, x => x.Value);
    }

    private void OnJobDone(object sender, EventArgs e)
    {
        if (sender is IJob job)
        {
            Console.WriteLine($"Job {job.Name} done!");
            job.JobDone -= this.OnJobDone;
        }
    }
}