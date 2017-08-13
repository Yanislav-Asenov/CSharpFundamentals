namespace EventImplementation.Models
{
    using System;
    using EventImplementation.Contracts;

    public delegate void NameChangeEventHandler(object sender, EventArgs e);

    public class Dispatcher : IDispatcher
    {
        private string name;

        public Dispatcher()
        {

        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(this.Name));
                }

                this.OnNameChnage(new NameChangeEventArgs(value));
                this.name = value;
            }
        }

        public event EventHandler NameChange;

        private void OnNameChnage(NameChangeEventArgs args)
        {
            this.NameChange(this, args);
        }
    }
}
