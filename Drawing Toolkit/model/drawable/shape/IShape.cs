using System.Drawing;

namespace Drawing_Toolkit.model.drawable.shape {
    internal interface IShape {
        void SetGraphics(Graphics graphics);
        void SetShape(Point from, Point to);
        void Move(Point offset);
        bool Intersect(Point location);
        bool Intersect(Rectangle area);
        void RenderShape();
        void RenderShapeContainer();
    }
}