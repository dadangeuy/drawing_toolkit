using System.Drawing;

namespace Drawing_Toolkit.Model.Drawing {
    interface IDrawing {
        bool Intersect(Point location);
        void Move(Point offset);
        void Resize(Point from, Point to);
        void Render(Graphics graphics);
    }
}
