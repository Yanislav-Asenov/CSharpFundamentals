using System;
using System.Linq;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        int numberOfInputLines = int.Parse(Console.ReadLine());
        Regex rgx = new Regex(@"^(.+?);(.+?);(\d+):(\d+)$");
        OnlineRadio onlineRadio = new OnlineRadio();
        for (int i = 0; i < numberOfInputLines; i++)
        {
            try
            {
                Match currentMatch = rgx.Match(Console.ReadLine());

                string artistName = currentMatch.Groups[1].Value;
                string songName = currentMatch.Groups[2].Value;

                if (int.TryParse(currentMatch.Groups[3].Value, out int minutes) && int.TryParse(currentMatch.Groups[4].Value, out int seconds))
                {
                    onlineRadio.AddSong(new Song(artistName, songName, minutes, seconds));
                    Console.WriteLine("Song added.");
                }
                else
                {
                    throw new InvalidSongLengthException("Invalid song length.");
                }
            }
            catch (InvalidSongException ise)
            {
                Console.WriteLine(ise.Message);
            }
        }

        Console.WriteLine(onlineRadio);
    }
}

