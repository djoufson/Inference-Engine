using System.Text;
using InferenceEngine.Abstractions;

namespace InferenceEngine.Models;

public abstract class Fact : IFact
{
    protected Fact(bool value)
    {
        Value = value;
    }

    public abstract string Name { get; }
    public bool Value { get; private set; } = true;

    public Fact True()
    {
        Value = true;
        return this;
    }

    public Fact False()
    {
        Value = false;
        return this;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendFormat("{0} | {1}", Name, Value);
        return sb.ToString();
    }
}
