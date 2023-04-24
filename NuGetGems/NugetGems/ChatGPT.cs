using BenchmarkDotNet.Environments;
using NugetGems.POCO;
using OneOf;
using OpenAI.GPT3.Managers;
using OpenAI.GPT3;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels;
using NuGetGems.Startup;
using Microsoft.Extensions.Hosting;
using BenchmarkDotNet.Engines;
using Forge.OpenAI.Models.Common;
using Forge.OpenAI.Models.TextCompletions;
using System.Reflection.Metadata.Ecma335;
using OpenAI_API;
using OpenAI_API.Moderation;
using OpenAI_API.Images;

namespace NuGetGems.NugetGems
{

    public class ChatGPTExamples {

        public async Task<string> OpenAIAPIExamples(string search) {

            IOpenAIAPI api = new OpenAIAPI(MyStringHelper.MY_API_KEY);
            var chat = api.Chat.CreateConversation();
            chat.AppendSystemMessage("I am a system message!");
            chat.AppendSystemMessage(search);

            _ = await api.Completions.GetCompletion(search);
            _ = await chat.GetResponseFromChatbotAsync();
            _ = api.Moderation.CallModerationAsync(new ModerationRequest {
                Input = "response"
            });

            _ = api.Embeddings.CreateEmbeddingAsync("EMBED ME");
            _ = api.Files.UploadFileAsync("EMBED ME");
            _ = api.ImageGenerations.CreateImageAsync(new OpenAI_API.Images.ImageGenerationRequest {
                Prompt = "Red",
                ResponseFormat = ImageResponseFormat.B64_json
            }); ;

            return await api.Completions.GetCompletion(search);
        }


        public async Task<string?> BetalgoExamples(string search) {

            IOpenAIService api = new OpenAIService(new OpenAiOptions() {
                ApiKey = MyStringHelper.MY_API_KEY
            });

            var completion = await api.ChatCompletion.CreateCompletion(

                new ChatCompletionCreateRequest {
                    Messages = new List<ChatMessage>
                    {
                        ChatMessage.FromSystem("System message"),
                        ChatMessage.FromUser(search)
                    },
                    Model = Models.ChatGpt3_5Turbo0301
                });

            if (completion.Successful) {
                return completion.Choices.FirstOrDefault()?.Message.Content;
            }
            else {
                return completion.Error?.Message;
            }
        }

        public async Task<string?> ForgeOpenAIExamples(Forge.OpenAI.Interfaces.Services.IOpenAIService openAIService, string search) {

           var request = new TextCompletionRequest();
            request.Prompt = search;

            var response =
                await openAIService.TextCompletionService
                    .GetAsync(request, CancellationToken.None)
                    .ConfigureAwait(false);

            if (response.IsSuccess) {
                var choices = response.Result.Completions.Select(x => x.Text);
                return String.Join(", ", choices.ToArray());
            }
            else {
                return response.ErrorResponse.Error.Message;
            }
        }

    }
}
