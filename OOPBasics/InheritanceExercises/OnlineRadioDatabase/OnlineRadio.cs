using System.Collections.Generic;
using System.Linq;
using System.Text;

public class OnlineRadio
{
    private List<Song> songs;

    public OnlineRadio()
    {
        this.songs = new List<Song>();
    }

    public void AddSong(Song song)
    {
        this.songs.Add(song);
    }

    public override string ToString()
    {
        int totalSeconds = songs.Sum(s => s.LengthInSeconds);
        int totalHours = totalSeconds / 60 / 60;
        totalSeconds = totalSeconds - (totalHours * 60 * 60);

        int totalMinutes = totalSeconds / 60;
        int totalSecods = totalSeconds % 60;

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Songs added: {this.songs.Count}");
        sb.Append($"Playlist length: {totalHours}h {totalMinutes}m {totalSecods}s");

        return sb.ToString();
    }
}

