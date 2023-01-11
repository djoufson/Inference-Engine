using InferenceRuler.Abstractions;
using InferenceRuler.Utilities;

namespace InferenceRuler.DB;

public class FactsBase : DataBase<IFact>
{
    public List<IFact> Facts => Datas;
    public void ClearFacts() => Clear();
    public IFact SearchFact(string factName) => SearchData(factName);
    public bool GetValueOfFact(string factName) => GetValueOfData(factName);
    public FactsBase AddFact(IFact newFact)
    {
        AddData(newFact);
        return this;
    }
    public FactsBase AppendFacts(IEnumerable<IFact> newFacts)
    {
        AppendDatas(newFacts);
        return this;
    }
    protected override bool GetValueOfData(string dataName)
    {
        var fact = SearchFact(dataName);
        Utils.CheckNull(fact, dataName);
        return fact.GetValue();
    }
}
