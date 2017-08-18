public class Wizard : AbstractHero
{
    private const int WizardDefaultStrength = 25;
    private const int WizardDefaultAgility = 25;
    private const int WizardDefaultIntelligence = 100;
    private const int WizardDefaultHitPoints = 100;
    private const int WizardDefaultDamage = 250;

    public Wizard(string name)
        : base(
            name,
            WizardDefaultStrength,
            WizardDefaultAgility,
            WizardDefaultIntelligence,
            WizardDefaultHitPoints,
            WizardDefaultDamage)
    {
    }
}