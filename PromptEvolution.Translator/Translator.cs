using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NJsonSchema;
using OpenAI_API;
using OpenAI_API.Models;
using Polly;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PromptEvolution
{
    public static class Translator
    {

        public static async Task<T?> Translate<T>(string request,string? requestContext = null)
        {
            var polly = Policy
           .Handle<Exception>()
           .RetryAsync(3, (exception, retryCount, context) => Debug.WriteLine($"try: {retryCount}, Exception: {exception.Message}"));

            var result = await polly.ExecuteAsync(async () => await TranslateInternal<T>(request, requestContext));

            return result;
        }
        private static async Task<T?> TranslateInternal<T>(string request, string? requestContext = null)
        {
            OpenAIAPI api = new OpenAIAPI();
            var chat = api.Chat.CreateConversation();
            chat.Model = Model.ChatGPTTurbo;

            var schema = JsonSchema.FromType<T>();
           
            var jsonSchema = schema.ToJson();

            var systemMessage = $$"""
                You are a service that translates user requests into JSON objects of type \"{{typeof(T).Name}}\" according to the following JSON Schema definitions:
                ```    
                    {{jsonSchema}}
                ```
                {{requestContext}}
                """;

            chat.AppendSystemMessage(systemMessage);


            var userInput = $$"""
                The following is a user request:
                \"{{request}}\"                        
                """;

            chat.AppendUserInput(userInput);

            var result = await chat.GetResponseFromChatbotAsync().ConfigureAwait(false);

            if(!result.Trim().StartsWith("{") || !result.Trim().EndsWith("}"))
            {
                var validationResults = schema.Validate(result);
                var validationResultsText = String.Join(Environment.NewLine,validationResults.Select(r => r.ToString()).ToArray());
                userInput = $$"""
                The JSON object is invalid for the following reasons:
                ```    
                    {{validationResultsText}}
                ```
                Correct it.
                """;

                chat.AppendUserInput(userInput);

                result = await chat.GetResponseFromChatbotAsync().ConfigureAwait(false);
            }

            var resultObject = JsonConvert.DeserializeObject<T>($"{result}");

            return resultObject;
        }
    }
}
