using TheDurkSalus.Controllers;
using TheDurkSalus.Interfaces;
using TheDurkSalus.Models;

namespace TheDurkSalus.Actions;

public class DoNothingAction : IAction
{
	public void Run(Game game, Creature creature)
	{
		Console.WriteLine($"{creature.Name} did nothing.");
	}
}