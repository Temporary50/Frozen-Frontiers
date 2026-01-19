
Frozen Frontiers — Slime Rancher Mod (SRML)

This project adds:
- Snowflake Slime (eats everything; special plort output)
- Snow Carrot (plantable)
- Snowflake food (non-plantable)
- Snowflake Plort
- Visual-only snow ambience ideas (optional hooks)

IMPORTANT:
I can’t compile the final .dll here because SRML and Slime Rancher assemblies
aren’t available in this environment. This ZIP is a READY-TO-BUILD project.
Follow the build steps below and you’ll get the .dll in minutes.

REQUIREMENTS
- Slime Rancher (PC)
- SRML 2.x
- Visual Studio (Community is fine)
- .NET Framework 4.7.2 (or the version SRML requires)

BUILD STEPS
1) Install SRML and run the game once.
2) Open FrozenFrontiers.csproj in Visual Studio.
3) Fix references:
   - Add references to:
     * Assembly-CSharp.dll
     * UnityEngine.dll
     * SRML.dll
   (All found in your Slime Rancher / SRML folders)
4) Build the project (Release).
5) Copy FrozenFrontiers.dll to:
   Slime Rancher/Mods/

NOTES
- Identifiable IDs are registered safely via SRML.
- Visual snow / ambience hooks are stubbed so you can expand them easily.
