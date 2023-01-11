using InferenceRuler.DB;
using InferenceRuler.Models;
using InferenceRuler.Utilities;

namespace InferenceRuler;

public class Engine
{
    private readonly FactsBase _factsBase;
    private readonly RulesBase _rulesBase;

    public Engine(FactsBase factsBase, RulesBase rulesBase)
    {
        _factsBase = factsBase;
        _rulesBase = rulesBase;
    }
    private bool CanApply(Rule rule)
    {
        var isProoven = true;
        Utils.CheckNull(rule);
        foreach (var premise in rule.Premises)
        {
            try
            {
                var fact = _factsBase.SearchFact(premise.GetName());
                // If there is no error, that means the fact exists.
                // Let's check if this fact is prooven or not
                isProoven = isProoven && fact.GetValue();
                if (!isProoven)
                    break;
            }
            catch (Exception)
            {
                // The fact was not found in the factsList... 
                // We are then sure tha the rule cannot be applied
                return false;
            }
        }
        return isProoven;
    }
    private Rule FindUsableRule(RulesBase rules)
    {
        foreach (Rule rule in rules.Rules.Cast<Rule>())
            if (CanApply(rule))
                return rule;

        throw new Exception("There is no more applyable rule");
    }
    public void Solve()
    {
        var moreRules = true;
        var usableRules = new RulesBase();
        usableRules.AppendRules(_rulesBase.Rules);
        while (moreRules)
        {

        }
    }
}
