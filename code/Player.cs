using Sandbox;
using static Sandbox.PhysicsContact;
using System;

public class Player : Component
{
	public int LifePoints {get; set;}
	public int Strength {get; set;}
	public int Defense {get; set;}
	public int Energy {get; set;}
	public Deck Deck {get; set;}
	public List<Card> Hand { get; set; }
    //public Deck DrawPile { get; set; }
    public Deck DiscardPile { get; set; }

	public Player(int lifepoints, int energy)
	{
		LifePoints = lifepoints;
		Energy = energy;
		Deck = new Deck().StartingDeck();
		Strength = 0;
		Defense = 0;
		DiscardPile = new Deck();
		Hand = new List<Card>();

		Deck.Shuffle();
	}
	protected override void OnUpdate()
	{

	}

	public void StartTurn() {
		DrawCards( 4 );
	}

	private void DrawCards( int numberOfCards )
	{
		if ( Deck.Cards.Count < numberOfCards )
		{
			// Shuffle discard into draw pile if not enough cards
			Deck.Cards.AddRange( DiscardPile.Cards );
			DiscardPile.Cards.Clear();
			Deck.Shuffle();
		}
		var drawnCards = Deck.Draw( numberOfCards );
		Hand.AddRange( drawnCards );
	}

	public void PlayCard( Card card, GameObject target )
	{
		// Assuming 'card' is a card from the hand
		if ( Hand.Contains( card ) )
		{
			if (Energy >= card.EnergyCost)
			{
				// Implement the logic of using the card based on its type, effects, etc.
				Log.Info( $"Playing {card.Name} on {target.Name}" );
				Energy -= card.EnergyCost;
				// For simplicity, just remove the card from hand and add to discard pile
				Hand.Remove( card );
				DiscardPile.AddCard( card );
			}
			else
			{
				Log.Info( "Not enough energy to play card" );
			}
		}
		else
		{
			Log.Info( "Card is not in hand." );
		}
	}
	public void EndTurn()
	{
		// Move any cards left in hand to the discard pile
		foreach ( var card in Hand.ToList() ) // ToList to avoid modification during enumeration
		{
			DiscardPile.AddCard( card );
		}
		Hand.Clear();
		Energy += 3;
	}
	public void AcquireCard( Card newCard )
	{
		Deck.AddCard( newCard );
	}
}
