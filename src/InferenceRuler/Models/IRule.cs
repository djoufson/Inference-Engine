using InferenceEngine.Abstractions;

namespace InferenceEngine.Models
{
    public interface IRule
    {
        string Name { get; set; }
        IFact Conclusion { get; set; }
        List<IFact> Premises { get; set; }

        string ToString();
    }
}