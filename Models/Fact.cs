using InferenceRuler.Abstractions;
using System.Text;

namespace InferenceRuler.Models;

public class Fact : IFact
{
    private readonly string _name;
    private readonly bool _value;
    public string Name => _name;
    public bool Value => _value;
    internal Fact(string name, bool value)
    {
        _name = name;
        _value = value;
    }
    public string GetName() => _name;
    public bool GetValue() => _value;
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendFormat("{0} | {1}", _name, _value);
        return sb.ToString();
    }
}
