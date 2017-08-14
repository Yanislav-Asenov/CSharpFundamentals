using System;

public class Handler
{
    public void SubscribeToDispatcher(IDispatcher dispatcher)
    {
        dispatcher.NameChange += OnDispatcherNameChange;
    }

    private void OnDispatcherNameChange(object sender, EventArgs e)
    {
        if (sender is Dispatcher s && e is NameChangeEventArgs eventArgs)
        {
            Console.WriteLine($"Dispatcher's name changed to {eventArgs.Name}.");
        }
    }
}