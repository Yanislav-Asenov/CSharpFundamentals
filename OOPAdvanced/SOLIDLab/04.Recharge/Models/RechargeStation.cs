namespace _04.Recharge.Models
{
    using _04.Recharge.Contracts;

    public class RechargeStation
    {
        public void Recharge(IRechargeable rechargeable)
        {
            rechargeable.Recharge();
        }
    }
}