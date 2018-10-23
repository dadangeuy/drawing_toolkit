using System.Drawing;
using Drawing_Toolkit.Model.Shape.Api;
using Drawing_Toolkit.Model.Shape.Impl;
using Drawing_Toolkit.Model.Tool.Api;

namespace Drawing_Toolkit.Model.Tool.Impl {
    class RectangleTool : ITool, IShapeTool {
        public IShape CreateShape(Point from, Point to) {
            IShape shape = new RectangleShape();
            shape.SetShape(from, to);
            return shape;
        }
    }
}
