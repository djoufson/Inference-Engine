using InferenceRuler.DB;

namespace InferenceRuler;

public class Engine
{
    private RulesBase _factsBase;
    private RulesBase _rulesBase;

    public Engine(RulesBase factsBase, RulesBase rulesBase)
    {
        _factsBase = factsBase;
        _rulesBase = rulesBase;
    }
}
