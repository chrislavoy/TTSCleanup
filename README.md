# TTSCleanup

>[!WARNING]
>This tool has not been fully tested! I've made every attempt to remove the offending code while leaving existing scripts in place but I am not able to test every scenario. **Please backup your save folder before running!**

The goal of this tool is to remove the lua script that replicates itself across all objects in a save file for Tabletop Simulator. It does this by scanning all of your Tabletop Simulator save files line by line to remove any occurrences of the script. It attempts to only remove the offending script and leave any existing lua code in place.

The tool assumes the following things about the offending script:
- It adds itself to the end of existing lua scripts
- It contains the url `obje.glitch.me`
- It adds a large number of spaces to the last line before replicating itself
- The offending code starts with the lua block comment `--[[Object base code]]`

If a line matching these assumptions is found its contents are trimmed to remove the offending script.

By default the tool looks for Tabletop Simulator files at the default Windows directory `%USERPROFILE%\Documents\My Games\Tabletop Simulator\Saves`. If you are on a different platform or use a different directory for save files you can pass the path in as the first argument (see below)

## How to Run
### From Source
1. Have `dotnet` installed with version 7.0 or higher. Download and install the SDK from [Microsoft](https://dotnet.microsoft.com/en-us/download).
2. Download or clone the project locally
3. Open a terminal window and navigate to the folder you put the code into
4. run `dotnet run --project .\TTSCleanup\TTSCleanup.csproj`
   - If you need to use a directory other than the default Windows directory you can pass it in as the first argument `dotnet run --project .\TTSCleanup\TTSCleanup.csproj "\My Custom Path\To\Tabletop Simulator\Saves"`

## Background
I originally tried the [python script](https://drive.google.com/file/d/18iIoMBYqRnJ0gorffbo9KteqkyB9N1gl/view) provided by a user in the TTS Warhammer 40k discord server but it didn't work for me. Shoutout anyways for a good first attempt and inspiration to create this script!
