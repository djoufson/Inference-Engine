using InferenceEngine.Models;

namespace Rules_UI.Facts;

internal class HasHeadacheFact : Fact
{
    public override string Name => "Has Headache";
    public HasHeadacheFact(bool value = true) : base(value)
    {
    }
}
