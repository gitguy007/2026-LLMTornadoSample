# 🌪️ 2026-LLMTornadoSample

A .NET sample project demonstrating how to use **LlmTornado** for multimodal AI workflows (text, image, audio).

This repository provides a minimal working example showing how to integrate and execute LLM-powered support workflows using C#.

---

## 📌 Overview

This sample demonstrates:

- Multimodal AI input (text + image + audio)
- Integration with LlmTornado SDK
- Basic agent-style orchestration
- File handling (Base64 / byte arrays)
- Console-based AI response output

This is a learning/reference project — not a production-ready system.

Sample reference article : https://dev.to/lofcz/migrating-to-a-multimodal-ai-framework-a-step-by-step-guide-for-c-developers-4k84

---

## 🏗 Project Structure

```
2026-LLMTornadoSample/
│
├── LLMTornadoSample.slnx
├── LLMTornadoSample.Project/
│   └── Program.cs
└── .gitignore
```

Main logic is implemented inside:

```
LLMTornadoSample.Project/Program.cs
```

---

## 🚀 What the Sample Demonstrates

- Creating a multimodal support agent
- Reading image files
- Reading audio files
- Sending combined prompt + media to an LLM
- Receiving and printing AI-generated solution output

---

## 🧠 Example Usage (From Program.cs)

```csharp
var agent = new MultimodalSupportAgent("your-api-key");

byte[] screenshot = await File.ReadAllBytesAsync("error-screenshot.jpg");
byte[] voiceMemo = await File.ReadAllBytesAsync("customer-complaint.mp3");

string solution = await agent.HandleSupportTicket(
    "The application crashes when I click Submit",
    imageData: screenshot,
    audioData: voiceMemo
);

Console.WriteLine(solution);
```

This example demonstrates:

- Passing text input
- Passing image data
- Passing audio data
- Receiving structured AI output

---

## ⚙️ Prerequisites
