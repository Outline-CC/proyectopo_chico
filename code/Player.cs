using Sandbox;

public sealed class Player : Component
{
	public int LifePoints {get; set;}
	public int Strength {get; set;}
	public int Defense {get; set;}
	public int Energy {get; set;}
	public Deck MyDeck {get; set;}

	public Player(int lp, int en, Deck deck)
	{
		LifePoints = lp;
		Energy = en;
		MyDeck = deck;
	}

	public void PlayCard(Card card, Enemy enemy)
	{
		Log.Info("Card: " + card.Name + "/" + card.EnergyCost + "/" + card.Description);
		Log.Info("Energy: " + Energy + "Cost: " + card.EnergyCost);
		if(Energy >= card.EnergyCost)
		{
			card.PlayEffect(this, enemy);
			Energy -= card.EnergyCost;
		}
		else
		{
			Log.Info( "Not enough energy!" );
		}
	}

	protected override void OnUpdate()
	{

	}
}