using InferenceRuler.Models;

namespace Rules_UI.Facts;

internal class HasMalariaFact : Fact
{
    public HasMalariaFact(bool value = true) : base(value)
    {
    }

    public override string Name => "Has Malaria";
}
