using InferenceEngine.Abstractions;
using InferenceEngine.Models;
using Rules_UI.Facts;

namespace Rules_UI.Rules;

internal class MalariaRule : Rule
{
    public override List<IFact> Premises => new()
    {
        new HasHeadacheFact(),
        new HasFeverFact()
    };

    public override IFact Conclusion => new HasMalariaFact();

    public override string Name => "Malaria Rule";
}
