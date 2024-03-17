using System.Text.Json;
using System.IO;
class PlayerProperties
{
    public void SaveDeckToFile(Deck deck, string filePath)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(deck, options);
        // NO JALA FILE
        //File.WriteAllText(filePath, jsonString);
    }

    // todo: replace void for Deck type
    public void LoadDeckFromFile(string filePath)
    {
        //string jsonString = File.ReadAllText(filePath);
        //Deck deck = JsonSerializer.Deserialize<Deck>(jsonString);
        //return deck;
    }
}

/*
string deckFilePath = "path/to/your/deckfile.json";

if (!File.Exists(deckFilePath))
{
    Deck initialDeck = new Deck();
    // Add initial cards to the deck
    initialDeck.AddCard(new Card("Sword Slash", 1, "Attack", "Deal 10 damage."));
    initialDeck.AddCard(new Card("Shield Up", 1, "Defense", "Gain 10 block."));
    // Add more cards as needed
    SaveDeckToFile(initialDeck, deckFilePath);
}
______________

Deck deck = LoadDeckFromFile(deckFilePath);
// Example: Add a new card
deck.AddCard(new Card("Fireball", 2, "Attack", "Deal 15 damage to all enemies."));
// Save changes
SaveDeckToFile(deck, deckFilePath);

*/