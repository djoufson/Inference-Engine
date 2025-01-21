namespace InferenceEngine.Utilities;

internal class Constants
{
    internal const string RULE_NAME_AND_CONCLUSION_PATTERN = @"(.*?):(.*?)\? ";
    internal const string RULE_PREMISES_PATTERN = @"";
    internal const string RULE_FIRST_PREMISE = @"[?](.*?)[&]";
    internal const string RULE_LAST_PREMISE = @"";
    internal const string SPECIAL_CHARACTERS = "=~`!@#$%^&*()-+={}[]|\\/:;\"'<>,.?";
}
