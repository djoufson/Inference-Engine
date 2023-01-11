using InferenceRuler.Models;

namespace InferenceRuler.Factories;

public class FactFactory
{
    public static Fact MakeFact(string name, bool value)
    {
        return (name.Contains('=')) ? 
            throw new ArgumentException("A Fact name cannot contain the \"=\" sign ") : 
            new Fact(
                value ? name : name[1..], // We skip the first element of the Name ('!') if the fact value is false
                value);
    }
    public static Fact MakeFact(string factFormat)
    {
        var text = factFormat.Trim();
        var datas = text.Split('=');
        if (datas.Length < 2)
            throw new ArgumentException("The format does not match the required pattern");
        if(bool.TryParse(datas[1], out var value))
            return new Fact(datas[0], value);
        else
            throw new ArgumentException("The format does not match the required pattern");
    }
}
