namespace TheDurkSalus.Models;

public abstract class Creature(string? name, double hp, bool isEnemy)
{
	public string? Name { get; protected set; } = name;
	public double Hp { get; protected set; } = hp;
	public bool IsEnemy { get; protected set; } = isEnemy;
}