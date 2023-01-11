using InferenceRuler.Abstractions;
using InferenceRuler.Models;
using InferenceRuler.Utilities;

namespace InferenceRuler.DB;

public sealed class RulesBase : DataBase<IRule>
{
    public List<IRule> Rules => Datas;
    public void ClearRules() => Clear();
    public IRule SearchRule(string ruleName) => SearchData(ruleName);
    public bool GetValueOfRule(string factName) => GetValueOfData(factName);

    /// <summary>
    /// Used to Add a single rule to the current rule Base
    /// </summary>
    /// <param name="newRule">The rule we want to add. It has to be not null</param>
    /// <returns>The instance of the current caller object as a Fluent API</returns>
    public RulesBase AddRule(IRule newRule)
    {
        AddData(newRule);
        return this;
    }

    /// <summary>
    /// Used to Add a range of rules to the current rule Base
    /// </summary>
    /// <param name="newRules">An IEnumerable of IRule, that contains the collection of rules you want to add</param>
    /// <returns>The instance of the current caller object as a Fluent API</returns>
    public RulesBase AddRangeRules(IEnumerable<IRule> newRules)
    {
        AddRangeDatas(newRules);
        return this;
    }
    protected override bool GetValueOfData(string dataName)
    {
        var rule = SearchRule(dataName) as Rule;
        Utils.CheckNull(rule, dataName);
        return rule.Conclusion.GetValue(); // Ignore this warning, because we already check if the variable rule is null
    }
}
