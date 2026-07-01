# ClarifEye

ClarifEye is an assistive-technology web platform that combines ASP.NET Core with Python AI services to help users analyze visual information such as traffic lights, colors, text, and scenery.

## Features

- Traffic light detection backed by a Python AI model
- Text detection and extraction workflow
- Color recognition workflow
- Scenery synthesis and text-to-speech oriented user flows
- Survey and statistics modules
- ASP.NET Core Identity authentication
- Layered solution structure with separate web, data, infrastructure, common, and AI projects

## Tech Stack

- ASP.NET Core MVC
- Entity Framework Core
- ASP.NET Core Identity
- Python AI services
- Keras/TensorFlow model assets
- HTML, CSS, and JavaScript

## Solution Structure

```text
ClarifEye.AI/
  ColorDetector/
  TextDetector/
  TrafficLightsDetector/
ClarifEye.Common/
ClarifEye.Data/
ClarifEye.Infrastructure/
ClarifEye.Web/
ClarifEye.sln
```

## Getting Started

### Prerequisites

- .NET SDK
- Python 3
- SQL Server or another configured EF Core provider

### Run the web application

```bash
git clone https://github.com/alex-stefanov/ClarifEye.git
cd ClarifEye
dotnet restore ClarifEye.sln
dotnet build ClarifEye.sln
dotnet run --project ClarifEye.Web
```

### Run the AI services

Each detector has its own Python requirements file:

```bash
cd ClarifEye.AI/TrafficLightsDetector
python -m venv .venv
source .venv/bin/activate
pip install -r requirements.txt
python api.py
```

Repeat the same pattern for the other detector folders when those services are needed.

## Configuration

Application settings live under `ClarifEye.Web/appsettings*.json`. Keep connection strings, API keys, and production secrets outside source control by using environment variables or user secrets.

## Testing

```bash
dotnet test ClarifEye.sln
```

## License

This project is licensed under the MIT License.
