using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BBModMenu;
using MelonLoader;
using UnityEngine;
using UnityEngine.UIElements;

namespace JumpMacro
{
    public class JumpMacroMod : MelonMod
    {
        private bool toggle_enable;
        private string jumpKey;

        public override void OnLateInitializeMelon()
        {
            MelonLogger.Msg("JumpMacro starting to load.");

            GameObject gameUI = GameObject.Find("GameUI");
            GameUI _gameUI = gameUI.GetComponent<GameUI>();
            List<UIScreen> screens = typeof(GameUI)?.GetField("screens", BindingFlags.NonPublic | BindingFlags.Instance)
            ?.GetValue(_gameUI) as List<UIScreen>;

            ModMenu _modMenu = screens?.FirstOrDefault(screen => screen is ModMenu) as ModMenu;
            if (_modMenu is null)
            {
                MelonLogger.Msg("ModMenu not found");
                return;
            }

            string categoryName = "Auto Jump";
            var autoJumpSettings = _modMenu.AddSetting(categoryName);

            var enableToggle = _modMenu.CreateToggle(categoryName, "Enable", true);
            enableToggle.RegisterValueChangedCallback(delegate (ChangeEvent<bool> b)
            {
                toggle_enable = b.newValue;
            });

            var key = _modMenu.CreateHotKey(categoryName, "JumpMacroKey", KeyCode.Mouse1);
            jumpKey = key.Value;
            key.OnChanged += newKey =>
            {
                MelonLogger.Msg($"Jump Macro Key : {newKey}");
                jumpKey = newKey;
            };


            var togglesGroup = _modMenu.CreateGroup("Toggles");

            var toggleWrapper = _modMenu.CreateWrapper();
            toggleWrapper.Add(_modMenu.CreateLabel("Enable Jump Macro"));
            toggleWrapper.Add(enableToggle);

            var keyWrapper = _modMenu.CreateWrapper();
            keyWrapper.Add(_modMenu.CreateLabel("Jump Macro Key"));
            keyWrapper.Add(key.Root);

            togglesGroup.Add(toggleWrapper);
            togglesGroup.Add(keyWrapper);

            autoJumpSettings.Add(togglesGroup);

            toggle_enable = enableToggle.value;
        }


        public override void OnFixedUpdate()
        {
            if (!toggle_enable) return;
            if (Utils.IsHotkeyHeld(jumpKey) && !GameModeManager.Instance.IsGameModeActive<MenuGameMode>()) GameModeManager.Instance.player.spaceDown = true;
        }
    }
}
