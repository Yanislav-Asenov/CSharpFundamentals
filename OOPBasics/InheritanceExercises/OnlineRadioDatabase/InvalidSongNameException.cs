using System;

public class InvalidSongNameException : InvalidSongException
{
    public InvalidSongNameException()
    {
    }

    public InvalidSongNameException(string message)
        : base(message)
    {
    }

    public InvalidSongNameException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
