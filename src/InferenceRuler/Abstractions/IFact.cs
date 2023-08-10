using InferenceRuler.Models;

namespace InferenceRuler.Abstractions;

public interface IFact
{
    string Name { get; }
    bool Value { get; }

    Fact True();
    Fact False();
}