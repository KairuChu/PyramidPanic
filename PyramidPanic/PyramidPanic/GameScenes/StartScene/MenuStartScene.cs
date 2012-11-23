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
    public class MenuStartScene
    {
        //fields
        private Picture start, load, help, score, quit, leveledit;
        private PyramidPanic game;
        private enum ButtonState {Start, Load, Help, Score, Quit, LevelEditor }
        private ButtonState buttonState;
        private Color buttonColorActive = Color.Gold;
        private int top, left, space;

        //constructor
        public MenuStartScene(PyramidPanic game)
        {
            this.game = game;
            this.Initialize();
        }

        //Initialize
        private void Initialize()
        {
            this.buttonState = ButtonState.Start;
            this.top = 430;
            this.left = 3;
            this.space = 107;
            this.Loadcontent();

        }

        //Update
        public void Update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyDown(Keys.Right))
            {
                if (this.buttonState < ButtonState.LevelEditor)
                {
                    this.buttonState++;
                }
            }
            if (Input.EdgeDetectKeyDown(Keys.Left))
            {
                if (this.buttonState > ButtonState.Start)
                {
                    this.buttonState--;
                }
            }

            if ((this.buttonState == ButtonState.Start) || 
                (this.start.Rectangle.Intersects(Input.MouseRectangle()) && Input.MouseEdgeDetectPressRight()))
            {
                this.buttonState = ButtonState.Start;
                if (Input.MouseEdgeDetectPressRight() && this.start.Rectangle.Intersects (Input.MouseRectangle()) || Input.EdgeDetectKeyDown(Keys.Enter))
                {
                this.game.GameState = new PlayScene(this.game);
                }
            }

            if ((this.buttonState == ButtonState.Load)|| 
                (this.load.Rectangle.Intersects(Input.MouseRectangle()) ))
            {
                this.buttonState = ButtonState.Load;
                if (Input.MouseEdgeDetectPressRight() || Input.EdgeDetectKeyDown(Keys.Enter))
                {
                    this.game.GameState = new LoadScene(this.game);
                }
            }

            if ((this.buttonState == ButtonState.Help)|| 
                (this.help.Rectangle.Intersects(Input.MouseRectangle()) ))
            {
                this.buttonState = ButtonState.Help;
                if (Input.MouseEdgeDetectPressRight()|| Input.EdgeDetectKeyDown(Keys.Enter))
                {
                    this.game.GameState = new HelpScene(this.game);
                }
            }

            if ((this.buttonState == ButtonState.Score)|| 
                (this.score.Rectangle.Intersects(Input.MouseRectangle()) ))
            {
                this.buttonState = ButtonState.Score;
                if (Input.MouseEdgeDetectPressRight() || Input.EdgeDetectKeyDown(Keys.Enter) )
                {
                    this.game.GameState = new ScoreScene(this.game);
                }
            }

            if ((this.buttonState == ButtonState.Quit) ||
                (this.quit.Rectangle.Intersects(Input.MouseRectangle()) ))
            {
                this.buttonState = ButtonState.Quit;
                if (Input.MouseEdgeDetectPressRight() || Input.EdgeDetectKeyDown(Keys.Enter))
                {
                    this.game.Exit();
                }
            }

            if (( this.buttonState == ButtonState.LevelEditor)|| 
                (this.leveledit.Rectangle.Intersects(Input.MouseRectangle()) ))
            {
                this.buttonState = ButtonState.LevelEditor;
                if (Input.MouseEdgeDetectPressRight() || Input.EdgeDetectKeyDown(Keys.Enter))
                {
                    this.game.GameState = new LevelEditorScene(this.game);
                }
            }
            // collioson testif (this.start.Rectangle.Intersects(Input.MouseRectangle()))
            //{
            //    this.game.Exit();
           // }
        }

        //loadContent
        private void Loadcontent()
        {
            this.start = new Picture(this.game,
                "Buttons\\Button_start",new Vector2(this.left,this.top));
            this.load = new Picture(this.game,
                "Buttons\\Button_load",new Vector2(this.left+this.space,this.top));
            this.help = new Picture(this.game,
                "Buttons\\Button_help", new Vector2(this.left + this.space * 2, this.top));
            this.score = new Picture(this.game,
                "Buttons\\Button_scores", new Vector2(this.left + this.space * 3, this.top));
            this.quit = new Picture(this.game, "Buttons\\Button_quit", new Vector2(this.left + this.space * 4, this.top));
            this.leveledit = new Picture(this.game,
                "Buttons\\Button_leveleditor", new Vector2(this.left+this.space*5, this.top));
            
            
           
            
            
        }

        //update


        //draw
        public void Draw(GameTime gameTime)
        {
            Color buttonColorStart = Color.White;
            Color buttonColorLoad = Color.White;
            Color buttonColorHelp = Color.White;
            Color buttonColorScore = Color.White;
            Color buttonColorQuit = Color.White;
            Color buttonColorLevelEditor = Color.White;


            switch (this.buttonState)
            {
                case ButtonState.Start:
                    buttonColorStart = this.buttonColorActive;
                    break;
                case ButtonState.Load:
                    buttonColorLoad = this.buttonColorActive;
                    break;
                case ButtonState.Help:
                    buttonColorHelp = this.buttonColorActive;
                    break;
                case ButtonState.Score:
                     buttonColorScore =  this.buttonColorActive;
                    break;
                case ButtonState.Quit:
                    buttonColorQuit = this.buttonColorActive;
                    break;
                case ButtonState.LevelEditor: 
                    buttonColorLevelEditor = this.buttonColorActive;
                    break;
                default:
                    break;

            }

            this.start.Draw(this.game.SpriteBatch, buttonColorStart);
            this.load.Draw(this.game.SpriteBatch, buttonColorLoad);
            this.help.Draw(this.game.SpriteBatch, buttonColorHelp);
            this.score.Draw(this.game.SpriteBatch, buttonColorScore);
            this.leveledit.Draw(this.game.SpriteBatch, buttonColorLevelEditor);          
            this.quit.Draw(this.game.SpriteBatch, buttonColorQuit);
        }
        
    }
}
