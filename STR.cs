public class STROperations
{
    /// <summary>
    /// Takes in the path of an STR file from Amplitude and produces a raw PCM S16LE file at the OutputPath path.
    /// </summary>
    /// <param name="STRPath"></param>
    /// <param name="OutputPath"></param>
    public static void ConvertToRawPCM(string STRPath, string OutputPath)
    {
        using (FileStream STRFile = new FileStream(STRPath, FileMode.Open, FileAccess.Read))
        {
            int len = STRPath.Length;
            using (FileStream RAWFile = new FileStream(OutputPath, FileMode.Create, FileAccess.Write))
            {
                int Interleave = 512;
                int ctr = 0;
                byte[] buffer = new byte[Interleave * 2];
                int Width = 2;

                while (STRFile.Position < STRFile.Length)
                {
                    if (ctr < Interleave)
                    {
                        STRFile.Read(buffer, (ctr / Width) << 2, Width);
                        ctr += Width;
                    }
                    else if (ctr < (Interleave * 2))
                    {
                        STRFile.Read(buffer, (((ctr - Interleave) / Width) << 2) + Width, Width);
                        ctr += Width;
                    }
                    else
                    {
                        RAWFile.Write(buffer, 0, Interleave * 2);
                        ctr = 0;
                        Array.Clear(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}