using System.Drawing;

namespace Drawing_Toolkit.Model.Shape.Api {
    interface IShape : IDrawable, ISelectable {
        void SetShape(Point from, Point to);
        void Move(Point difference);
        bool Intersect(Point point);
    }
}
