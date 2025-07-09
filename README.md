# ampstr-sharp
An Amplitude (2003) Song File Extractor

# Credits
[Maxton](https://github.com/maxton) - Original AmpStr C Snippet<br>
[Mariteaux/Cammy](https://github.com/mariteaux) - Edited Maxton's AmpStr C Snippet - Taken from [their blog post](https://archives.somnolescent.net/web/mari_v3/blog/2021/04/i-want-to-be-synthesized/)

## Gathering usable files
The STR files this program works with are located inside of the /AUDIO directory of an Amplitude copy's disc.
Dump your Amplitude copy and either mount it in Explorer or extract it by other means to gather STR files ready to be used by ampstr-sharp.

# Usage
AmpStr-Sharp is a command line only program, but comes with an incredibly simple syntax because of it's internal simplicity. AmpStr-Sharp currently has two audio formats available to convert to, MP3 and WAV. You'll need to specify one of these audio formats with each command you execute.
### Directory Conversion
To convert a directory, use the argument string `convertdir %DIRECTORYPATH% %AUDIOFORMAT%`. This will produce a directory in your working directory named the same as the path you provided's final member and place the files inside of it. `(Ex. E:\AUDIO -> %WORKINGDIR%\AUDIO)`.
### Single File Conversion
To convert a single STR file, use the argument string `%STRFILEPATH% %AUDIOFORMAT%`. This will produce a file with the same name as the original file with your file format's file extension suffixed onto it `(Ex. E:\AUDIO\DRUMNBAS.STR -> DRUMNBAS.wav/DRUMNBAS.mp3)`.

## Audio Formats (Extended)
The audio formats that AmpStr-Sharp works with are WAV and MP3, the following will break them down more if you're indecisive upon which one to use.

### WAV
A lossless format, WAV will give you the best sounding audio, but consumes the most disk space (26-45 MB/song). If you're under the assumption the quality of the music isn't very good due to the timeframe Amplitude released, you'd be surprised what the Playstation 2 was able to produce. [Example YouTube video here](https://youtu.be/pQ5WQRo1wXc)
### MP3
A lossy (compressed) format, MP3 will save you on disk space (~4 MB/song). 

# Baseline! BASELINE!
We got fools on the case and they're giving me a baseline!
