using System;

public class InvalidSongSecondsException : InvalidSongLengthException
{
    public InvalidSongSecondsException()
    {
    }

    public InvalidSongSecondsException(string message)
        : base(message)
    {
    }

    public InvalidSongSecondsException(string message, Exception inner)
        : base(message, inner)
    {
    }
}

