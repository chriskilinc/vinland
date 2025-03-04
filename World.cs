using Godot;
using System;

namespace Vinland
{
    public partial class World : Node3D
    {
        private Tile[,] tiles;
        int width = 100;
        int height = 100;

        public World()
        {
            GD.Print("Creating world");
            var TileScene = GD.Load<PackedScene>("res://tile.tscn");


            // tiles = new Tile[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {   
                    var a = TileScene.Instantiate<Tile>().Init(this, x, y);
                    AddChild(a);
                    // tiles[x, y] = new Tile(this, x, y);
                }
            }

            GD.Print("World created");
            // GD.Print("Tiles: ", tiles.Length);
            // GD.Print("Origen: ", tiles[0, 0]);


            // spawn tiles in world
            // foreach (Tile tile in tiles)
            // {
            //     // TileScene into world
            //     // TileScene.Instantiate<Tile>();


            //     // tile.Position = new Vector3(tile.x, 0, tile.y);
            //     // AddChild(tile);
            // }
        }

        public override void _Ready()
        {
            GD.Print("World ready");
        }

        public override void _Process(double delta)
        {
            // Called every frame. Delta is the elapsed time since the previous frame.
            // Update game logic here.
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