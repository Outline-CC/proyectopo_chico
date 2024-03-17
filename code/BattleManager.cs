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
			if( Input.Pressed( "attack2" ) )
			{
				Log.Info( "ACT" );
				switch ( step )
				{
					// DRAW PHASE
					case 0: DrawPhase(); break;
					// PLAYER BATTLE PHASE
					case 1: PlayerBattle(); break;
					// END PLAYER TURN
					case 2: EndTurn(); break;
					// ENEMY ACTION
					case 3: EnemyTurn();  break;
					default: break;
				}
			}
		}
	}

	void DrawPhase()
	{
		player.Components.Get<Player>().StartTurn();
		step = 1;
	}
	void PlayerBattle()
	{
		player.Components.Get<Player>().PlayCard(card, enemy);
	}
	void EndTurn()
	{
		player.Components.Get<Player>().EndTurn();
		step = 3;
	}
	void EnemyTurn()
	{
		Enemy enemyObject = enemy.Components.Get<Enemy>();
		Player playerObject = player.Components.Get<Player>();
		while ( enemyObject.Energy > 0 )
		{
			if( enemyObject.EnemyActionType > EnemyActionType.NormalAttack && enemyObject.Energy == 1 )
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
}
