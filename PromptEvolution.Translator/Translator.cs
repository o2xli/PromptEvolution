﻿using Newtonsoft.Json;
using NJsonSchema;
using OpenAI_API.Chat;
using OpenAI_API.Models;
using Polly;
using System.Diagnostics;

namespace PromptEvolution
{
    public static class Translator
    {

        public static async Task<T?> Translate<T>(string request, string? requestContext = null)
        {
            var polly = Policy
           .Handle<Exception>()
           .RetryAsync(3, (exception, retryCount, context) => Debug.WriteLine($"try: {retryCount}, Exception: {exception.Message}"));

            var result = await polly.ExecuteAsync(async () => await TranslateInternal<T>(request, requestContext));

            return result;
        }
        private static async Task<T?> TranslateInternal<T>(string request, string? requestContext = null)
        {
            Conversation chat = OpenAiHelpers.GetOpenAIChat(Model.GPT4, 0.6, 0.7);

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
            result = OpenAiHelpers.ExtractJsonCodeMarkDown(result);

            if (!result.Trim().StartsWith("{") || !result.Trim().EndsWith("}"))
            {
                var validationResultsText = string.Empty;
                try
                {
                    var validationResults = schema.Validate(result);
                    validationResultsText = String.Join(Environment.NewLine, validationResults.Select(r => r.ToString()).ToArray());
                }
                catch (JsonReaderException ex)
                {
                    validationResultsText = ex.ToString();
                }

                userInput = $$"""
                The JSON object is invalid for the following reasons:
                ```    
                    {{validationResultsText}}
                ```
                Correct it.
                """;

                chat.AppendUserInput(userInput);

                result = await chat.GetResponseFromChatbotAsync().ConfigureAwait(false);
                result = OpenAiHelpers.ExtractJsonCodeMarkDown(result);
            }

            var resultObject = JsonConvert.DeserializeObject<T>($"{result}");

            return resultObject;
        }

        

    }
}
