using Microsoft.Xna.Framework;
using StardewValley;

namespace ValleyTalk.Platform
{
    public static class AndroidHelper
    {
        public static bool IsAndroid => false;

        public static int GetVirtualKeyboardHeight()
        {
            if (!IsAndroid) return 0;
            return Game1.graphics.Viewport.Height / 3;
        }

        public static Vector2 AdjustPositionForKeyboard(Vector2 originalPosition)
        {
            if (!IsAndroid) return originalPosition;
            var keyboardHeight = GetVirtualKeyboardHeight();
            var screenHeight = Game1.graphics.Viewport.Height;
            if (originalPosition.Y > screenHeight - keyboardHeight)
                return new Vector2(originalPosition.X, screenHeight - keyboardHeight - 100);
            return originalPosition;
        }
    }
}
