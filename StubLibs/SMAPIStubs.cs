using System;

namespace StardewModdingAPI.Events {
    public interface IGameLoopEvents {
        event EventHandler<GameLaunchedEventArgs> GameLaunched;
    }
    public interface IInputEvents {
        event EventHandler<ButtonPressedEventArgs> ButtonPressed;
    }
    public class GameLaunchedEventArgs : EventArgs { }
    public class ButtonPressedEventArgs : EventArgs {
        public ICursorPosition Cursor { get; set; }
        public StardewModdingAPI.SButton Button { get; set; }
    }
    public interface ICursorPosition {
        Microsoft.Xna.Framework.Vector2 GrabTile { get; }
    }
}

namespace StardewModdingAPI {
    public enum SButton { MouseLeft, MouseRight, ControllerA }

    public abstract class Mod {
        public IModHelper Helper { get; set; }
        public IMonitor Monitor { get; set; }
        public IManifest ModManifest { get; set; }
        public abstract void Entry(IModHelper helper);
    }
    public interface IModHelper {
        IModEvents Events { get; }
        IGameContentHelper GameContent { get; }
        IDataHelper Data { get; }
        T ReadConfig<T>() where T : class, new();
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
    }
    public interface IGameContentHelper { }
    public interface IDataHelper { }
    public enum LogLevel { Trace, Debug, Info, Warn, Error, Alert }

    public static class SButtonExtensions {
        public static bool IsActionButton(this SButton button) => true;
    }
}
