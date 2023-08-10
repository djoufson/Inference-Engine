namespace InferenceRuler.Utilities.CustomExceptions;

public class RulePatternException : Exception
{
	public RulePatternException() : base()
	{
	}
	public RulePatternException(string? message) : base(message)
	{
	}
}
