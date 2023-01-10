using InferenceRuler.Abstractions;
using System.Text;

namespace InferenceRuler.Models;

public class Fact : IFact
{
    private readonly string _name;
    private readonly bool _value;
    private int _level;
    public string Name => _name;
    public int Level => _level;
    public bool Value => _value;
    public Fact(string name, int level, bool value)
    {
        _name = name;
        _level = level;
        _value = value;
    }
    public int GetLevel() => _level;
    public string GetName() => _name;
    public bool GetValue() => _value;
    public void SetLevel(int level) => _level = level;
    public override string ToString()
    {
        var sb = new StringBuilder();
        if (!_value)
            sb.Append('!');
        sb.AppendFormat("{0} ({1})", _name, _level);
        return sb.ToString();
    }
}
