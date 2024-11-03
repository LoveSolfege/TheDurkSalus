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

	public void Run(Game game, Creature creature)
	{
		Console.WriteLine($"Character {creature.Name} used {_attack.Name} on {_target.Name}");
	}
	
}