using Sandbox;

public class Card : Component
{
	[Property]
	public string Name { get; set; }
	[Property]
	public int EnergyCost { get; set; }
	[Property]
	public string Description { get; set; }
	[Property]
	public string Type { get; set; }
	[Property]
	public int EffectImpact { get; set; }

	// Constructor
    /*public Card(string name, int energyCost, string type, int effectImpact, string description)
    {
        Name = name;
        EnergyCost = energyCost;
        Type = type;
        EffectImpact = effectImpact;
        Description = description;
    }*/
	public Card()
	{
		Name = "Strike";
		EnergyCost = 1;
		Type = "Attack";
		EffectImpact = 6;
		Description = "Lorem Ipsum";
	}
	public void SetData( string name, int energyCost, string type, int effectImpact, string description )
	{
		Name = name;
		EnergyCost = energyCost;
		Type = type;
		EffectImpact = effectImpact;
		Description = description;
	}
}
