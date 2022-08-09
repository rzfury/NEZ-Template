using Microsoft.Xna.Framework.Input;

namespace RZGame.Core.Utilities
{
    public static class KeyboardHelper
    {
        private static KeyboardState _currentKeyState;
        private static KeyboardState _previousKeyState;

        public static KeyboardState GetState()
        {
            _previousKeyState = _currentKeyState;
            _currentKeyState = Keyboard.GetState();
            return _currentKeyState;
        }

        public static bool GetKeyDown(Keys key)
        {
            return _currentKeyState.IsKeyDown(key);
        }

        public static bool GetKeyDownOnce(Keys key)
        {
            return _currentKeyState.IsKeyDown(key) && !_previousKeyState.IsKeyDown(key);
        }
    }
}
