using System;

public class InvalidSongLengthException : InvalidSongException
{
    public InvalidSongLengthException()
    {
    }

    public InvalidSongLengthException(string message)
        : base(message)
    {
    }

    public InvalidSongLengthException(string message, Exception inner)
        : base(message, inner)
    {
    }
}

