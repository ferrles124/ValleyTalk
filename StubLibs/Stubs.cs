using System;
using System.Collections.Generic;

namespace Microsoft.Xna.Framework {
    public struct Vector2 {
        public float X, Y;
        public Vector2(float x, float y) { X = x; Y = y; }
        public static Vector2 Zero = new Vector2(0, 0);
        public static bool operator ==(Vector2 a, Vector2 b) => a.X == b.X && a.Y == b.Y;
        public static bool operator !=(Vector2 a, Vector2 b) => !(a == b);
        public override bool Equals(object obj) => obj is Vector2 other && this == other;
        public override int GetHashCode() => (X, Y).GetHashCode();
    }
    public struct Color {
        public static Color White;
        public static Color Black;
        public static Color Gray;
        public Color(int r, int g, int b, int a = 255) { }
    }
    public struct Rectangle {
        public int X, Y, Width, Height;
        public Rectangle(int x, int y, int w, int h) { X=x; Y=y; Width=w; Height=h; }
        public bool Contains(int x, int y) => false;
        public bool Contains(Point p) => false;
        public static Rectangle Empty = new Rectangle();
    }
    public struct Point {
        public int X, Y;
        public Point(int x, int y) { X = x; Y = y; }
    }
}

namespace Microsoft.Xna.Framework.Graphics {
    public class Texture2D { public int Width; public int Height; }
    public class SpriteFont { }
    public class SpriteBatch {
        public void Draw(Texture2D t, Rectangle r, Color c) { }
        public void DrawString(SpriteFont f, string s, Microsoft.Xna.Framework.Vector2 pos, Color c) { }
    }
    public class GraphicsDevice { }
}

namespace Microsoft.Xna.Framework.Input {
    public struct KeyboardState { }
    public enum Keys { Enter, Escape, Back, Tab }
}

namespace Microsoft.Xna.Framework.Content {
    public class ContentManager { }
}

namespace StardewValley {
    public enum Season { Spring, Summer, Fall, Winter }
    public class WorldDate {
        public int Year; public string Season; public int DayOfMonth;
        public WorldDate(int year, string season, int day) { }
    }
    public class LanguageCode { }
    public class DialogueLine {
        public string Text;
        public DialogueLine(string text) { Text = text; }
    }
    public class Response {
        public string responseKey, responseText;
        public Response(string key, string text) { responseKey = key; responseText = text; }
    }
    public class MarriageDialogueReference {
        public MarriageDialogueReference(string file, string key, bool gendered = false, params string[] args) { }
        public Dialogue GetDialogue(NPC n) => null;
    }
    public class Child : NPC { }
    public class Game1 {
        public static Farmer player;
        public static List<GameLocation> locations = new();
        public static GameLocation currentLocation;
        public static string currentSeason;
        public static int pixelZoom = 4;
        public static void drawDialogue(NPC n) { }
        public static void DrawDialogue(NPC n) { }
    }
    public class Farmer { public string Name; public GameLocation currentLocation; public List<Child> getChildren() => new(); }
    public class GameLocation {
        public string Name;
        public List<NPC> characters = new();
        public virtual Dialogue GetLocationOverrideDialogue(NPC n) => null;
    }
    public class NPC : Character {
        public string Name;
        public Dialogue CurrentDialogue;
        public void setNewDialogue(string text, bool add = false, bool clear = false) { }
        public Microsoft.Xna.Framework.Vector2 getTileLocation() => new();
        public virtual void checkAction(Farmer f, GameLocation l) { }
        public virtual void addMarriageDialogue(string file, string key, bool gendered = false, params string[] args) { }
        public virtual void PushTemporaryDialogue(Dialogue d) { }
        public virtual Dialogue TryGetDialogue(string key) => null;
        public virtual Dialogue TryToRetrieveDialogue(string key) => null;
        public virtual Dialogue TryToGetMarriageSpecificDialogue(string key) => null;
        public virtual void CheckForNewCurrentDialogue(int hearts, bool onlyCheck = false) { }
        public virtual string GetGiftReaction(StardewValley.Object gift) => "";
    }
    public class Character { }
    public class Item { }
    public class Object : Item { public string Name; public string Category; }
    public class Dialogue {
        public Dialogue(NPC speaker, string dialogueText) { }
        public Dialogue(NPC speaker, string file, string key) { }
        public NPC speaker;
        public void Clear() { }
        public virtual string chooseResponse(List<Response> responses) => "";
    }
}

namespace StardewValley.Events {
    public class SavingEventArgs : EventArgs { }
}

namespace StardewValley.Menus {
    public class IClickableMenu {
        public virtual void draw(Microsoft.Xna.Framework.Graphics.SpriteBatch b) { }
        public virtual void receiveLeftClick(int x, int y, bool playSound = true) { }
        public virtual void receiveRightClick(int x, int y, bool playSound = true) { }
        public virtual void update(GameTime time) { }
        public virtual void gameWindowSizeChanged(Microsoft.Xna.Framework.Rectangle oldBounds, Microsoft.Xna.Framework.Rectangle newBounds) { }
        public virtual void emergencyShutDown() { }
        public bool destroy;
    }
    public class ClickableTextureComponent {
        public Microsoft.Xna.Framework.Rectangle bounds;
        public bool visible = true;
        public string name;
        public ClickableTextureComponent(string name, Microsoft.Xna.Framework.Rectangle bounds, string label, string hoverText, Microsoft.Xna.Framework.Graphics.Texture2D texture, Microsoft.Xna.Framework.Rectangle sourceRect, float scale, bool drawShadow = false) { this.name = name; this.bounds = bounds; }
        public void draw(Microsoft.Xna.Framework.Graphics.SpriteBatch b) { }
        public bool containsPoint(int x, int y) => false;
    }
    public class DialogueBox : IClickableMenu, IDisposable {
        public DialogueBox(StardewValley.Dialogue dialogue) { }
        public void Dispose() { }
    }
}

namespace StardewValley.Network {
    public class NetCollection<T> : List<T> { }
}

namespace StardewValley.Characters {
    public class Child : StardewValley.NPC { }
}

namespace StardewValley.GameData {
    public class CharacterData { }
}

namespace StardewValley.Objects {
    public class Hat : StardewValley.Object { }
}

namespace Xna.Framework {
    public class GameTime { public TimeSpan TotalGameTime; public TimeSpan ElapsedGameTime; }
}

namespace Microsoft.Xna.Framework {
    public class GameTime { public TimeSpan TotalGameTime; public TimeSpan ElapsedGameTime; }
}
