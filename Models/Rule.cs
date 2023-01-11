using InferenceRuler.Abstractions;
using System.Text;

namespace InferenceRuler.Models;

public class Rule : IRule
{
    public List<IFact> Premises { get; set; }
    public IFact Conclusion { get; set; }
    public string Name { get; set; }
    internal Rule(string ruleName, IEnumerable<IFact> premises, IFact conclusion)
    {
        Name = ruleName;
        Premises = premises.ToList();
        Conclusion = conclusion;
    }
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendFormat("{0} ===> IF: (", Name)
            .AppendJoin(" AND ", Premises)
            .AppendFormat(") THEN {0}", Conclusion);

        return sb.ToString();
    }

    public string GetName()
    {
        return Name;
    }
}
