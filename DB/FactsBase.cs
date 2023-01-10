using InferenceRuler.Abstractions;
using InferenceRuler.Utilities;

namespace InferenceRuler.DB;

public class FactsBase
{
    private List<IFact> _facts;
    public List<IFact> Facts => _facts;

    // CONSTRUCTOR
    public FactsBase()
    {
        _facts = new List<IFact>();
    }
    public FactsBase Clear()
    {
        _facts.Clear();
        return this;
    }
    public FactsBase AddFact(IFact newFact)
    {
        Utils.CheckNull(newFact);
        _facts.Add(newFact);
        return this;
    }
    public FactsBase AppendFacts(IEnumerable<IFact> newFacts)
    {
        Utils.CheckNull(newFacts);
        _facts.AddRange(newFacts);
        return this;
    }
    public IFact SearchFact(string factName)
    {
        var fact = _facts.FirstOrDefault(x => x.GetName() == factName);
        Utils.CheckNull(fact);
        return fact; // Do not care about this warning, because the fact object is already checked through the Utils.CheckNull() method
    }
}
