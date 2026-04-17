using System;
using System.Collections.Generic;

namespace Microsoft.Xna.Framework {
    public class GameTime {
        public TimeSpan TotalGameTime;
        public TimeSpan ElapsedGameTime;
    }
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
        public static Color Red;
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
    public class SpriteFont { public Microsoft.Xna.Framework.Vector2 MeasureString(string s) => new(); }
    public class SpriteBatch {
        public void Draw(Texture2D t, Microsoft.Xna.Framework.Rectangle r, Microsoft.Xna.Framework.Color c) { }
        public void DrawString(SpriteFont f, string s, Microsoft.Xna.Framework.Vector2 pos, Microsoft.Xna.Framework.Color c) { }
        public void Begin() { }
        public void End() { }
    }
    public class GraphicsDevice { }
    public class RenderTarget2D : Texture2D { }
}

namespace Microsoft.Xna.Framework.Input {
    public struct KeyboardState { }
    public enum Keys { Enter, Escape, Back, Tab, A, C, V, X, Z, Y }
}

namespace Microsoft.Xna.Framework.Content {
    public class ContentManager { }
}

namespace StardewValley {
    public enum Season { Spring, Summer, Fall, Winter }
    public enum Gender { Male, Female, Undefined }
    public class WorldDate {
        public int Year; public string Season; public int DayOfMonth;
        public WorldDate(int year, string season, int day) { }
    }
    public class LocalizedContentManager {
        public enum LanguageCode { en, de, es, fr, hu, it, ja, ko, pt, ru, tr, zh }
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
    public class Friendship {
        public int Points;
        public bool IsMarried() => false;
        public bool IsDating() => false;
        public bool IsEngaged() => false;
    }
    public class Crop { public string indexOfHarvest; }
    public class FarmAnimal { public string displayName; public string type; }
    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue> { }
    public class Game1 {
        public static Farmer player;
        public static List<GameLocation> locations = new();
        public static GameLocation currentLocation;
        public static string currentSeason;
        public static int pixelZoom = 4;
        public static Microsoft.Xna.Framework.Graphics.SpriteFont dialogueFont;
        public static Microsoft.Xna.Framework.Graphics.Texture2D mouseCursors;
        public static void drawDialogue(NPC n) { }
        public static void DrawDialogue(NPC n) { }
        public static void activeClickableMenu_setter(Menus.IClickableMenu menu) { }
        public static Menus.IClickableMenu activeClickableMenu;
    }
    public class Farmer {
        public string Name;
        public GameLocation currentLocation;
        public Gender gender;
        public Dictionary<string, Friendship> friendshipData = new();
        public List<Characters.Child> getChildren() => new();
        public int getFriendshipHeartLevelForNPC(string name) => 0;
    }
    public class GameLocation {
        public string Name;
        public List<NPC> characters = new();
        public virtual Dialogue GetLocationOverrideDialogue(NPC n) => null;
    }
    public class NPC : Character {
        public string Name;
        public Dialogue CurrentDialogue;
        public Gender gender;
        public int Age;
        public void setNewDialogue(string text, bool add = false, bool clear = false) { }
        public Microsoft.Xna.Framework.Vector2 getTileLocation() => new();
        public virtual void checkAction(Farmer f, GameLocation l) { }
        public virtual void addMarriageDialogue(string file, string key, bool gendered = false, params string[] args) { }
        public virtual void PushTemporaryDialogue(Dialogue d) { }
        public virtual Dialogue TryGetDialogue(string key) => null;
        public virtual Dialogue TryToRetrieveDialogue(string key) => null;
        public virtual Dialogue tryToRetrieveDialogue(string key) => null;
        public virtual Dialogue TryToGetMarriageSpecificDialogue(string key) => null;
        public virtual Dialogue tryToGetMarriageSpecificDialogue(string key) => null;
        public virtual void CheckForNewCurrentDialogue(int hearts, bool onlyCheck = false) { }
        public virtual void checkForNewCurrentDialogue(int hearts, bool onlyCheck = false) { }
        public virtual string GetGiftReaction(Object gift) => "";
        public bool isMarried() => false;
        public bool isDivorcedFrom(Farmer f) => false;
        public string getTermOfSpousalEndearment() => "";
    }
    public class Character { }
    public class Item { }
    public class Object : Item { public string Name; public string Category; public string DisplayName; }
    public class Dialogue {
        public Dialogue(NPC speaker, string dialogueText) { }
        public Dialogue(NPC speaker, string file, string key) { }
        public NPC speaker;
        public void Clear() { }
        public virtual string chooseResponse(List<Response> responses) => "";
        public virtual Dialogue TryGetDialogue(string key) => null;
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
        public virtual void receiveKeyPress(Microsoft.Xna.Framework.Input.Keys key) { }
        public virtual void update(Microsoft.Xna.Framework.GameTime time) { }
        public virtual void gameWindowSizeChanged(Microsoft.Xna.Framework.Rectangle oldBounds, Microsoft.Xna.Framework.Rectangle newBounds) { }
        public virtual void emergencyShutDown() { }
        public virtual void cleanupBeforeExit() { }
        public virtual bool overrideSnappyMenuCursorMovementBan() => false;
        public bool destroy;
        public int xPositionOnScreen, yPositionOnScreen, width, height;
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
    public class CharacterData { public string DisplayName; public string Age; public string Gender; }
    public class HomeRenovation { }
}

namespace StardewValley.GameData.Characters {
    public class CharacterData { }
}

namespace StardewValley.Objects {
    public class Hat : StardewValley.Object { }
    public class Trinket : StardewValley.Object { }
}

namespace StardewValley.Objects.Trinkets {
    public class Trinket : StardewValley.Object { }
}

namespace StardewValley.Buildings {
    public class Building { public string buildingType; }
}
