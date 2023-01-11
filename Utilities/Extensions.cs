namespace InferenceRuler.Utilities;

internal static class Extensions
{
    internal static bool ContainsAny(this string text, char[] elements)
    {
        bool result = false;
        foreach (char element in elements)
        {
            result = text.Contains(element);
            if(result) return true;
        }
        return result;
    }
}
