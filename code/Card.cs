using Sandbox;

public class Card : Component
{
    public string Name { get; set; }
	public int EnergyCost { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public int EffectImpact { get; set; }

	// Constructor
    public Card(string name, int energyCost, string type, int effectImpact, string description)
    {
        Name = name;
        EnergyCost = energyCost;
        Type = type;
        EffectImpact = effectImpact;
        Description = description;
    }
}
