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

    public partial class Tile : Node3D
    {
        static StringName _inputMouseLeft = new StringName("mouse_left");

        [Export]
        public TileType Type { get; set; }

        Item item;
        StaticObject staticObject;

        World world;

        [Export]
        public int x;

        [Export]
        public int y;

        StandardMaterial3D OriginalMaterial;

        private MeshInstance3D meshInstance;

        // Static property to keep track of the selected tile
        private static Tile selectedTile;

        public override void _Ready()
        {

        }

        public Tile Init(World world, int x, int y)
        {
            Type = TileType.Empty;
            this.world = world;
            this.x = x;
            this.y = y;

            Position = new Vector3(x, 0, y);
            Name = "Tile " + x + ", " + y;

            meshInstance = GetNode<MeshInstance3D>("MeshInstance3D");
            if (meshInstance != null)
            {
                // meshInstance.Position = new Vector3(x, 0, y);

                StandardMaterial3D material = new StandardMaterial3D();
                // material.AlbedoColor = new Color(1, 1, 1);

                Random random = new Random();
                Color randomColor = new Color(
                    (float)random.NextDouble(),
                    (float)random.NextDouble(),
                    (float)random.NextDouble()
                );

                material.AlbedoColor = randomColor;
                meshInstance.MaterialOverride = material;

                OriginalMaterial = material;
            }

            return this;
        }

        public void OnInputEvent(Node camera, InputEvent @event, Vector3 click_position, Vector3 click_normal, int shape_idx)
        {
            if (@event is InputEventMouseButton mouseButton)
            {
                if (mouseButton.IsActionPressed(_inputMouseLeft))
                {
                    GD.Print("click on tile ", x, ", ", y);

                    // TODO: Deselect the previously selected tile
                    if (selectedTile != null && selectedTile != this)
                    {
                        selectedTile.Deselect();
                    }

                    // Select the current tile
                    Select();
                }
            }
        }

        private void Select()
        {
            selectedTile = this;
            if (meshInstance != null)
            {
                StandardMaterial3D material = new StandardMaterial3D();
                material.AlbedoColor = new Color(1, 0, 0); // Red color to indicate selection
                meshInstance.MaterialOverride = material;
            }
        }

        private void Deselect()
        {
            if (meshInstance != null)
            {
                meshInstance.MaterialOverride = OriginalMaterial; // Revert to the original material
            }
        }
    }
}
