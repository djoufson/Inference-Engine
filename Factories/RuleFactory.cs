using InferenceRuler.Abstractions;
using InferenceRuler.Models;

namespace InferenceRuler.Factories;

public class RuleFactory
{
    public static Rule MakeRule(Rule rule) => new (rule.Name, rule.Premises, rule.Conclusion);
    public static Rule MakeRule(string ruleName, IFact conclusion, params IFact[] premises)
    {
        return new (ruleName, premises, conclusion);
    }
}
