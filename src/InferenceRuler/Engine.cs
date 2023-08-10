using InferenceRuler.Abstractions;
using InferenceRuler.DB;
using InferenceRuler.Models;
using InferenceRuler.Utilities;
using System.Text;

namespace InferenceRuler;

public class Engine
{
    private readonly FactsBase _factsBase;
    private readonly RulesBase _rulesBase;

    public IReadOnlyList<Rule> Rules => _rulesBase.AsReadOnly();
    public IReadOnlyList<IFact> Facts => _factsBase.AsReadOnly();

    /// <summary>
    /// Instantiates a new Inference Engine with the given attributes
    /// </summary>
    /// <param name="factsBase">The object that we will use to instantiate the facts base. It has to be not null</param>
    /// <param name="rulesBase">The object that we will use to instantiate the rules base. It has to be not null</param>
    internal Engine(FactsBase factsBase, RulesBase rulesBase)
    {
        _factsBase = factsBase;
        _rulesBase = rulesBase;
    }

    /// <summary>
    /// Prints the rules to the console
    /// </summary>
    public string PrintFacts()
    {
        var sb = new StringBuilder();
        foreach (var fact in _factsBase)
            sb.AppendLine(fact.ToString());

        return sb.ToString();
    }

    /// <summary>
    /// Solves the problem and updates the Facts base.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<IFact> Solve()
    {
        var usableRules = new RulesBase();
        usableRules.AddRange(_rulesBase);
        do
        {
            Rule? rule = usableRules.FirstOrDefault(r => CanApply(r));
            if(rule is null)
                break;

            usableRules.Remove(rule);
            if(!_factsBase.Exists(f => f.Name == rule.Conclusion.Name))
                _factsBase.Add(rule.Conclusion);
        } while (usableRules.Any());
        return _factsBase;
    }

    /// <summary>
    /// Determnes if a given rule is appliyable, meaning all of its premises are true
    /// </summary>
    /// <param name="rule"></param>
    /// <returns>true if the rule can be applied, false if not</returns>
    public bool CanApply(Rule rule)
    {
        var isProoven = true;
        foreach (var premise in rule.Premises)
        {
            var fact = _factsBase.SearchFact(premise.Name);
            if (fact is null)
                return false;

            var firstValue = premise.Value;
            var secondValue = fact.Value;
            isProoven = firstValue == secondValue;
            if (!isProoven)
                return false;
        }

        return isProoven;
    }
}
