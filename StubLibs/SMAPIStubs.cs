using System;

namespace StardewModdingAPI {
    public enum SButton { MouseLeft, MouseRight, ControllerA }
    public abstract class Mod {
        public IModHelper Helper { get; set; }
        public IMonitor Monitor { get; set; }
        public IManifest ModManifest { get; set; }
        public abstract void Entry(IModHelper helper);
        public virtual object GetApi() => null;
    }
    public interface IModHelper {
        IModEvents Events { get; }
        IGameContentHelper GameContent { get; }
        IDataHelper Data { get; }
        ITranslationHelper Translation { get; }
        IModRegistry ModRegistry { get; }
        T ReadConfig<T>() where T : class, new();
        void WriteConfig<T>(T config) where T : class, new();
    }
    public interface ITranslationHelper { }
    public interface IModRegistry {
        T GetApi<T>(string uniqueId) where T : class;
    }
    public static class Context {
        public static bool IsWorldReady { get; set; }
        public static bool IsPlayerFree { get; set; }
    }
    public interface IMonitor { void Log(string message, LogLevel level = 0); }
    public interface IManifest { string UniqueID { get; } }
    public interface IModEvents {
        Events.IGameLoopEvents GameLoop { get; }
        Events.IInputEvents Input { get; }
        Events.IPlayerEvents Player { get; }
    }
    public interface IGameContentHelper { }
    public interface IDataHelper { }
    public enum LogLevel { Trace, Debug, Info, Warn, Error, Alert }
    public static class SButtonExtensions {
        public static bool IsActionButton(this SButton button) => true;
    }
    public interface IKeyboardSubscriber {
        void RecieveTextInput(char inputChar);
        void RecieveTextInput(string text);
        void RecieveCommandInput(char command);
        void RecieveSpecialInput(Microsoft.Xna.Framework.Input.Keys key);
        bool Selected { get; set; }
    }
    public class KeybindList {
        public static KeybindList Parse(string s) => new KeybindList();
        public override string ToString() => "";
    }
}

namespace StardewModdingAPI.Utilities {
    public class PerScreen<T> {
        public T Value { get; set; }
        public PerScreen() { }
        public PerScreen(Func<T> init) { Value = init(); }
    }
}

namespace StardewModdingAPI.Events {
    public interface IGameLoopEvents {
        event EventHandler<GameLaunchedEventArgs> GameLaunched;
        event EventHandler<UpdateTickedEventArgs> UpdateTicked;
        event EventHandler<SavingEventArgs> Saving;
    }
    public interface IInputEvents {
        event EventHandler<ButtonPressedEventArgs> ButtonPressed;
    }
    public interface IPlayerEvents { }
    public class GameLaunchedEventArgs : EventArgs { }
    public class UpdateTickedEventArgs : EventArgs { }
    public class SavingEventArgs : EventArgs { }
    public class ButtonPressedEventArgs : EventArgs {
        public ICursorPosition Cursor { get; set; }
        public StardewModdingAPI.SButton Button { get; set; }
    }
    public interface ICursorPosition {
        Microsoft.Xna.Framework.Vector2 GrabTile { get; }
        Microsoft.Xna.Framework.Vector2 ScreenPixels { get; }
    }
}
