using InferenceRuler.Abstractions;
using InferenceRuler.Models;
using InferenceRuler.Utilities;

namespace InferenceRuler.DB;

public class RulesBase : DataBase<IRule>
{
    public List<IRule> Facts => Datas;
    public void ClearRules() => Clear();
    public IRule SearchRule(string ruleName) => SearchData(ruleName);
    public bool GetValueOfRule(string factName) => GetValueOfData(factName);
    protected override bool GetValueOfData(string dataName)
    {
        var rule = SearchRule(dataName) as Rule;
        Utils.CheckNull(rule, dataName);
        return rule.Conclusion.GetValue(); // Ignore this warning, because we already check if the variable rule is null
    }
}
