🌪️ 2026-LLMTornadoSample

A sample reference application demonstrating multimodal AI support workflows using LlmTornado — a .NET AI orchestration toolkit.

This project contains example code showing how to use the LlmTornado SDK for advanced AI tasks such as text, speech, image, and multimodal prompt handling using .NET.

✅ What This Is

This repository provides:

📌 A real .NET sample demonstrating how to invoke multimodal LLM workflows

🎯 Integration with LlmTornado SDK components (Chat, Audio, Images, Code)

📂 Example usage of text, images, and audio support

🧪 Reference patterns for building AI-powered features in your own .NET apps

Note: This is a sample project (not a full application) intended for learning and experimentation.

📁 Included Code

LLMTornadoSample.slnx – .NET solution

LLMTornadoSample.Project/Program.cs – Console sample with multiple multimodal examples

.gitignore

The main code shows how to:

Initialize agents

Load image and audio data

Send multimodal input to the model

Print AI solution output

🚀 Features Demonstrated

✔ Multimodal support (image + audio + text)
✔ Integration with the LlmTornado AI SDK
✔ Streaming response capabilities
✔ Console output of AI assistant solutions
✔ Base64 file handling
✔ Multiple usage patterns (voice memo, screenshots, text prompts)

🧠 Sample Usage

Here’s an illustrative snippet from the sample app (Program.cs):

var agent = new MultimodalSupportAgent("your-api-key");

byte[] screenshot = await File.ReadAllBytesAsync("error-screenshot.jpg");
byte[] voiceMemo = await File.ReadAllBytesAsync("customer-complaint.mp3");

string solution = await agent.HandleSupportTicket(
    "The application crashes when I click Submit",
    imageData: screenshot,
    audioData: voiceMemo
);

Console.WriteLine(solution);


This shows basic multimodal support using an agent object to process text, images, and voice.

📦 Prerequisites

✔ .NET SDK installed (version supported by the project)
✔ API key for your LLM provider (OpenAI, Anthropic, etc.)
✔ Required dependencies installed via NuGet

Before running the sample, set your API key (example using environment variables):

export YOUR_API_KEY="your_llm_api_key_here"

📌 How to Run the Project

Clone the repository:

git clone https://github.com/gitguy007/2026-LLMTornadoSample.git


Navigate into the project folder:

cd 2026-LLMTornadoSample


Restore and build:

dotnet restore
dotnet build


Run the sample:

dotnet run --project LLMTornadoSample.Project

🛠 Customizing

You can customize the sample to:

Use different LLM models (Azure, OpenAI, Claude, etc.)

Add more multimodal workflows

Integrate external data sources

Build UI or a web API on top of this backend

🧪 Testing

There are no automated tests included by default. For production projects, add:

Unit tests (e.g., xUnit or NUnit)

Integration tests

Mocking of LLM responses

📖 Recommended Next Steps

If you want to expand this sample, consider:

✅ Adding RAG (Retrieval-Augmented Generation) pipelines using vectors
✅ Building an agentic orchestration layer
✅ Packaging the logic behind a REST API
✅ Adding a UI (Blazor / ASP.NET) front end

📄 License

This sample is provided under the MIT License (check repository for the full license text if present).

🧠 Acknowledgements

The project uses LlmTornado, a provider-agnostic AI toolkit for .NET.

This sample is intended as a hands-on learning resource.
