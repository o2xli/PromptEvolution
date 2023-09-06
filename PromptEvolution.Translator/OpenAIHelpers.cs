using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;

internal static class OpenAiHelpers
{
    public static Conversation GetOpenAIChat(Model model, double? temperature, double? topP)
    {
        OpenAIAPI api = new OpenAIAPI();
        var chat = api.Chat.CreateConversation();
        chat.Model = Model.GPT4;
        if (temperature.HasValue)
            chat.RequestParameters.Temperature = temperature;
        if (topP.HasValue)
            chat.RequestParameters.TopP = topP;
        return chat;
    }
    public static string ExtractJsonCodeMarkDown(string input)
    {
        var result = input;
        if (!result.Trim().StartsWith("{") || (!result.Trim().EndsWith("}") && result.Contains("```json")))
        {
            var startTag = "```json";
            var endTag = "```";
            int startIndex = result.IndexOf(startTag) + startTag.Length;
            int endIndex = result.IndexOf(endTag, startIndex);
            result = result.Substring(startIndex, endIndex - startIndex);
        }

        return result;
    }

    public static List<string> ExtractCodeMarkDown(string input, string suffixTypeName = "")
    {
        var startTag = "```" + suffixTypeName;
        var endTag = "```";
        var outputs = new List<string>();
        var result = input;
        while (result.Contains(startTag, StringComparison.OrdinalIgnoreCase))
        {
            int startIndex = result.IndexOf(startTag, StringComparison.OrdinalIgnoreCase) + startTag.Length;
            int endIndex = result.IndexOf(endTag, startIndex);
            outputs.Add(result.Substring(startIndex, endIndex - startIndex).Trim('\n'));
            result = result.Substring(endIndex + endTag.Length);
        }
        if (outputs.Count == 0)
            outputs.Add(input);

        return outputs;
    }
}