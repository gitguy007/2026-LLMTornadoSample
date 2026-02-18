using LlmTornado.Chat;
using LlmTornado.Chat.Models;

namespace LLMTornadoSample
{
    public class MultimodalCostTracker
    {
        private decimal totalCost = 0;

        public async Task<ChatRichResponse> TrackRequest(
            Conversation chat,
            Func<Task<ChatRichResponse>> request)
            {
                ChatRichResponse response = await request();

                if (response.Result?.Usage != null)
                {
                    int tokens = response.Result.Usage.TotalTokens;
                    decimal costPer1k = GetModelCost(chat.Model);
                    decimal cost = (tokens / 1000m) * costPer1k;

                    totalCost += cost;

                    Console.WriteLine($"Request cost: ${cost:F4} ({tokens} tokens)");
                    Console.WriteLine($"Running total: ${totalCost:F2}");
                }

                return response;
            }

        private decimal GetModelCost(ChatModel model)
        {
            // Simplified - check current pricing
            return model.Name switch
            {
                var n when n.Contains("gpt-4-turbo") => 0.01m,
                var n when n.Contains("claude-3") => 0.015m,
                var n when n.Contains("gemini") => 0.0005m,
                _ => 0.01m
            };
        }
    }
}
