namespace PackIT.Domain.ValueObjects;

public record PackingListName
{
	public string Value { get; }
	PackingListName(string value)
	{
		if(string.IsNullOrWhiteSpace(value))
		{
			throw new 
		}
		Value = value;
	}
}
