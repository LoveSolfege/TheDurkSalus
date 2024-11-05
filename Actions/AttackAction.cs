using TheDurkSalus.Controllers;
using TheDurkSalus.Interfaces;
using TheDurkSalus.Models;
using TheDurkSalus.Utils;

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
		ConsoleUtils.WriteLine($"Damage dealt to {target.Name} is {damage}",
			damage > 0 ? ConsoleColor.DarkYellow : ConsoleColor.DarkGray);
		if (target.CurrentHp <= 0)
		{
			game.RemoveFromTeam(target, game.GetTeamFor(target));
			ConsoleUtils.WriteLine($"{target.Name} has died.", ConsoleColor.Red);
		}
		else
		{
			ConsoleUtils.WriteLine($"{target.Name} is now at {target.CurrentHp}/{target.MaxHp}", game.IsEnemy(target) ? ConsoleColor.DarkRed : ConsoleColor.Blue);
		}
	}
	
	public void Run(Game game, Creature creature)
	{
		ConsoleUtils.WriteLine($"Character {creature.Name} used {_attack.Name} on {_target.Name}", ConsoleColor.White);
		CalculateDamageDealt(game, _target, _attack);
	}
	
}