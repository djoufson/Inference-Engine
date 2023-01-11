using InferenceRuler.Abstractions;
using InferenceRuler.Utilities;

namespace InferenceRuler.DB;

public sealed class FactsBase : DataBase<IFact>
{
    public List<IFact> Facts => Datas;

    public FactsBase(IEnumerable<IFact> facts)
    {
        foreach (var fact in facts)
            Facts.Add(fact);
    }
    /// <summary>
    /// Clears the facts of the facts Base
    /// </summary>
    public void ClearFacts() => Clear();

    /// <summary>
    /// Search the single rule that matches the given name
    /// </summary>
    /// <param name="factName"></param>
    /// <exception cref="InvalidOperationException">If there is no such a fact with the given name</exception>
    /// <exception cref="ArgumentException">If the argument is null</exception>
    /// <returns>The found fact as an IFact</returns>
    public IFact SearchFact(string factName) => SearchData(factName);

    /// <summary>
    /// Gets the value of the facts that corresponds to the given name
    /// </summary>
    /// <param name="factName"></param>
    /// <exception cref="ArgumentNullException">If there is no such a fact with the given name</exception>
    /// <returns></returns>
    public bool GetValueOfFact(string factName) => GetValueOfData(factName);

    /// <summary>
    /// Used to Add a single fact to the current fact Base
    /// </summary>
    /// <param name="newFact">The fact we want to add. It has to be not null</param>
    /// <returns>The instance of the current caller object as a Fluent API</returns>
    public FactsBase AddFact(IFact newFact)
    {
        AddData(newFact);
        return this;
    }

    /// <summary>
    /// Used to Add a range of facts to the current rule Base
    /// </summary>
    /// <param name="newFacts">An IEnumerable of IFact, that contains the collection of facts you want to add</param>
    /// <returns>The instance of the current caller object as a Fluent API</returns>
    public FactsBase AddRangeFacts(IEnumerable<IFact> newFacts)
    {
        AddRangeDatas(newFacts);
        return this;
    }
    protected override bool GetValueOfData(string dataName)
    {
        var fact = SearchFact(dataName);
        Utils.CheckNull(fact, dataName);
        return fact.GetValue();
    }
}
