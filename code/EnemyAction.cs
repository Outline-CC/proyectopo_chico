using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sandbox
{
	internal class EnemyAction
	{
		private string _name;
		private int _energyCost;
		private int _damage;
		private int _opponentDefense;
		private int _opponentAttack;
		private int _myDefense;
		private int _myAttack;
		private string _description;
		[Property]
		public string Name 
		{ 
			get { return _name; } 
			set { _name = value; } 
		}
		[Property]
		public int EnergyCost
		{
			get { return _energyCost; }
			set { _energyCost = value; }
		}
		[Property]
		public int Damage
		{
			get { return _damage; }
			set { _damage = value; }
		}
		[Property]
		public int OpponentDefense
		{
			get { return _opponentDefense; }
			set { _opponentDefense = value; }
		}
		[Property]
		public int OpponentAttack
		{
			get { return _opponentAttack; }
			set { _opponentAttack = value; }
		}
		[Property]
		public int MyDefense
		{
			get { return _myDefense; }
			set { _opponentDefense = value; }
		}
		[Property]
		public int MyAttack
		{
			get { return _myAttack; }
			set { _opponentAttack = value; }
		}
		[Property]
		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}
		public EnemyAction(string name, int energyCost, int damage, int opponentDefense, int opponentAttack, int myDefense, int myAttack, string Description) 
		{
			_name = name;
			_energyCost = energyCost;
			_damage = damage;
			_opponentDefense = opponentDefense;
			_opponentAttack = opponentAttack;
			_myDefense = myDefense;
			_myAttack = myAttack;
			_description = Description;
		}

		public void ResolveAction(ref Player player, ref Enemy enemy)
		{
			if ( player != null)
			{
				player.LifePoints -= _damage;
				player.Strength -= _opponentAttack;
				player.Defense -= _opponentDefense;
			}
			if (enemy != null)
			{
				enemy.Energy -= _energyCost;
				enemy.Strength += _myAttack;
				enemy.Defense += _myDefense;
			}
		}
	}
}
