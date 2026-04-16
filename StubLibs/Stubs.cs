using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace StardewValley {
    public class Game1 {
        public static Farmer player;
        public static List<GameLocation> locations = new();
        public static GameLocation currentLocation;
        public static string currentSeason;
        public static void drawDialogue(NPC n) { }
    }
    public class Farmer { public string Name; public GameLocation currentLocation; }
    public class GameLocation { 
        public string Name; 
        public List<NPC> characters = new(); 
    }
    public class NPC : Character { 
        public string Name; 
        public Dialogue CurrentDialogue; 
        public void setNewDialogue(string text, bool add = false, bool clear = false) { }
        public Vector2 getTileLocation() => new Vector2();
    }
    public class Character { }
    public class Item { }
    public class Object : Item { }
    public class Dialogue {
        public Dialogue(NPC speaker, string dialogueText) { }
        public NPC speaker;
        public void Clear() { }
    }
}
namespace StardewValley.Events { }
namespace StardewValley.Menus {
    public class DialogueBox : IDisposable {
        public DialogueBox(StardewValley.Dialogue dialogue) { }
        public void Dispose() { }
    }
}
namespace Microsoft.Xna.Framework {
    public struct Vector2 { 
        public float X, Y; 
        public static bool operator ==(Vector2 a, Vector2 b) => a.X == b.X && a.Y == b.Y;
        public static bool operator !=(Vector2 a, Vector2 b) => !(a == b);
        public override bool Equals(object obj) => obj is Vector2 other && this == other;
        public override int GetHashCode() => (X, Y).GetHashCode();
    }
    public struct Color { public static Color White; }
}
