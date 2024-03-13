using System.Security.Cryptography.X509Certificates;

public class DeckManager : Component
{
    // Deck Manager will add new card prefabs to the scene.
    // Start by adding one to the scene.
    [Property]
    GameObject CardPrefab { get; set; }
    [Property]
    public List<GameObject> Cards { get; set; } = new List<GameObject>();
    public List<Card> ConsoleCards { get; set; } = new List<Card>();
    public int[] positions = {950, 650, 350, 50, -250, -550};
	protected override void OnStart()
	{
	}
	// Assign a gameobject to the predetermined deck
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
				.SetProperties("Strike", 1, "Le pega bien duro");
            // add card to deck
            Cards.Add(cardInstance);
            Log.Info(Cards.Count);
           }
        }
    }
}
