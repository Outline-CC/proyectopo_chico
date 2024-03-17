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
	public EnemyActionType EnemyActionType {  get;  set; } = EnemyActionType.NormalAttack;
	public string Name { get; set; }
	public int LifePoints {get; set;}
	public int Strength {get; set;}
	public int Defense {get; set;}
	public int Energy {get; set;}
	public float Accuracy { get; set;}
	public EnemyAction EnemyAction { get; set; } = new EnemyAction();

	public Enemy()
	{
		Name = "Juan";
		LifePoints = 20;
		Energy = 3;
		Strength = 0; 
		Defense = 0;
		Accuracy = 0;
	}

	protected override void OnUpdate()
	{

	}
	protected override void OnStart()
	{
	
	}

	public void Action() 
	{
		
			switch ( EnemyActionType )
			{
				case EnemyActionType.NormalAttack:
					//Logica de Ataque Normal
					EnemyAction.Name = "NormalAttack";
					EnemyAction.EnergyCost = 1;
					EnemyAction.Damage = 3;
					EnemyAction.Description = "Normal Attack";
					break;
				case EnemyActionType.Buff:
					//Logica de Buff
					EnemyAction.Name = "Buff";
					EnemyAction.EnergyCost = 2;
					EnemyAction.MyAttack = 1;
				    EnemyAction.MyDefense = 1;
					EnemyAction.Description = "Buff";
					break;
				case EnemyActionType.Debuff:
					//Logica de Debuff
					EnemyAction.Name = "Debuff";
					EnemyAction.EnergyCost = 2;
					EnemyAction.OpponentAttack = 1;
				    EnemyAction.OpponentDefense = 1;
					EnemyAction.Description = "Debuff";
					break;
				case EnemyActionType.SpecialAttack:
					//Logica de Ataque Especial
					EnemyAction.Name = "NormalAttack";
					EnemyAction.EnergyCost = 1;
					EnemyAction.Damage = 6;
					EnemyAction.Description = "Normal Attack";
					break;
				default:
					break;
			}

			EnemyActionType++;
			if ( EnemyActionType > EnemyActionType.SpecialAttack )
			{
				EnemyActionType = EnemyActionType.NormalAttack;
			}
	}
}
