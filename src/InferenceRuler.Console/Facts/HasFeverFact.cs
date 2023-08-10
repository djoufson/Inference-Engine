using InferenceRuler.Models;

namespace Rules_UI.Facts;

internal class HasFeverFact : Fact
{
    public override string Name => "Has Fever";
    public HasFeverFact(bool value = true) : base(value)
    {
    }
}
