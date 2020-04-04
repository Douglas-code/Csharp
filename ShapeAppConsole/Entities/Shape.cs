using ShapeAppConsole.Entities.Enums;

namespace ShapeAppConsole.Entities
{
    public abstract class Shape
    {
        public Color Color { get; set; }

        public Shape(Color color)
        {
            Color = color;
        }

        public abstract double Area();
    }
}