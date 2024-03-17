using Sandbox;

public sealed class Enemy : Component
{
	public string Name { get; set; }
	public int LifePoints {get; set;}
	public int Strength {get; set;}
	public int Defense {get; set;}
	public int Energy {get; set;}
	public Deck MyDeck {get; set;}

	public Enemy()
	{
		Name = "Juan";
		LifePoints = 20;
		Energy = 3;
		MyDeck = new Deck();
	}

	protected override void OnUpdate()
	{

	}
}
