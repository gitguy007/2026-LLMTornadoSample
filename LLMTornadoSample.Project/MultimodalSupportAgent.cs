using System;
using System.Collections.Generic;
using System.Text;

namespace LLMTornadoSample
{
    using LlmTornado;
    using LlmTornado.Agents;
    using LlmTornado.Agents.DataModels;
    using LlmTornado.Audio;
    using LlmTornado.Audio.Models;
    using LlmTornado.Chat;
    using LlmTornado.Chat.Models;
    using LlmTornado.Images;
    using System.Text;

    public class MultimodalSupportAgent
    {
        private readonly TornadoApi api;

        public MultimodalSupportAgent(string apiKey)
        {
            api = new TornadoApi(apiKey);
        }

        public async Task<string> HandleSupportTicket(
            string userMessage,
            byte[]? imageData = null,
            byte[]? audioData = null)
        {
            var agent = new TornadoAgent(
                client: api,
                model: ChatModel.OpenAi.Gpt51.V51,
                instructions: @"You are a technical support specialist. 
                Analyze all provided inputs (text, images, audio) 
                to provide comprehensive solutions.",
                streaming: true
            );

            // Build multimodal message
            List<ChatMessagePart> parts = [new ChatMessagePart(userMessage)];

            if (imageData != null)
            {
                string base64 = $"data:image/jpeg;base64,{Convert.ToBase64String(imageData)}";
                parts.Add(new ChatMessagePart(base64, ImageDetail.High, "image/jpeg"));
            }

            if (audioData != null)
            {
                // Transcribe first
                var transcription = await api.Audio.CreateTranscription(new TranscriptionRequest
                {
                    File = new AudioFile(audioData, AudioFileTypes.Wav),
                    Model = AudioModel.OpenAi.Whisper.V2
                });

                parts.Add(new ChatMessagePart($"[Audio transcript]: {transcription.Text}"));
            }

            // Stream response for better UX
            StringBuilder fullResponse = new StringBuilder();

            await agent.Run(
                parts,
                streaming: true,
                onAgentRunnerEvent: (evt) =>
                {
                    if (evt is AgentRunnerStreamingEvent streamEvt &&
                        streamEvt.ModelStreamingEvent is ModelStreamingOutputTextDeltaEvent deltaEvt)
                    {
                        Console.Write(deltaEvt.DeltaText);
                        fullResponse.Append(deltaEvt.DeltaText);
                    }
                    return ValueTask.CompletedTask;
                }
            );

            return fullResponse.ToString();
        }
    }
}
