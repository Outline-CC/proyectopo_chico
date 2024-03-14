using Sandbox;

public sealed class CardObject : Component
{
    public string Name { get; set; }
	public int EnergyCost { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }

	// Constructor
   public void SetProperties(string name, int energyCost, string type, string description)
    {
        Name = name;
        EnergyCost = energyCost;
        Type = type;
        Description = description;
    }

    public void ReadProperties()
    {
        Log.Info("Card values: " + Name + "/" + EnergyCost + "/"  + Type + "/" + Description);
    }

    // Example Effect Method
    public void PlayEffect(Player player, Enemy enemy)
    {
        Log.Info("Card was played");
    }
}