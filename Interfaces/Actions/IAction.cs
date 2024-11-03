using TheDurkSalus.Controllers;
using TheDurkSalus.Models;

namespace TheDurkSalus.Interfaces;

public interface IAction
{
	void Run(Game game, Creature creature);
}