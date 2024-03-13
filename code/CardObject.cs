using Sandbox;

public sealed class CardObject : Component
{
    public string Name { get; set; }
	public int EnergyCost { get; set; }
    public string Description { get; set; }

	// Constructor
   public void SetProperties(string name, int energyCost, string description)
    {
        Name = name;
        EnergyCost = energyCost;
        Description = description;
    }

    public void ReadProperties()
    {
        Log.Info("Card values: " + Name + "/" + EnergyCost + "/" + Description);
    }

    // Example Effect Method
    public void PlayEffect(Player player, Enemy enemy)
    {
        Log.Info("Card was played");
    }
}