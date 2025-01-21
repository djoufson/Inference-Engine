using InferenceEngine.Models;

namespace InferenceEngine.Abstractions;

public interface IFact
{
    string Name { get; }
    bool Value { get; }

    Fact True();
    Fact False();
}