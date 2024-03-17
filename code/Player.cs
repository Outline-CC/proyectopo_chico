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

	public Player()
	{
		LifePoints = 100;
		Energy = 0;
		Deck = new Deck().StartingDeck();
		Strength = 0;
		Defense = 0;
		DiscardPile = new Deck();
		Hand = new List<Card>();

		Deck.Shuffle();
	}

	public void StartTurn() {
		Log.Info("Start turn");
		Energy += 3;
		Deck.Shuffle();
		DrawCards( 5 );
	}

	private void DrawCards( int numberOfCards )
	{
		Log.Info( "DRAW CARDS" );
		if ( Deck.Cards.Count < numberOfCards )
		{
			// Shuffle discard into draw pile if not enough cards
			Deck.Cards.AddRange( DiscardPile.Cards );
			DiscardPile.Cards.Clear();
			Deck.Shuffle();
		}
		List<Card> drawnCards = Deck.Draw( numberOfCards );
		int i = 1;
		foreach ( var card in drawnCards )
		{
			string objName = "CARD " + i.ToString();
			i++;
			//Log.Info(objName);
			//Log.Info(Scene.Directory.FindByName(objName));
			Scene.Children.Find(x => x.Name == objName)
			.Components.Get<Card>(FindMode.EverythingInSelf)
			.SetData(card.Name, card.EnergyCost, card.Type, card.EffectImpact, card.Description);
			//Log.Info(Scene.Children.Find(x => x.Name == objName)
			//.Components.Get<Card>(FindMode.EverythingInSelf).Name);

		}
		Hand.AddRange( drawnCards );
	}

	public void PlayCard( GameObject card, GameObject target )
	{
		Log.Info( "PLAY CARDS" );
		Card playCard = card.Components.Get<Card>();
		Enemy playEnemy = target.Components.Get<Enemy>();
		// Assuming 'card' is a card from the hand
		//if ( Hand.Contains( playCard ) )
		//{
			if (Energy >= playCard.EnergyCost)
			{
				// Implement the logic of using the card based on its type, effects, etc.
				Log.Info( $"Playing {playCard.Name} on {playEnemy.Name}" );
				Energy -= playCard.EnergyCost;
				// For simplicity, just remove the card from hand and add to discard pile
				Hand.Remove( playCard );
				DiscardPile.AddCard( playCard );
				card.Destroy();
				Log.Info( $"Player energy left: {Energy}" );
			}
			else
			{
				Log.Info( "Not enough energy to play card" );
			}
		//}
		//else
		//{
		//	Log.Info( "Card is not in hand." );
		//}
	}
	public void EndTurn()
	{
		Log.Info( "END TURN" );
		// Move any cards left in hand to the discard pile
		foreach ( var card in Hand.ToList() ) // ToList to avoid modification during enumeration
		{
			DiscardPile.AddCard( card );
		}
		Hand.Clear();
	}
	public void AcquireCard( Card newCard )
	{
		Log.Info( "ACQUIRE CARD" );
		Deck.AddCard( newCard );
	}
}
