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

	Enemy enemyObject;
	Player playerObject;

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
					// PLAYER BATTLE PHASE
					case 1: PlayerBattle(card); break;
					// END PLAYER TURN
					case 2: EndTurn(); break;
					// ENEMY ACTION
					case 3: EnemyTurn();  break;
					default: break;
				}
			//}
			if (Input.Pressed("attack1"))
			{
				//Log.Info( "ACT" );
				var mouseray = Scene.Camera.ScreenPixelToRay(Mouse.Position);
				SceneTraceResult ray = Scene.Trace.Ray(mouseray.Position, mouseray.Forward * int.MaxValue).Run();
				if (ray.Hit)
					Log.Info(ray.GameObject.Name);
				{
					if(ray.GameObject.Tags.ToString().Contains("card"))
					{
						Log.Info( "HIT" );
						Log.Info(ray.GameObject.Components.Get<Card>( FindMode.EverythingInSelf ).Name);
						PlayerBattle(ray.GameObject);
					}
				}
			}
			if (Input.Pressed("use"))
			{
				EndTurn();
				step = 0;
			}
		}
		else
		{
			if(playerObject.LifePoints > 0 && enemyObject.LifePoints < 1)
			{
				//Win
			}
			if(playerObject.LifePoints < 1 && enemyObject.LifePoints > 0)
			{
				//Lose
			}
		}
	}

	protected override void OnStart()
	{
		enemyObject = enemy.Components.Get<Enemy>();
		playerObject = player.Components.Get<Player>();
	}

	void DrawPhase()
	{
		playerObject.StartTurn();
		step = 1;
	}
	void PlayerBattle(GameObject card)
	{
		playerObject.PlayCard(card, enemy);
	}
	void EndTurn()
	{
		playerObject.EndTurn();
		step = 3;
	}
	void EnemyTurn()
	{
		if(enemyObject.LifePoints > 0 )
		{
			while ( enemyObject.Energy > 0 )
			{
				if ( enemyObject.EnemyActionType > EnemyActionType.NormalAttack && enemyObject.Energy == 1 )
				{
					enemyObject.EnemyActionType = EnemyActionType.NormalAttack;
				}
				enemyObject.Action();
				playerObject.LifePoints -= enemyObject.EnemyAction.Damage;
				playerObject.Strength -= enemyObject.EnemyAction.OpponentAttack;
				playerObject.Defense -= enemyObject.EnemyAction.OpponentDefense;
				enemyObject.Energy -= enemyObject.EnemyAction.EnergyCost;
				enemyObject.Strength += enemyObject.EnemyAction.MyAttack;
				enemyObject.Defense += enemyObject.EnemyAction.MyDefense;
			}
		}
		else
		{
			battleContinues = false;
		}
	}
}
