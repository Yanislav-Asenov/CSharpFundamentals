using System;

public class InvalidArtistNameException : InvalidSongException
{
    public InvalidArtistNameException()
    {
    }

    public InvalidArtistNameException(string message)
        : base(message)
    {
    }

    public InvalidArtistNameException(string message, Exception inner)
        : base(message, inner)
    {
    }
}

