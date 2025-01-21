using System.Text;
using InferenceEngine.Abstractions;

namespace InferenceEngine.Models;

public abstract class Rule
{
    public abstract List<IFact> Premises { get; }
    public abstract IFact Conclusion { get; }
    public abstract string Name { get; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendFormat("{0} ===> IF: (", Name)
            .AppendJoin(" AND ", Premises)
            .AppendFormat(") THEN {0}", Conclusion);

        return sb.ToString();
    }
}
