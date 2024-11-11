using DrawingLibrary.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary.Input
{
    public sealed class CustomMouse:ICustomMouse
    {
        private MouseState _previous;
        private MouseState _current;

        private static CustomMouse Instance;
        public static CustomMouse _instance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new CustomMouse();
                }
                return Instance;
            }
        }

        public Point WindowPosition => _current.Position;

        private CustomMouse() { 
            _previous = Mouse.GetState();
            _current = Mouse.GetState();
        }

        public Vector2? GetScreenPosition(IScreen screen)
        {
            if(screen == null)
            {
                throw new ArgumentNullException("Screen cannot be null");
            }

            float screenWidth = screen.Width;
            float screenHeight = screen.Height;

            Rectangle scaledScreen = screen.CalculateDestinationRectangle();

            var xOffset = WindowPosition.X - scaledScreen.X;
            var yOffset = WindowPosition.Y - scaledScreen.Y;

            float posX = (xOffset * screenWidth) / scaledScreen.Width;
            float posY = (yOffset * screenHeight) / scaledScreen.Height;


            if (posX > screenWidth || posX < 0 || posY > screenHeight || posY < 0) {
                return null;
            }

            Vector2 vector2 = new Vector2(posX, posY);

            return vector2;
        }

        public bool IsLeftButtonClicked()
        {
            if(_current.LeftButton == ButtonState.Pressed && _previous.LeftButton == ButtonState.Released)
            {
                return true;
            }
            return false;
        }

        public bool IsLeftButtonDown()
        {
            if(_current.LeftButton == ButtonState.Pressed && _previous.LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            return false;
        }

        public bool IsLeftButtonUp()
        {
            if (_current.LeftButton == ButtonState.Released && _previous.LeftButton == ButtonState.Released)
            {
                return true;
            }
            return false;
        }

        public bool IsMiddleButtonClicked()
        {
            if (_current.MiddleButton == ButtonState.Pressed && _previous.MiddleButton == ButtonState.Released)
            {
                return true;
            }
            return false;
        }

        public bool IsMiddleButtonDown()
        {
            if (_current.MiddleButton == ButtonState.Pressed && _previous.MiddleButton == ButtonState.Pressed)
            {
                return true;
            }
            return false;
        }

        public bool IsRightButtonClicked()
        {
            if (_current.RightButton == ButtonState.Pressed && _previous.RightButton == ButtonState.Released)
            {
                return true;
            }
            return false;
        }

        public bool IsRightButtonDown()
        {
            if (_current.RightButton == ButtonState.Pressed && _previous.RightButton == ButtonState.Pressed)
            {
                return true;
            }
            return false;
        }

        public void Update()
        {
            _previous = _current;
            _current = Mouse.GetState();
        }
    }
}
