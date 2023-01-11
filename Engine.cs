using InferenceRuler.Abstractions;
using InferenceRuler.DB;
using InferenceRuler.Models;
using InferenceRuler.Utilities;
using System.Text;

namespace InferenceRuler;

public class Engine
{
    public readonly FactsBase _factsBase;
    public readonly RulesBase _rulesBase;

    /// <summary>
    /// Instantiates a new Inference Engine with the given attributes
    /// </summary>
    /// <param name="factsBase">The object that we will use to instantiate the rules base. It has to be not null</param>
    /// <param name="rulesBase">The object that we will use to instantiate the rules base. It has to be not null</param>
    public Engine(FactsBase factsBase, RulesBase rulesBase)
    {
        _factsBase = factsBase;
        _rulesBase = rulesBase;
    }

    /// <summary>
    /// Gets the list of initially known rules and infered rules
    /// </summary>
    /// <returns>A list of rules</returns>
    public List<Fact> GetFacts()
    { 
        var facts = new List<Fact>();
        foreach (var fact in _factsBase.Facts)
        {
            var f = fact as Fact;
            if(f is not null)
                facts.Add(f);
        }
        return facts;
    }

    public List<Rule> GetRules()
    {
        var rules = new List<Rule>();
        foreach (var rule in _rulesBase.Rules)
        {
            var r = rule as Rule;
            if (r is not null)
                rules.Add(r);
        }
        return rules;
    }

    /// <summary>
    /// Prints the rules to the console
    /// </summary>
    public string PrintFacts()
    {
        var sb = new StringBuilder();
        foreach (var fact in _factsBase.Facts)
            sb.AppendLine(fact.ToString());

        return sb.ToString();
    }

    /// <summary>
    /// Solves the problem and updates the Facts base.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<IFact> Solve()
    {
        var moreRules = true;
        var usableRules = new RulesBase();
        usableRules.AddRangeRules(_rulesBase.Rules);
        while (moreRules)
        {
            // We try to find some applyable Rule
            try
            {
                var rule = FindUsableRule(usableRules);
                // No error occurs, we can continue
                usableRules.Rules.Remove(rule);

                try
                {
                    // If there is no error, that means that the rule already exists
                    var _fact = _factsBase.SearchFact(rule.Conclusion.GetName());
                    continue;
                }
                catch (Exception)
                {
                    // The inferred rule does not exixt in the rulesBase
                    _factsBase.AddFact(rule.Conclusion);
                }
            }
            catch (Exception)
            {
                // We didn't find any applyable rule
                break;
            }
        }
        return _factsBase.Facts;
    }

    /// <summary>
    /// Determnes if a given rule is appliyable, meaning all of its premises are true
    /// </summary>
    /// <param name="rule"></param>
    /// <returns>true if the rule can be applied, false if not</returns>
    public bool CanApply(Rule rule)
    {
        var isProoven = true;
        Utils.CheckNull(rule);
        foreach (Fact premise in rule.Premises.Cast<Fact>())
        {
            try
            {
                var fact = _factsBase.SearchFact(premise.GetName());
                // If there is no error, that means the rule exists.
                // Let's check if this rule is prooven or not
                var value1 = premise.GetValue();
                var value2 = fact.GetValue();
                isProoven = value1 == value2;
                if (!isProoven)
                    break;
            }
            catch (Exception)
            {
                // The rule was not found in the factsList... 
                // We are then sure tha the rule cannot be applied
                return false;
            }
        }
        return isProoven;
    }
    public Rule FindUsableRule(RulesBase rules)
    {
        foreach (Rule rule in rules.Rules.Cast<Rule>())
            if (CanApply(rule))
                return rule;

        throw new Exception("There is no applyable rule");
    }
}
