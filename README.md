# Traffic Utils

Traffic Utils is the supported successor of Reset Traffic, Jam Threshold, and Accidents Be Gone. One Options page has a tab for each. Disable the three older mods before you test. Leaving them on runs each system twice.

Jam Threshold and Accidents Be Gone start disabled. Turn each on in its own Options tab. Reset Traffic stays available from its tab.

Version 0.0.1 alpha. Published on Paradox as mod 160488: https://mods.paradoxplaza.com/mods/160488/Windows

Source: https://github.com/mafra-code/cs2-traffic_utils

On first launch, if `Mods_TrafficUtils.coc` is missing, values are copied from `Mods_ResetTraffic.coc`, `Mods_JamThreshold.coc`, and `Mods_AccidentsBeGone.coc`. Those old files are left in place. Later launches use `Mods_TrafficUtils.coc` only.

Build Debug (do not Release-build while the game is running):

```
dotnet build TrafficUtils/TrafficUtils.csproj -c Debug
```

License: MIT.
