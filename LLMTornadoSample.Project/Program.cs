using LlmTornado;
using LlmTornado.Audio;
using LlmTornado.Audio.Models;
using LlmTornado.Chat;
using LlmTornado.Chat.Models;
using LlmTornado.Code;
using LLMTornadoSample;

// var api = new TornadoApi("your-api-key");

// Usage example
var agent = new MultimodalSupportAgent("your-api-key");

byte[] screenshot = await File.ReadAllBytesAsync("error-screenshot.jpg");
byte[] voiceMemo = await File.ReadAllBytesAsync("customer-complaint.mp3");

string solution = await agent.HandleSupportTicket(
    "The application crashes when I click Submit",
    imageData: screenshot,
    audioData: voiceMemo
);

Console.WriteLine(solution);

/*
-----------------
20260218 - Image analysis - Streaming
-----------------
var chat = api.Chat.CreateConversation(new ChatRequest
{
    Model = ChatModel.OpenAi.Gpt4.O,
    Stream = true  // Enable streaming
});

byte[] imageBytes = await File.ReadAllBytesAsync("complex-diagram.jpg");
string base64Image = $"data:image/jpeg;base64,{Convert.ToBase64String(imageBytes)}";

chat.AppendUserInput([
    new ChatMessagePart(base64Image, LlmTornado.Images.ImageDetail.High, "image/jpeg"),
    new ChatMessagePart("Explain this architecture diagram step by step")
]);

// Stream the response as it arrives
await chat.StreamResponseRich(new ChatStreamEventHandler
{
    MessageTokenHandler = (token) =>
    {
        Console.Write(token);  // Write immediately to UI
        return ValueTask.CompletedTask;
    },
    OnFinished = (data) =>
    {
        Console.WriteLine($"\n\nTokens used: {data.Usage.TotalTokens}");
        return ValueTask.CompletedTask;
    }
});

-----------------
20260218 - PDF document - Unsuccessful!
-----------------
using LlmTornado.Chat;
using LlmTornado.Chat.Models;

var api = new TornadoApi("your-api-key");

var chat = api.Chat.CreateConversation(new ChatRequest
{
    Model = ChatModel.Anthropic.Claude37.Sonnet,
    MaxTokens = 2000
});

// Option 1: Base64 encoded PDF
byte[] pdfBytes = await File.ReadAllBytesAsync("contract.pdf");
string base64Pdf = Convert.ToBase64String(pdfBytes);

chat.AppendUserInput([
    new ChatMessagePart(base64Pdf, DocumentLinkTypes.Base64),
    new ChatMessagePart("Summarize key obligations in this contract")
]);

// Option 2: PDF from URL (more efficient for large files)
chat.AppendUserInput([
    new ChatMessagePart("https://example.com/public-document.pdf", DocumentLinkTypes.Url),
    new ChatMessagePart("Extract dates and deadlines")
]);

ChatRichResponse response = await chat.GetResponseRich();
Console.WriteLine(response.Text);


/*
-----------------
20260217 - Audio Whisper
-----------------
using LlmTornado;
using LlmTornado.Audio;
using LlmTornado.Audio.Models;
using LlmTornado.Chat;
using LlmTornado.Chat.Models;
using LlmTornado.Code;

var api = new TornadoApi("your-api-key");

// First, transcribe the audio
byte[] audioData = await File.ReadAllBytesAsync("customer-complaint.mp3");

var transcription = await api.Audio.CreateTranscription(new TranscriptionRequest
{
    File = new AudioFile(audioData, AudioFileTypes.Mp3),
    Model = AudioModel.OpenAi.Whisper.V2,
    ResponseFormat = AudioTranscriptionResponseFormats.VerboseJson,
    TimestampGranularities = [TimestampGranularities.Segment]
});

// Now process with multimodal context
var chat = api.Chat.CreateConversation(new ChatRequest
{
    Model = ChatModel.OpenAi.Gpt4.O,
    MaxTokens = 800
});

chat.AppendSystemMessage("You are analyzing customer feedback. Pay attention to tone and sentiment.");
chat.AppendUserInput($"Audio transcript:\n{transcription.Text}\n\nAnalyze the customer's concern and suggest next steps.");

ChatRichResponse response = await chat.GetResponseRich();
Console.WriteLine(response.Text);
*/

/*
-----------------
20260217 - text + image
-----------------

using LlmTornado;
using LlmTornado.Chat;
using LlmTornado.Chat.Models;
using LlmTornado.Images;

var api = new TornadoApi("your-api-key");

var chat = api.Chat.CreateConversation(new ChatRequest
{
    Model = ChatModel.Anthropic.Claude37.Sonnet,  // Vision-capable model
    MaxTokens = 1000
});

// Load image from file or URL
byte[] imageBytes = await File.ReadAllBytesAsync("error-screenshot.jpg");
string base64Image = $"data:image/jpeg;base64,{Convert.ToBase64String(imageBytes)}";

chat.AppendSystemMessage("You are a technical support assistant. Analyze both text descriptions and screenshots.");
chat.AppendUserInput([
    new ChatMessagePart("My application shows this error:"),
    new ChatMessagePart(base64Image, ImageDetail.High, "image/jpeg")
]);

ChatRichResponse response = await chat.GetResponseRich();
Console.WriteLine(response.Text);
*/