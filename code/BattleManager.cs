using Sandbox;
using Sandbox.UI;
using Sandbox.UI.GameMenu;

public sealed class BattleManager : Component
{
	bool battleContinues = true;
	// 0 = DRAW PHASE, 1 = PLAYER ACTION, 2 = END PLAYER TURN, 3 = ENEMY ACTS
	int step = 0;
	[Property]
	GameObject player { get; set; }
	[Property]
	GameObject enemy { get; set; }
	[Property]
	GameObject card { get; set; }

	protected override void OnUpdate()
	{
		if ( battleContinues )
		{
			//if( Input.Pressed( "attack2" ) )
			//{
				//Log.Info( "ACT" );
				switch ( step )
				{
					// DRAW PHASE
					case 0: DrawPhase(); break;
					case 3: break;
					default: break;
				}
			//}
			if (Input.Pressed("attack1"))
			{
				//Log.Info( "ACT" );
				var mouseray = Scene.Camera.ScreenPixelToRay(Mouse.Position);
				SceneTraceResult ray = Scene.Trace.Ray(mouseray.Position, mouseray.Forward * int.MaxValue).Run();
				if (ray.Hit)
				{
					if(ray.GameObject.Tags.ToString().Contains("card"))
					Log.Info(ray.GameObject.Components.Get<Card>( FindMode.EverythingInSelf ).Name);
					PlayerBattle(ray.GameObject);
				}
			}
			if (Input.Pressed("use"))
			{
				EndTurn();
				step = 0;
			}
		}
	}

	void DrawPhase()
	{
		player.Components.Get<Player>().StartTurn();
		step = 1;
	}
	void PlayerBattle(GameObject card)
	{
		player.Components.Get<Player>().PlayCard(card, enemy);
	}
	void EndTurn()
	{
		player.Components.Get<Player>().EndTurn();
		step = 3;
	}
	void EnemyAction()
	{
		// enemy.Components.Get<Enemy>().EnemyAction(player);

	}
}
