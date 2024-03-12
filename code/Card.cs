using Sandbox;

public sealed class Card : Component
{
	public string Name { get; set; }
	public int EnergyCost { get; set; }
    public string Description { get; set; }

	// Constructor
    public Card(string name, int energyCost, string description)
    {
        Name = name;
        EnergyCost = energyCost;
        Description = description;
    }

    // Example Effect Method
    public void PlayEffect(Player player, Enemy enemy)
    {
        Log.Info("Card was played");
    }
}