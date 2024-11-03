namespace TheDurkSalus.Constants;

public static class AttackDamage
{
	private static readonly Random _rnd = new();

	public const int PunchDamage = 1;
	public static  int BoneCrunchDamage
	{
		get { return _rnd.Next(2); }
	}

}