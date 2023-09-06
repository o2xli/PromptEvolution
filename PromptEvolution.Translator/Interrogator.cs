using OpenAI_API.Models;

namespace PromptEvolution
{
    public class Interrogator
    {
        public static async Task<List<string>> Ask(string question)
        {
            var chat = OpenAiHelpers.GetOpenAIChat(Model.GPT4, 0.6, 0.7);
            chat.AppendSystemMessage("Suggest Windows PowerShell commands for the following request:");

            chat.AppendUserInput(question);
            var result = await chat.GetResponseFromChatbotAsync().ConfigureAwait(false);

            return OpenAiHelpers.ExtractCodeMarkDown(result, "powershell");
        }
    }
}
