using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace PyramidPanic
{
    public static class Input
    {

        //Fields

        private static KeyboardState ks, oks;
        private static MouseState ms, oms;
        private static Rectangle mouseRectangle;

        //constructor word een maal aangeroepen
        static Input()
        {
            mouseRectangle =  new Rectangle(0, 0, 1, 1);
            ks = Keyboard.GetState();
            ms = Mouse.GetState();
            oks = ks;
            oms = ms;
        }
        //update methode
        public static void Update()
        {
            oks = ks;
            oms = ms;
            ks = Keyboard.GetState();
            ms = Mouse.GetState();


        }
        //LevelDetector
        public static bool DetectKeydown(Keys key)
        {
            return ks.IsKeyDown(key);

        }

        //Edgedetector voor buttons
        public static bool EdgeDetectKeyDown(Keys key)
        {
            return (ks.IsKeyDown(key) && oks.IsKeyUp(key));
        }


        //Edgedetectio voor een linksklik van e muis
        public static bool MouseEdgeDetectPressLeft()
        {
            return(ms.LeftButton == ButtonState.Pressed && oms.LeftButton == ButtonState.Released);

        }
        public static bool MouseEdgeDetectPressRight()
        {
            return (ms.LeftButton == ButtonState.Pressed && oms.LeftButton == ButtonState.Released);

        }

        public static Vector2 MousePosition()
       {
            return new Vector2 (ms.X, ms.Y);

       }
        //Rectangle position.
        public static Rectangle MouseRectangle()
        {
            mouseRectangle.X = ms.X;
            mouseRectangle.Y = ms.Y;
            return mouseRectangle;
        }
    }


   
}
