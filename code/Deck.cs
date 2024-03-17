public class Deck
{
    public List<Card> Cards { get; set; } = new List<Card>();

    // Add a card to the deck
    public void AddCard(Card card)
    {
        Cards.Add(card);
    }

    // Initialize with some cards (optional)
    public Deck()
    {
        // Example cards added to the deck upon initialization
        AddCard(new Card("Attack", 1, "Deal 5 damage."));
        AddCard(new Card("Defend", 1, "Gain 5 block."));
        Log.Info( Cards );
        // Add more cards as needed
    }
}
