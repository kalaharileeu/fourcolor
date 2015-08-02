using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Input;

namespace fourcolors
{
    class InputManager
    {
        KeyboardState currentkeystate, prevkeystate;

        private static InputManager instance;

        public static InputManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new InputManager();
                return instance;
            }
        }

        public void Update()
        {
            prevkeystate = currentkeystate;
            if (!ScreenManager.Instance.IsTransitioning)
                currentkeystate = Keyboard.GetState();
        }

        public bool KeyPressed(params Keys[] keys)
        {
            foreach(Keys key in keys)
            {
                if (currentkeystate.IsKeyDown(key) && prevkeystate.IsKeyUp(key))
                    return true;
            }
            return false;
        }

        public bool KeyReleased(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (currentkeystate.IsKeyUp(key) && prevkeystate.IsKeyDown(key))
                    return true;
            }
            return false;
        }

        public bool KeyDown(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (currentkeystate.IsKeyDown(key))
                    return true;
            }
            return false;
        }
    }
}
