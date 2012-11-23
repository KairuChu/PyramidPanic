using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;

namespace PyramidPanic
{
    public class Level

    {
        //fields
        private PyramidPanic game;
        private string levelPath;
        private List<String> lines;
        private Block [,] block;
        private Picture background;
        private const int GRIDWIDTH = 32;
        private const int GRIDHEIGHT=32;
        private List<Picture> treasures;
        private Panel panel;



        //constructor
        public Level (PyramidPanic game, int levelIndex)
        {
            this.game = game;
            this.levelPath = @"Content\PlaySceneAssets\levels\0.txt";
            this.LoadAssets();

        }
        private void LoadAssets()
        {

            this.treasures = new List<Picture>();
            this.panel = new Panel(this.game, new Vector2(0f, 448f));
            this.lines = new List<string>();
            StreamReader reader = new StreamReader(this.levelPath);
            string line = reader.ReadLine();
            int width = line.Length;
            //Console.WriteLine(line);
            while (line != null)
            {
                lines.Add(line);
                line = reader.ReadLine();
                // Console.WriteLine(line);
            }
            int height = lines.Count;
            this.block = new Block [width, height];
            reader.Close();

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    char blockElement = this.lines[row][column];
                    this.block[column,row] = LoadBlock(blockElement, column * GRIDWIDTH, row * GRIDHEIGHT);
                }
            }


        }
        private Block LoadBlock(char blockElement, int x, int y)
        {
            switch (blockElement)
            {
                case 'a':
                    this.treasures.Add(new Picture(this.game, @"PlaySceneAssets\Treasures\Treasure2", new Vector2(x, y)));
                    return new Block (this.game, @"Transparant", new Vector2(x,y), BlockCollision.Passable, 'a');
                case 'b':
                    this.treasures.Add(new Picture(this.game, @"PlaySceneAssets\Treasures\Treasure1", new Vector2(x, y)));
                    return new Block(this.game, @"Transparant", new Vector2(x, y), BlockCollision.Passable, 'b');
                case 'c':
                    this.treasures.Add(new Picture(this.game, @"PlaySceneAssets\Treasures\Scarab", new Vector2(x, y)));
                    return new Block(this.game, @"Transparant", new Vector2(x, y), BlockCollision.Passable, 'c');
                case 'd':
                    this.treasures.Add(new Picture(this.game, @"PlaySceneAssets\Treasures\Potion", new Vector2(x, y)));
                    return new Block(this.game, @"Transparant", new Vector2(x, y), BlockCollision.Passable, 'd');
                case 'w':
                        return new Block(this.game, @"Block", new Vector2(x,y), BlockCollision.NotPassable, 'w');
                case 'x':
                        return new Block(this.game, @"Wall1", new Vector2(x, y), BlockCollision.NotPassable, 'w');
                case 's':
                        return new Block(this.game, @"Wall2", new Vector2(x, y), BlockCollision.NotPassable, 'w');
                case 'y':
                        return new Block(this.game, @"Door", new Vector2(x, y), BlockCollision.NotPassable, 'y');
                case '@':
                        this.background = new Picture(this.game, @"PlaySceneAssets\background\Background2", new Vector2(x,y));
                        return new Block(this.game, @"Block", new Vector2(x, y), BlockCollision.NotPassable, 'w');
                case '.':
                       return new Block(this.game, @"Transparant", new Vector2(x,y), BlockCollision.Passable, '.');
                default:
                    return new Block(this.game, @"Transparant", new Vector2(x,y), BlockCollision.Passable, '.');

            }

        }
        public void Update(GameTime gameTime)
        {


        }
        public void Draw(GameTime gameTime)
        {
            this.background.Draw(gameTime);
            this.panel.Draw(gameTime);

            for (int row =0; row < this.block.GetLength(1); row++)
            {

                for (int column = 0; column < this.block.GetLength(0); column++)
                {
                    this.block[column, row].Draw(gameTime );
                }
            }
            foreach (Picture treasure in this.treasures)
            {
                treasure.Draw(gameTime);
            }

        }


    }
    }
