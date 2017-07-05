using System;

public class InvalidSongMinutesException : InvalidSongLengthException
{
    public InvalidSongMinutesException()
    {
    }

    public InvalidSongMinutesException(string message)
        : base(message)
    {
    }

    public InvalidSongMinutesException(string message, Exception inner)
        : base(message, inner)
    {
    }
}

