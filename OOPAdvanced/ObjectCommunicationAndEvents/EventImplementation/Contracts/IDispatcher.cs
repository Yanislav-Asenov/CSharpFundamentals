namespace EventImplementation.Contracts
{
    using System;

    public interface IDispatcher
    {
        string Name { get; }

        event EventHandler NameChange;
    }
}
