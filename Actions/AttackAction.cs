using TheDurkSalus.Controllers;
using TheDurkSalus.Interfaces;
using TheDurkSalus.Models;

namespace TheDurkSalus.Actions;

public class AttackAction : IAction
{
	private readonly IAttack _attack;
	private readonly Creature _target;

	public AttackAction(IAttack attack, Creature target)
	{
		_attack = attack;
		_target = target;
	}

	private void CalculateDamageDealt(Game game, Creature target, IAttack attack)
	{
		double damage = attack.Damage;
		target.ReceiveDamage(damage);
		Console.WriteLine($"Damage dealt to {target.Name} is {damage}");
		if (target.CurrentHp <= 0)
		{
			game.RemoveFromTeam(target, game.GetTeamFor(target));
			Console.WriteLine($"{target.Name} has died.");
		}
		else
		{
			Console.WriteLine($"{target.Name} is now at {target.CurrentHp}/{target.MaxHp}");
		}
	}
	
	public void Run(Game game, Creature creature)
	{
		Console.WriteLine($"Character {creature.Name} used {_attack.Name} on {_target.Name}");
		CalculateDamageDealt(game, _target, _attack);
	}
	
}