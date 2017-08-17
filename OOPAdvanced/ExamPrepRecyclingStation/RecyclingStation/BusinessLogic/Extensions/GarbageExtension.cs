namespace RecyclingStation.WasteDisposal.Interfaces
{
    public static class GarbageExtension
    {
        public static double GetTotalVolume(this IWaste garbage)
        {
            return garbage.Weight * garbage.VolumePerKg;
        }
    }
}
