using System.Drawing;

namespace Drawing_Toolkit.Model.Drawing.Shape {
    interface IShape {
        void SetGraphics(Graphics graphics);
        void SetShape(Point from, Point to);
        void Move(Point offset);
        bool Intersect(Point location);
        void RenderShape();
        void RenderShapeContainer();
    }
}
