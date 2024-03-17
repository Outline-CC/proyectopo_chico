using Sandbox;
using Sandbox.UI;
using Sandbox.UI.GameMenu;

public sealed class BattleManager : Component
{
	bool battleContinues = true;
	Player player = new Player(100, 10, new Deck());
    Enemy enemy = new Enemy(); // Assuming you've created an Enemy class
    Card cardToPlay; // Simplified: playing the first card

	protected override void OnStart()
	{
		cardToPlay = player.MyDeck.Cards[0];
		Log.Info( "Hello world!" );
		Log.Info( "Deck size: " + player.MyDeck.Cards.Count);
		Log.Info( "Player: E=" + player.Energy);
		Log.Info( "Enemy: E=" + enemy.Energy);
	}
	protected override void OnUpdate()
	{
		/*if (Input.Pressed("attack1"))
		{
			Log.Info("CLIC");
			UseCard();
		}*/
	}

	public void UseCard()
	{
		Log.Info( "Card to play: " + cardToPlay.Name );
		player.PlayCard(cardToPlay, enemy);
	}
}