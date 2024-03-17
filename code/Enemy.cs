using Sandbox;

public enum EnemyActionType
{
	NormalAttack,
	Buff,
	Debuff,
	SpecialAttack
}

public sealed class Enemy : Component
{
	public EnemyActionType enemyAction {  get;  set; } = EnemyActionType.NormalAttack;
	public int LifePoints {get; set;}
	public int Strength {get; set;}
	public int Defense {get; set;}
	public int Energy {get; set;}
	public float Accuracy { get; set;}
	public Player Player { get; set;}

	public Enemy()
	{
		Name = "Juan";
		LifePoints = 20;
		Energy = 3;
		Strength = 0; 
		Defense = 0;
		Accuracy = 0;
		Player = new Player();
	}

	protected override void OnUpdate()
	{

	}
	protected override void OnStart()
	{
	
	}

	public void Action() 
	{
		switch (enemyAction)
		{
			case EnemyActionType.NormalAttack:
				//Logica de Ataque Normal
				EnemyAction enemyAction = new EnemyAction( "NormalAttack", 1, 0, 0, 0, 0, 0, "Normal Attack" );
				enemyAction.ResolveAction( Player, this );
				break;
			case EnemyActionType.Buff:
				//Logica de Buff
				break;
			case EnemyActionType.Debuff:
				//Logica de Debuff
				break;
			case EnemyActionType.SpecialAttack:
				//Logica de Ataque Especial
				break;
			default:
				break;
		}

		enemyAction++;
		if(enemyAction > EnemyActionType.SpecialAttack)
		{
			enemyAction = EnemyActionType.NormalAttack;
		}
	}
}
