//code for the AI project https://github.com/sonuubhagat11-spec/levelsAI
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
    

    static async Task Main() {
    Console.WriteLine("yeah so theres gonna be a lot of text but thats ok :-D (pause is intended) !READ READD  btw if your gpu is weak ahh you should save some ram and it might be slower ofc not trying to cal you broke. Its ok though. You need at least 700 MB spare.");
    await Task.Delay(2000);
        string Finder = @"C:\LLM_Models";
        string modles = Path.Combine(Finder, "Qwen2.5-1.5b-instruct-q8_0.gguf");
        if (!File.Exists(modles))
        {
            Directory.CreateDirectory(Finder);
            using var wheat = new HttpClient();
            wheat.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");

            var response = await wheat.GetAsync("https://huggingface.co/bartowski/Qwen2.5-1.5B-Instruct-GGUF/resolve/main/Qwen2.5-1.5B-Instruct-Q8_0.gguf?download=true", HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            long totAhh = response.Content.Headers.ContentLength ?? -1;

            using var RAP = await response.Content.ReadAsStreamAsync();
            using var Foinder = new FileStream(modles, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true);

            byte[] buffer = new byte[8192];
            long wreck = 0;
            int poo;

            Console.CursorVisible = false;

            while ((poo = await RAP.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                await Foinder.WriteAsync(buffer, 0, poo);
                wreck += poo;

                if (totAhh!= -1)
                {
                    double War = ((double)wreck / totAhh) * 100;
                    double Fah = (double)wreck / 1024 / 1024;
                    double Pinder = (double)totAhh / 1024 / 1024;

                    
                    Console.Write($"\rModel is downloading [{(int)War}%] ({Fah:F1} MB / {Pinder:F1} MB)   ");
                }
            }

            Console.CursorVisible = true;
            Console.WriteLine("Ai is downloaded");
        }
        var frigit = new ModelParams(modles) { ContextSize = 1750 };
            using var model =LLamaWeights.LoadFromFile(frigit);
            using var joedeshvspincoiny = model.CreateContext(frigit);//oefwhuiwaheu9fhuwaehfuihwfuoihawgy7efgywiahgbnapw9guhhudiwpojfwiqwjiofhjiofwuwahfuichatgpteatspoopooanddrinkspeepee
            var ashki = new InteractiveExecutor(joedeshvspincoiny); 
            string PatnPatherher = Path.Combine(Finder, "chat_history.txt");
            using StreamWriter chatLogger = new StreamWriter(PatnPatherher, append: true);
        //Ai chat nice
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
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.ForegroundColor = ConsoleColor.White; 
        while (true)
        {
            
            Console.Write("\nAsk anything- ");
            string? RIggedriggytherabitmonke = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(RIggedriggytherabitmonke) || RIggedriggytherabitmonke.Equals("exit", StringComparison.OrdinalIgnoreCase))
                break;

           chatLogger.WriteLine($"User: {RIggedriggytherabitmonke}");
            var skinnyinipresetfileMACISOFILEDOBSISAVIRUSDONTDOWNLOADFORMITFOOL =
                new InferenceParams() { MaxTokens = 1000, AntiPrompts = new[] {"<|im_end|>", "<|endoftext|>"} }; 

            Console.WriteLine("Thinking...");

            string webText = "";
            string webUrl = "";

            //BIG GUNS :-D
            if (RIggedriggytherabitmonke.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                RIggedriggytherabitmonke.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                webUrl = RIggedriggytherabitmonke;
                

            webText = await ScrapeDirectLinkAsync(webUrl);

            }
            else
            {
                (webText, webUrl) = await SearchWebWithSourceAsync(RIggedriggytherabitmonke);
            }
            

            Console.WriteLine($"{webText}");



            string prompt = $"<|im_start|>system\n" +
                            $"You are a perfect chatbot. You will take time reading sources and going in link nad finding the best sources WITHOUT hallucinating within 30 seconds.: {webText}\n" +
                            $"If the text did not help you, answer with your own internal knowledge combined with sources. Always mention the source link at the end: Source: {webUrl}\n" +
                            $"<|im_end|>\n" +
                            $"<|im_start|>user\n{RIggedriggytherabitmonke}<|im_end|>\n" +
                            $"<|im_start|>assistant\n";


            Console.Write("finderAI- ");

            await foreach (var token in ashki.InferAsync(prompt, skinnyinipresetfileMACISOFILEDOBSISAVIRUSDONTDOWNLOADFORMITFOOL))
            {
                Console.Write(token);
            }
            Console.WriteLine();
        } 


        static async Task<(string text, string url)> SearchWebWithSourceAsync(string query)
        {
            try
            {
                using var willpower = new HttpClient();
                willpower.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");

                string lnk = $"https://html.duckduckgo.com/html/?q={Uri.EscapeDataString(query)}";
                string hitmill = await  willpower.GetStringAsync(lnk);

                int BoZoNG =  hitmill.IndexOf("class=\"result__snippet\"");
                if (BoZoNG != -1)
                {
                    int BlobbyClips =  hitmill.IndexOf(">", BoZoNG) + 1;
                    int  BlobbyDips =  hitmill.IndexOf("</a>",  BlobbyClips);
                    string FINThereRBroHasBeenThere = hitmill.Substring( BlobbyClips,  BlobbyDips -  BlobbyClips);
            
                    string Poop = System.Text.RegularExpressions.Regex.Replace(FINThereRBroHasBeenThere, "<.*?>", "").Trim();
            
                    string Pee = $"https://html.duckduckgo.com/html/?q={Uri.EscapeDataString(query)}";
                    return (Poop, Pee);
                }
            }
            catch { }

            return ("", "");
        } 

        static async Task<string> ScrapeDirectLinkAsync(string url)
        {
            try
            {
                using var copilot = new HttpClient();
                copilot.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");

                string htmlContent = await  copilot.GetStringAsync(url);

                string a = System.Text.RegularExpressions.Regex.Replace(htmlContent, "<script.*?</script>", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
                a = System.Text.RegularExpressions.Regex.Replace(a, "<style.*?</style>", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
               a = System.Text.RegularExpressions.Regex.Replace(a, "<.*?>", ""); 

                if (a.Length > 1500)
                {
                    a = a.Substring(0, 1500) + "... [Text truncated]";
                }

                return a.Trim();
            } 
            catch (Exception ex)
            {
                return $"it didnt get link GRR: {ex.Message}";
            }
        }
    } 
}
//Bye!!
