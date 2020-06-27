# Twitch-Plays-VGC
A bot coded in C# to allow a twitch chat to play Pokemon online doubles

# Setup:
1. Make sure you have a switch running [Atmosphere CFW](https://github.com/Atmosphere-NX/Atmosphere/releases "Atmosphere Download Page") and have installed [sys-botbase](https://github.com/olliz0r/sys-botbase "sys-botbase Page")
2. Make sure the team you want to use is in your party.
3. Set the current screen to the VS screen (the screen where you can choose between "Battle Stadium" and "Live Competition")

# Usage:
1. Set your information in `settings.txt` but **do not remove or change anything to the left of the = signs**
*note: you shouldn't have to change switch port, but this is for further customization in the future*
2. Run `TwitchBotSide.exe` and watch the magic

# Known Issues:
1. Unable to do ranked battles, this will be fixed on July 1st, 2020.
2. Occasionally Backs out of the VS screen rather than going into Battle Stadium
  -FIX: go back to VS screen and restart the bot
3. This program might be detected as a virus.
  -Don't worry, it's not. All of the source code can be seen here :)
  
# Credits:
1. Huge thanks to [kwsch's SysBot.NET sourcecode](https://github.com/kwsch/SysBot.NET) for helping with socket and data interactions. As this is my first C# project.
2. [olliz0r's sys-botbase](https://github.com/olliz0r/sys-botbase) for allowing the bot automation.
3. [Atmosphere as always.](https://github.com/Atmosphere-NX/Atmosphere)
