using InferenceRuler.Models;

namespace InferenceRuler.DB;

public sealed class RulesBase : List<Rule>
{
    public Rule? SearchRule(string name) => this.FirstOrDefault(r => r.Name == name);
}
