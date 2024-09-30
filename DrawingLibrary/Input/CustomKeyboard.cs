using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary.Input
{
    public class CustomKeyboard : ICustomKeyboard
    {
        KeyboardState _previous;
        KeyboardState _current;

        private static CustomKeyboard Instance;
        public static CustomKeyboard _instance
        {
            get
            {
                if(Instance == null)
                {
                    Instance = new CustomKeyboard();
                }
                return Instance;
            }
        }

        public CustomKeyboard() { 
            _previous = Keyboard.GetState();
            _current = Keyboard.GetState();
        }
        public bool IsKeyClicked(Keys key)
        {

            //compare previous key state to current key state
            if (_previous[key] != _current[key])
            {
                return true;
            }
            return false;
        }

        public bool IsKeyDown(Keys key)
        {
            return _current.IsKeyDown(key);
        }

        public void Update()
        {
            _previous = _current;
            _current = Keyboard.GetState();
        }
    }
}
