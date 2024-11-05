namespace TheDurkSalus.Utils;

public static class PropertyUtils
{
	public static List<(string Name, object Value)> GetProperties<T>(object obj)
	{
		List<(string Name, object Value)> propertyList = new List<(string, object)>();
		var properties = obj.GetType().GetProperties();

		foreach (var property in properties)
		{
			if (property.PropertyType == typeof(T))
			{
				propertyList.Add((property.Name, property.GetValue(obj))!);
			}
		}

		return propertyList;
	}
}