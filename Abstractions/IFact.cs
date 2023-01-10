namespace InferenceRuler.Abstractions;

public interface IFact
{
    string GetName();
    bool GetValue();
    int GetLevel();
    void SetLevel(int level);
}
