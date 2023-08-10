using InferenceRuler.Abstractions;

namespace InferenceRuler.DB;

public sealed class FactsBase : List<IFact>
{
    public IFact? SearchFact(string factName) => this.FirstOrDefault(f => f.Name == factName);
}
