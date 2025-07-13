class Program
{
    static void Main(string[] args)
    {
        //Initialize program: Create Temp. dir, Generate Unique ID for file and start conversion from STR -> PCM S16LE
        if (!Directory.Exists("tmp"))
        {
            Directory.CreateDirectory("tmp");
        }
        var UUID = Guid.NewGuid();
        switch(args[0])
        {
            case "convertdir":
                //Create directory with the same name as the directory we're scanning from
                var NewDir = new DirectoryInfo(args[1]).Name;
                Directory.CreateDirectory(NewDir);
                foreach (var File in Directory.GetFiles(args[1]))
                {
                    Console.WriteLine($"Converting {File}...");
                    //I just disregard the initial UUID so it's easier to manage in code
                    UUID = Guid.NewGuid();
                    STROperations.ConvertToRawPCM(File, $"tmp/{UUID}");
                    if (Path.GetExtension(File) == ".STR")
                    {
                        if (args[2] == "wav")
                        {
                            ConvertRaw.ToWAV($"tmp/{UUID}", $"{NewDir}/{Path.GetFileNameWithoutExtension(File)}.wav");
                        }
                        else if (args[2] == "mp3")
                        {
                            ConvertRaw.ToMP3($"tmp/{UUID}", $"{NewDir}/{Path.GetFileNameWithoutExtension(File)}.mp3");
                        }
                        Console.WriteLine("Done.");
                    }
                }
                break;
            case null:
                break;
            default:
                if (File.Exists(args[1]))
                {
                    switch (args[1])
                    {
                        case "wav":
                            ConvertRaw.ToWAV($"tmp/{UUID}", Path.GetFileNameWithoutExtension(args[0]) + ".wav");
                            break;
                        case "mp3":
                            ConvertRaw.ToMP3($"tmp/{UUID}", Path.GetFileNameWithoutExtension(args[0]) + ".mp3");
                            break;
                    }
                }

                else
                {
                    Console.WriteLine("invalid usage.");
                }
                break;
        }
        //Too lazy to write a disposal for the Temp. dir, so I just let the Garbage Collector dispose it
        System.GC.Collect();
        System.GC.WaitForPendingFinalizers();
        Directory.Delete("tmp", true);
    }
}