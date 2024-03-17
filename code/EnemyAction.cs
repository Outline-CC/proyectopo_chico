using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Sandbox
{
	public class EnemyAction
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

		public EnemyAction()
		{
			_name = "";
			_energyCost = 0;
			_damage = 0;
			_opponentDefense = 0;
			_opponentAttack = 0;
			_myDefense = 0;
			_myAttack = 0;
			_description = "";
		}

		public void ResolveAction(Player player, Enemy enemy)
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
