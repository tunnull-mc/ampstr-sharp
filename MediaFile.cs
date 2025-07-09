/*
 I wanted this codebase to be easier to manage and add onto, so it is split into static voids
 that are easier to break down and manage instead of a long Program.cs file.
 */

using NAudio.Wave;
public class ConvertRaw
{
    /// <summary>
    /// Takes in the path of a PCM S16LE file and converts it into a WAV file at the OutputFile path. (Direct conversion)
    /// </summary>
    /// <param name="InputFile"></param>
    /// <param name="OutputFile"></param>
    public static void ToWAV(string InputFile, string OutputFile)
    {
        var Stream = new RawSourceWaveStream(File.OpenRead(InputFile), new WaveFormat(48000, 16, 2));
        WaveFileWriter.CreateWaveFile(OutputFile, Stream);
    }
    /// <summary>
    /// Takes in the path of a PCM S16LE file and converts it into an MP3 file at the OutputFile path. (Lossy conversion)
    /// </summary>
    /// <param name="InputFile"></param>
    /// <param name="OutputFile"></param>
    public static void ToMP3(string InputFile, string OutputFile)
    {
        var Stream = new RawSourceWaveStream(File.OpenRead(InputFile), new WaveFormat(48000, 16, 2));
        MediaFoundationEncoder.EncodeToMp3(Stream, OutputFile);
    }
}