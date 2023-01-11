using InferenceRuler.Abstractions;
using InferenceRuler.Models;
using InferenceRuler.Utilities;
using InferenceRuler.Utilities.CustomExceptions;
using System.Text.RegularExpressions;

namespace InferenceRuler.Factories;

public class RuleFactory
{
    /// <summary>
    /// Create a rule based on an existing rule.
    /// If provided a ruleName, the created rule name will be assigned to this; 
    /// if not, the default rule name will be the same as the provided rule's one
    /// </summary>
    /// <param name="rule">The rule you want to copy</param>
    /// <param name="ruleName">The name you want the new rule to have</param>
    /// <exception cref="ArgumentNullException">If the rule passed as argument is null</exception>
    /// <returns>The created rule</returns>
    public static Rule MakeRule(Rule rule, string ruleName = "")
        => (Utils.CheckNull(rule)) ? new((string.IsNullOrEmpty(ruleName)) ? rule.Name : ruleName,
            rule.Premises,
            rule.Conclusion) :

        throw new global::System.ArgumentException(null, nameof(rule));

    /// <summary>
    /// Create a rule based on explicits parameters
    /// </summary>
    /// <param name="ruleName">The name of the rule you want to create</param>
    /// <param name="conclusion">The logical conclusion if every premise is asserted</param>
    /// <param name="premises">The actual premises of the rule, those are a list of facts separated by comas ","</param>
    /// <returns>The created rule</returns>
    public static Rule MakeRule(string ruleName, IFact conclusion, params IFact[] premises)
    {
        return new(ruleName, premises, conclusion);
    }

    /// <summary>
    /// Create a rule, based on the following firstPattern :
    /// RuleName : Conclusion ? Fact1 & Fact2 & !Fact3 & !Fact4
    /// </summary>
    /// <param name="rulePattern"></param>
    /// <exception cref="ArgumentNullException">If the rulePattern passed as argument is null</exception>
    /// <exception cref="RulePatternException">If the passed string argument does not respect the rule firstPattern</exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="RegexMatchTimeoutException"></exception>
    /// <returns>The created rule</returns>
    public static Rule MakeRule(string rulePattern)
    {
        if (string.IsNullOrEmpty(rulePattern)) throw new ArgumentNullException(nameof(rulePattern));
        if (!rulePattern.Contains(':') ||
            !rulePattern.Contains('?')) throw new RulePatternException();

        // START CAPTURING ELEMENTS
        // 1. The ruleName and the Conslusion
        string firstPattern = Constants.RULE_NAME_AND_CONCLUSION_PATTERN;
        var options = RegexOptions.Multiline;
        var match = Regex.Match(@rulePattern, firstPattern, options);

        string ruleName = match.Groups[1].Value.Trim();
        string conclusionName = match.Groups[2].Value.Trim();

        // Make the Conclusion Fact
        var conclusion = FactFactory.MakeFact(conclusionName, !conclusionName.Contains('!'));
        Console.WriteLine($"{ruleName} {conclusion}");


        // 2. The Premises
        List<Fact> facts = new ();
        string secondPattern = Constants.RULE_PREMISES_PATTERN;
        var premisesMatches = Regex.Matches(@rulePattern, secondPattern, options);
        foreach (Match premiseMatch in premisesMatches.Cast<Match>())
        {
            var name = premiseMatch.Groups[1].Value.Trim();
            facts.Add(FactFactory.MakeFact(name, !conclusionName.Contains('!')));
        }

        // RETURN THE NEW RULE MADE WITH THE RETRIEVED ELEMENTS
        return MakeRule(ruleName, conclusion, facts.ToArray());
    }
}
