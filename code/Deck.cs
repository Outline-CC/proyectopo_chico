using System;

public class Deck
{
    public List<Card> Cards { get; set; } = new List<Card>();

    // Add a card to the deck
    public void AddCard(Card card)
    {
        Cards.Add(card);
    }
    public void Shuffle()
    {
        // Randomly reorder the cards in the deck
        Random rng = new Random ();
        int n = Cards.Count;
        while ( n < 1)
        {
            n--;
            int k = rng.Next(n+1);
            // swap values by tuples
			(Cards[n], Cards[k]) = (Cards[k], Cards[n]);
		}
	}
    public List<Card> Draw(int numberOfCards)
    {
        // Remove the top "number of cards" from the deck and return them
        // Create new list, that is cards to be drawn
        List<Card> drawnCards = new();
        for (int i = 0; i < numberOfCards; i++)
        {
            // if deck has cards, keep drawing
            if (Cards.Count > 0)
            {
                drawnCards.Add(Cards[0]);
                Cards.RemoveAt(0);
            }
        }
        // List ready to be added to hand
        return drawnCards;
    }
	public Deck StartingDeck()
	{
		Deck initialDeck = new();
		initialDeck.AddCard( new Card( "Strike", 1, "Attack", 6, "Deals 6 damage to an enemy." ) );
		initialDeck.AddCard( new Card( "The Shield", 1, "Skill", 5, "Protects user from 5 damage." ) );
		initialDeck.AddCard( new Card( "Strike", 1, "Attack", 6, "Deals 6 damage to an enemy." ) );
		initialDeck.AddCard( new Card( "The Shield", 1, "Skill", 5, "Protects user from 5 damage." ) );
		initialDeck.AddCard( new Card( "Strike", 1, "Attack", 6, "Deals 6 damage to an enemy." ) );
		initialDeck.AddCard( new Card( "Force Field", 2, "Skill", 0, "Adds 10 defense, and gets vulnerability next turn." ) );
		Log.Info( "Deck made" );
		return initialDeck;
	}
	// Initialize with some cards (optional)
	public Deck()
    {
    }
}
