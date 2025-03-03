using Godot;
using System;

namespace Vinland
{
    public partial class World : Node
    {
        private Tile[,] tiles;
        int width = 100;
        int height = 100;

        public World()
        {
            GD.Print("Creating world");

            tiles = new Tile[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    tiles[x, y] = new Tile(this, x, y);
                }
            }

            GD.Print("World created");
            GD.Print("Tiles: ", tiles.Length);
            GD.Print("Origen: ", tiles[0, 0]);
        }

        public Tile GetTileAt(int x, int y)
        {
            if (x > width || x < 0 || y > height || y < 0)
            {
                GD.PrintErr("Tile out of bounds");
                return null;
            }
            return tiles[x, y];
        }
    }
}