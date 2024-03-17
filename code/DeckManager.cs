using System;
public class DeckManager : Component
{
    // Deck Manager will add new card prefabs to the scene.
    // Start by adding one to the scene.
    [Property]
    GameObject CardPrefab { get; set; }
    public List<GameObject> Cards { get; set; } = new List<GameObject>();
    public int[] positions = {950, 650, 350, 50, -250, -550};
    public PlayerProperties pp = new();
    public Deck deck = new();
	protected override void OnStart()
	{
		Log.Info(deck.Cards.Count);
        deck = pp.StartingDeck();
        Log.Info(deck.Cards.Count);
	}
	// Assign a gameobject to the predetermined deck
	/*
	protected override void OnUpdate()
    {
        if (Input.Pressed("Attack2"))
        {
           if(Cards.Count<6)
           {
            GameObject cardInstance = CardPrefab.Clone(Transform.Position);
            Log.Info(cardInstance.Transform.Rotation.x);
            cardInstance.Transform.Rotation *= Rotation.FromPitch(-90);
            cardInstance.Transform.Rotation *= Rotation.FromYaw(180);
            cardInstance.Transform.Position += new Vector3(0,positions[Cards.Count],-370);
            cardInstance.BreakFromPrefab();
            // add properties to cardInstance
            cardInstance.Components.Get<CardObject>( FindMode.EverythingInSelf )
				.SetProperties("Strike", 1, "Attack", "Le pega bien duro");
            // add card to deck
            Cards.Add(cardInstance);
            Log.Info(Cards.Count);
           }
        }
    }
    */
}

class DeckMain {
    public List<Card> ConsoleCards { get; set; } = new List<Card>();
    // Shuffle cards in deck
    public void Shuffle()
    {
        // Randomly reorder the cards in the deck
        Random rng = new Random ();
        int n = ConsoleCards.Count;
        while ( n < 1)
        {
            n--;
            int k = rng.Next(n+1);
            // swap values by tuples
			(ConsoleCards[n], ConsoleCards[k]) = (ConsoleCards[k], ConsoleCards[n]);
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
            if (ConsoleCards.Count > 0)
            {
                drawnCards.Add(ConsoleCards[0]);
                ConsoleCards.RemoveAt(0);
            }
        }
        // List ready to be added to hand
        return drawnCards;
    }
    public void AddCard(Card card)
    {
        // Add a new card to the deck
        ConsoleCards.Add(card);
    }
}

class PlayerOne
{
    // hand: List<Card>
    public List<Card> Hand { get; set; }
    // draw_pile: Deck
    public DeckMain DrawPile { get; set; }
    // discard_pile: Deck
    public DeckMain DiscardPile { get; set; }

    public PlayerOne(DeckMain startingDeck)
    {
		DrawPile = new DeckMain
		{
			ConsoleCards = new List<Card>( startingDeck.ConsoleCards ) // Clone starting deck to draw pile
		};
		DrawPile.Shuffle();

        DiscardPile = new DeckMain();
        Hand = new List<Card>();
    }
	void StartTurn() =>
		// Draw a predetermined number of cards from the draw pile to the hand
		// Example: Draw 5 cards drawn_cards = draw_pile.draw(5) 
		// hand.extend(drawn_cards)
		Hand.AddRange( DrawPile.Draw( 5 ) );
	void PlayCard() {
        // Play a card from the hand
        // card.use(target)
        // hand.remove(card)
        // discard_pile.add_card(card) // Add the played card to the discard pile
    }
    void EndTurn() {
        // Move unused cards to the discard pile
        // for cards in hand: discard_pile.add_card(card)
        // hand.clear()
        // Shuffle discard pile back into deck if draw pile is empty
    }
    void AcquireCard(){
        // Add a new card to the discard pile (or draw pile, depending on game rules)
        // discard_pile.add_card(new_card)
    }
}

class GameSetup {
    
    void SetupGame(){
        // Initialize player's deck with basic cards
        //
        // initialize_class = [List of initial Card objects]
        // player = Player()
        // player.draw_pile.cards = initial_cards
        // player.draw_pule.shuffle()
        //
        // while not game_over:
        //  player.start_turn()
        //
        // Player chooses cards to play during their turn
        // Implement game logic for choosing and playing cards
        //
        // player.end_turn()
        // Check for game over conditions
        //
    }
 
}