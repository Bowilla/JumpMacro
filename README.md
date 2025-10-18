# Jump Macro Mod
Don't have g502 unlocked scroll wheel?\
Having difficulty setting up a good macro?\
This jump macro is comfortable to use and performs well.

Integration with [BBModMenu](https://thunderstore.io/c/beton-brutal/p/Beton_Bros/BBModMenu/)
allows you to change your macro keybind quickly.\
Option for disabling macro.

*Shoutout to Lupheron for setting WR with this macro!*

### Technical Details
This macro operates in [FixedUpdate()](https://docs.unity3d.com/ScriptReference/MonoBehaviour.FixedUpdate.html) which runs every `0.02ms`(50 per second).\
This offers the best consistency and works much better for players on low FPS.

The macro works by setting `player.spaceDown = true;` which ensures you will jump as early as possible.\
This macro only activates while playing maps and has no effect in the menu or on other applications (unlike [AutoHotkey](https://www.autohotkey.com/)).

## Install
This mod is used with [MelonLoader](https://github.com/LavaGang/MelonLoader).\
Mod dependency: [BBModMenu](https://github.com/MiaouZart/BBModMenu)\
You may also get this mod on [Thunderstore](https://thunderstore.io/c/beton-brutal/p/Beton_Bros/JumpMacro/).
