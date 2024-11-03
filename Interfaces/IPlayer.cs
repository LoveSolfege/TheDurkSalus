using TheDurkSalus.Controllers;
using TheDurkSalus.Models;

namespace TheDurkSalus.Interfaces;

public interface IPlayer
{
	IAction ChooseAction(Game game, Creature creature);
}