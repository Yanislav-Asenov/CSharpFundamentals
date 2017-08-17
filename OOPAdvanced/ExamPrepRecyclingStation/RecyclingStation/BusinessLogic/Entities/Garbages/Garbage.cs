namespace RecyclingStation.Entities.Garbages
{
    using RecyclingStation.WasteDisposal.Interfaces;

    public abstract class Garbage : IWaste
    {
        private string name;
        private double volumePerKg;
        private double weight;

        protected Garbage(string name, double weight, double volumePerKg)
        {
            this.Name = name;
            this.Weight = weight;
            this.VolumePerKg = volumePerKg;
        }

        public string Name
        {
            get => this.name;
            private set => this.name = value;
        }

        public double VolumePerKg
        {
            get => this.volumePerKg;
            private set => this.volumePerKg = value;
        }

        public double Weight
        {
            get => this.weight;
            private set => this.weight = value;
        }
    }
}
