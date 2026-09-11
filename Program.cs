using System;
using System.Text.Json;
using System.IO;
using System.Net.Http;
using System.Diagnostics;
using System.Threading.Tasks;
using LLama;
using LLama.Common;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("yeah so theres gonna be a lot of text but thats ok :-D (pause is intended) !READ READD  btw if your gpu is weak ahh you should save some ram and it might be slower ofc not trying to cal you broke. Its ok though. You need at least 700 MB spare.");
        await Task.Delay(2000);

        string Finder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            "AIModels"
        );

        string modles = Path.Combine(Finder, "qwen2.5-1.5b-instruct-q8_0.gguf");
        Console.WriteLine($"the model paths: {modles}");
        Console.WriteLine($"if file exist?: {File.Exists(modles)}");
        string pintupindu = modles + ".part";

        Directory.CreateDirectory(Finder);

        if (!await waterinyomout(modles))
        {
            if (File.Exists(pintupindu))
            {
                try
                {
                    File.Delete(pintupindu);
                }
                catch
                {
                }
            }

            await waiterinyomout(modles, pintupindu);
        }

        var frigit = new ModelParams(modles)
        {
            ContextSize = 1750
        };

        using var model = LLamaWeights.LoadFromFile(frigit);
        using var joedeshvspincoiny = model.CreateContext(frigit);
        var ashki = new InteractiveExecutor(joedeshvspincoiny);

        string PatnPatherher = Path.Combine(Finder, "chat_history.txt");

        using StreamWriter chatLogger = new StreamWriter(
            PatnPatherher,
            append: true
        );

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("___________________ ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("|    |     /    |  | finderAI 2026 Stacy 1.0.0. (placeholder name) ");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("|    |    /     |  | Coded by a beginner, so feel free to complain.");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("|        /_        | pew pew pew- wait isnt that finder so short   ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("|     \\___|__/     | Day 1 project- wait why is he so flat");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("|__________|_______| Open source. Chat with ai NOW.");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Sudo takes a finder from toml the cargo lock ): )-:");
        Console.ForegroundColor = ConsoleColor.White;

        while (true)
        {
            Console.Write("\nAsk anything- ");
            string? RIggedriggytherabitmonke = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(RIggedriggytherabitmonke) ||
                RIggedriggytherabitmonke.Equals("exit", StringComparison.OrdinalIgnoreCase))
                break;

            chatLogger.WriteLine($"User: {RIggedriggytherabitmonke}");

            var skinnyinipresetfileMACISOFILEDOBSISAVIRUSDONTDOWNLOADFORMITFOOL =
                new InferenceParams()
                {
                    MaxTokens = 1000,
                    AntiPrompts = new[] { "<|im_end|>", "<|endoftext|>" }
                };

            Console.WriteLine("Thinking...");

            string webText = "";
            string webUrl = "";

            if (RIggedriggytherabitmonke.StartsWith(
                    "http://",
                    StringComparison.OrdinalIgnoreCase) ||
                RIggedriggytherabitmonke.StartsWith(
                    "https://",
                    StringComparison.OrdinalIgnoreCase))
            {
                webUrl = RIggedriggytherabitmonke;
                webText = await ScrapeDirectLinkAsync(webUrl);
            }
            else
            {
                (webText, webUrl) =
                    await SearchWebWithSourceAsync(RIggedriggytherabitmonke);
            }

            Console.WriteLine($"{webText}");

            string prompt =
                $"<|im_start|>system\n" +
                $"You are a perfect chatbot. You will take time reading sources and going in link nad finding the best sources WITHOUT hallucinating within 30 seconds.: {webText}\n" +
                $"If the text did not help you, answer with your own internal knowledge combined with sources. Always mention the source link at the end: Source: {webUrl}\n" +
                $"<|im_end|>\n" +
                $"<|im_start|>user\n{RIggedriggytherabitmonke}<|im_end|>\n" +
                $"<|im_start|>assistant\n";

            Console.Write("finderAI- ");

            await foreach (var token in ashki.InferAsync(
                prompt,
                skinnyinipresetfileMACISOFILEDOBSISAVIRUSDONTDOWNLOADFORMITFOOL))
            {
                Console.Write(token);
            }

            Console.WriteLine();
        }

        static async Task<bool> waterinyomout(string path)
        {
            if (!File.Exists(path))
                return false;

            try
            {
                var info = new FileInfo(path);

                if (info.Length < 100_000_000)
                {
                    File.Delete(path);
                    return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        static async Task waiterinyomout(string destination, string temporary)
        {
            Console.WriteLine("Model is downloading...");

            using var Roblot = new HttpClient();

            Roblot.DefaultRequestHeaders.UserAgent.ParseAdd(
                "Mozilla/5.0"
            );

            string yintuyindu =
                "https://huggingface.co/Qwen/Qwen2.5-1.5B-Instruct-GGUF/resolve/main/qwen2.5-1.5b-instruct-q8_0.gguf?download=true";

            using var RobingTheLocks = await Roblot.GetAsync(
                yintuyindu,
                HttpCompletionOption.ResponseHeadersRead
            );

            RobingTheLocks.EnsureSuccessStatusCode();

            long OUfhwo =
                RobingTheLocks.Content.Headers.ContentLength ?? -1;

            await using var pinder =
                await RobingTheLocks.Content.ReadAsStreamAsync();

            byte[] buffer = new byte[8192];
            long wreck = 0;
            int poo;

            Console.CursorVisible = false;

            await using (var pintupindu = new FileStream(
                temporary,
                FileMode.Create,
                FileAccess.Write,
                FileShare.None,
                8192,
                true))
            {
                while ((poo = await pinder.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    await pintupindu.WriteAsync(buffer, 0, poo);
                    wreck += poo;

                    if (OUfhwo > 0)
                    {
                        double War = ((double)wreck / OUfhwo) * 100;
                        double Fah = (double)wreck / 1024 / 1024;
                        double Pinder = (double)OUfhwo / 1024 / 1024;

                        Console.Write(
                            $"\rModel is downloading [{(int)War}%] ({Fah:F1} MB / {Pinder:F1} MB)   "
                        );
                    }
                }

                await pintupindu.FlushAsync();
            }

            Console.CursorVisible = true;

            if (OUfhwo > 0 && wreck != OUfhwo)
            {
                try
                {
                    File.Delete(temporary);
                }
                catch
                {
                }

                throw new IOException(
                    $"Model download was incomplete. Expected {OUfhwo} bytes but received {wreck} bytes."
                );
            }

            if (File.Exists(destination))
                File.Delete(destination);

            File.Move(temporary, destination);

            Console.WriteLine("\nAi is downloaded");
        }

        static async Task<(string text, string url)> SearchWebWithSourceAsync(string query)
        {
            try
            {
                using var willpower = new HttpClient();

                willpower.DefaultRequestHeaders.Add(
                    "User-Agent",
                    "Mozilla/5.0 (Windows NT 10.0; Win64; x64)"
                );

                string lnk =
                    $"https://html.duckduckgo.com/html/?q={Uri.EscapeDataString(query)}";

                string hitmill = await willpower.GetStringAsync(lnk);

                int BoZoNG =
                    hitmill.IndexOf("class=\"result__snippet\"");

                if (BoZoNG != -1)
                {
                    int BlobbyClips =
                        hitmill.IndexOf(">", BoZoNG) + 1;

                    int BlobbyDips =
                        hitmill.IndexOf("</a>", BlobbyClips);

                    if (BlobbyClips > 0 &&
                        BlobbyDips > BlobbyClips)
                    {
                        string FINThereRBroHasBeenThere =
                            hitmill.Substring(
                                BlobbyClips,
                                BlobbyDips - BlobbyClips
                            );

                        string Poop =
                            System.Text.RegularExpressions.Regex.Replace(
                                FINThereRBroHasBeenThere,
                                "<.*?>",
                                ""
                            ).Trim();

                        string Pee =
                            $"https://html.duckduckgo.com/html/?q={Uri.EscapeDataString(query)}";

                        return (Poop, Pee);
                    }
                }
            }
            catch
            {
            }

            return ("", "");
        }

        static async Task<string> ScrapeDirectLinkAsync(string url)
        {
            try
            {
                using var copilot = new HttpClient();

                copilot.DefaultRequestHeaders.Add(
                    "User-Agent",
                    "Mozilla/5.0"
                );

                string htmlContent =
                    await copilot.GetStringAsync(url);

                string a =
                    System.Text.RegularExpressions.Regex.Replace(
                        htmlContent,
                        "<script.*?</script>",
                        "",
                        System.Text.RegularExpressions.RegexOptions.IgnoreCase |
                        System.Text.RegularExpressions.RegexOptions.Singleline
                    );

                a =
                    System.Text.RegularExpressions.Regex.Replace(
                        a,
                        "<style.*?</style>",
                        "",
                        System.Text.RegularExpressions.RegexOptions.IgnoreCase |
                        System.Text.RegularExpressions.RegexOptions.Singleline
                    );

                a =
                    System.Text.RegularExpressions.Regex.Replace(
                        a,
                        "<.*?>",
                        ""
                    );

                if (a.Length > 1500)
                    a = a.Substring(0, 1500) + "... [Text truncated]";

                return a.Trim();
            }
            catch (Exception ex)
            {
                return $"it didnt get link GRR: {ex.Message}";
            }
        }
    }
}
