using System;
public class DeckManager : Component
{
    // Deck Manager will add new card prefabs to the scene.
    // Start by adding one to the scene.
    [Property]
    GameObject CardPrefab { get; set; }
    public List<GameObject> Cards { get; set; } = new List<GameObject>();
    public int[] positions = {950, 650, 350, 50, -250, -550};

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
