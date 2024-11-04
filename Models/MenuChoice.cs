using TheDurkSalus.Interfaces;

namespace TheDurkSalus.Models;

public record MenuChoice(string Description, IAction? Action)
{
	public bool Available => Action != null;
}