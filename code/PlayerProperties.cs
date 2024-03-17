using System.Text.Json;
using Sandbox;
public class PlayerProperties : Component
{
    public static void SaveDeckToFile(Deck deck)
    {
        //var options = new JsonSerializerOptions { WriteIndented = true };
		//string jsonString = JsonSerializer.Serialize( new Card( "Strike", 1, "Attack", 6, "Deals 6 damage to an enemy." ), options);
        //Log.Info(jsonString);
        //FileSystem.Data.WriteAllText("deckfile.json", jsonString);
    }

    public Deck LoadDeckFromFile()
    {
        string jsonString = FileSystem.Data.ReadAllText("deckfile.json");
        Deck deck = JsonSerializer.Deserialize<Deck>(jsonString);
        return deck;
    }

    public Deck StartingDeck(){
        Deck initialDeck = new();
        initialDeck.AddCard(new Card("Strike", 1, "Attack", 6, "Deals 6 damage to an enemy."));
        initialDeck.AddCard(new Card("The Shield", 1, "Skill", 5, "Protects user from 5 damage."));
        initialDeck.AddCard(new Card("Strike", 1, "Attack", 6, "Deals 6 damage to an enemy."));
        initialDeck.AddCard(new Card("The Shield", 1, "Skill", 5, "Protects user from 5 damage."));
        initialDeck.AddCard(new Card("Strike", 1, "Attack", 6, "Deals 6 damage to an enemy."));
        initialDeck.AddCard(new Card("Force Field", 2, "Skill", 0, "Adds 10 defense, and gets vulnerability next turn."));
		//SaveDeckToFile( initialDeck);
        Log.Info("Deck made");
        return initialDeck;
    }
}
