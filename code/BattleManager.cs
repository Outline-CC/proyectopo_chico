using Sandbox;
using Sandbox.UI;
using Sandbox.UI.GameMenu;

public sealed class BattleManager : Component
{
	bool battleContinues = true;
	static Player player = new Player();
    static Enemy enemy = new Enemy(); // Assuming you've created an Enemy class
    Card cardToPlay = player.MyDeck.Cards[0]; // Simplified: playing the first card

	protected override void OnStart()
	{
		Log.Info( "Hello world!" );
		Log.Info( "Deck size: " + player.MyDeck.Cards.Count);
		Log.Info( "Player: E=" + player.Energy);
		Log.Info( "Enemy: E=" + enemy.Energy);
		Log.Info( "Card to play: " + cardToPlay.Name );
		player.PlayCard(cardToPlay, enemy);
	}
	protected override void OnUpdate()
	{
		if (Input.Pressed("attack1"))
		{
			Log.Info("CLIC");
		}
	}
}