# LevelsAI — Installation & Usage

## Windows — ARM64 and x64

### 1. Download

Download the **release folder** for your CPU architecture:

* **Windows x64** → `win-x64`
* **Windows ARM64** → `win-arm64`

> **Important:** Make sure you download the correct architecture for your PC.

### 2. Extract

Unzip the downloaded folder somewhere on your computer.

**Do not run the `.exe` directly from inside the ZIP file.**

### 3. Run LevelsAI

Open the extracted folder and double-click:

`ConsoleApp2.exe`

### 4. Wait for the model

The first time you run LevelsAI, it will download the required AI model.

> **An internet connection is required for the first launch.**

Once the model finishes downloading, you can start using LevelsAI.

---

# macOS and Linux — ARM64 and x64

## Requirements

You need:

* **.NET** installed
* An internet connection for the first model download
* The correct release for your CPU architecture

You can check whether .NET is installed with:

```bash
dotnet --version
```

If that command is not found, install the appropriate **.NET runtime/SDK** for your operating system and architecture.

## 1. Download

Download the appropriate **release folder**, not the outdated source-code folder.

Choose:

* `linux-x64` — Linux Intel/AMD 64-bit
* `linux-arm64` — Linux ARM64
* `osx-x64` — macOS Intel
* `osx-arm64` — Apple Silicon

## 2. Extract

Unzip the downloaded folder.

## 3. Open Terminal

Change to the extracted LevelsAI directory:

```bash
cd /path/to/levelsAI/chatbot
```

Replace `/path/to/levelsAI/chatbot` with the actual location of the downloaded folder.

## 4. Give the application permission to run

```bash
chmod +x ConsoleApp2
```

## 5. Run LevelsAI

```bash
./ConsoleApp2
```

The first launch may take some time because the AI model needs to be downloaded.

Once the download finishes, LevelsAI is ready to use.

---

# Important Notes

### Release folders vs. source code

**Use the release folders for normal use.**

The source-code folders are currently outdated and are intended for development. They may not contain the same files or configuration as the latest releases.

### CPU architecture

Make sure you select the correct build:

| Platform | 64-bit Intel/AMD | ARM64         |
| -------- | ---------------- | ------------- |
| Windows  | `win-x64`        | `win-arm64`   |
| Linux    | `linux-x64`      | `linux-arm64` |
| macOS    | `osx-x64`        | `osx-arm64`   |

### Model download

LevelsAI downloads its required model when it is first launched.

Make sure you have:

* An active internet connection
* Enough free disk space
* Permission to write to the application/model directory

The initial download can take a while depending on your internet speed.

### Subsequent launches

After the model has been downloaded, you normally **do not need to download it again**. Simply launch `ConsoleApp2` again.

### If the application does not start

First make sure that:

1. You extracted the entire release folder.
2. You downloaded the correct architecture.
3. You have the required .NET runtime.
4. You are running the application from its extracted folder.
5. You have an internet connection if the model has not been downloaded yet.

For Linux/macOS, make sure you ran:

```bash
chmod +x ConsoleApp2
```

Then:

```bash
./ConsoleApp2
```

---

## For Developers

If you are building LevelsAI from source rather than using a release, install the required LLamaSharp packages:

```bash
dotnet add package LLamaSharp
dotnet add package LLamaSharp.Backend.Cpu
```

**These commands are for building the source code and are not normally required when using a pre-built release.**
##Also, It might say "CPU buffer is complete. You can restart the Console.
