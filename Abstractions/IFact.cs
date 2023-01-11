namespace InferenceRuler.Abstractions;

public interface IFact : IData
{
    bool GetValue();
    int GetLevel();
    void SetLevel(int level);
}
