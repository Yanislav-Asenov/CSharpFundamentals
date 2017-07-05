using System;

public class InvalidSongException : Exception
{
    public InvalidSongException()
    {
    }

    public InvalidSongException(string message)
        : base(message)
    {
    }

    public InvalidSongException(string message, Exception inner)
        : base(message, inner)
    {
    }
}

