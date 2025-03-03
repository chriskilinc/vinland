using Godot;
using System;

namespace Vinland
{
    public class Item
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }

    public class StaticObject
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }

    public enum TileType
    {
        Empty,
        Floor
    }

    public partial class Tile
    {
        public TileType Type { get; set; }

        Item item;
        StaticObject staticObject;

        World world;
        int x;
        int y;

        public Tile(World world, int x, int y)
        {
            Type = TileType.Empty;
            this.world = world;
            this.x = x;
            this.y = y;
        }
    }
}
