public class Song
{
    private string artistName;
    private string songName;
    private int seconds;
    private int minutes;
    private int lengthInSeconds;

    public Song(string artistName, string songName, int minutes, int seconds)
    {
        this.ArtistName = artistName;
        this.SongName = songName;
        this.Minutes = minutes;
        this.Seconds = seconds;
        this.LengthInSeconds = (minutes * 60) + seconds;
    }

    public string ArtistName
    {
        get { return this.artistName; }
        set
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new InvalidArtistNameException("Artist name should be between 3 and 20 symbols.");
            }

            this.artistName = value;
        }
    }

    public string SongName
    {
        get { return this.songName; }
        set
        {
            if (value.Length < 3 || value.Length > 30)
            {
                throw new InvalidSongNameException("Song name should be between 3 and 30 symbols.");
            }

            this.songName = value;
        }
    }

    public int Minutes
    {
        get { return this.minutes; }
        set
        {
            if (value < 0 || value > 14)
            {
                throw new InvalidSongMinutesException("Song minutes should be between 0 and 14.");
            }

            this.minutes = value;
        }
    }

    public int Seconds
    {
        get { return this.seconds; }
        set
        {
            if (value < 0 || value > 59)
            {
                throw new InvalidSongSecondsException("Song seconds should be between 0 and 59.");
            }

            this.seconds = value;
        }
    }

    public int LengthInSeconds
    {
        get
        {
            return this.lengthInSeconds;
        }

        set
        {
            if (value > 899 || value < 0)
            {
                throw new InvalidSongLengthException("Invalid song length.");
            }

            this.lengthInSeconds = value;
        }
    }
}

