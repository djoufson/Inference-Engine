using InferenceRuler.DB;
using InferenceRuler.Models;

namespace InferenceRuler;

public class EngineBuilder
{
    private FactsBase _factsBase = new();
    private RulesBase _rulesBase = new();

    public EngineBuilder AddRule(Rule rule)
    {
        _rulesBase.Add(rule);
        return this;
    }
    public EngineBuilder AddRules(IEnumerable<Rule> rules)
    {
        _rulesBase.AddRange(rules);
        return this;
    }
    public EngineBuilder AddRules(params Rule[] rules)
    {
        _rulesBase.AddRange(rules);
        return this;
    }
    public EngineBuilder AddFact(Fact fact)
    {
        _factsBase.Add(fact);
        return this;
    }
    public EngineBuilder AddFacts(IEnumerable<Fact> facts)
    {
        _factsBase.AddRange(facts);
        return this;
    }
    public EngineBuilder AddFacts(params Fact[] facts)
    {
        _factsBase.AddRange(facts);
        return this;
    }

    public Engine Build()
    {
        var engine = new Engine(_factsBase, _rulesBase);
        _factsBase = new();
        _rulesBase = new();
        return engine;
    }
}
