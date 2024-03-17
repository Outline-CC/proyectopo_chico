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

	public Enemy()
	{
		LifePoints = 20;
		Energy = 3;
		Strength = 0; 
		Defense = 0;
		Accuracy = 0;
	}

	protected override void OnUpdate()
	{

	}

	public void Action() 
	{
		switch (enemyAction)
		{
			case EnemyActionType.NormalAttack:
				//Logica de Ataque Normal
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
