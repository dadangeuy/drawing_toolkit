using System.Collections.Generic;
using System.Drawing;
using Drawing_Toolkit.Model.Shape.Api;
using Drawing_Toolkit.Model.Tool.Api;

namespace Drawing_Toolkit.Model.Tool.Impl {
    class SelectionTool : ITool, IPointerTool {
        public void Drag(Point from, Point to, List<IShape> shapes) {
            foreach (IShape shape in shapes) shape.Deselect();
            shapes.Reverse();
            foreach (IShape shape in shapes) {
                if (shape.Intersect(from)) {
                    Point difference = new Point(to.X - from.X, to.Y - from.Y);
                    shape.Move(difference);
                    shape.Select();
                    return;
                }
            }
            shapes.Reverse();
        }
    }
}
