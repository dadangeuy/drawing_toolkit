using Drawing_Toolkit.Model.Shape.Api;
using Drawing_Toolkit.Model.Shape.Impl;
using Drawing_Toolkit.Model.Tool.Api;
using System.Drawing;

namespace Drawing_Toolkit.Model.Tool.Impl {
    class EllipseTool : ITool, IShapeTool {
        public IShape CreateShape(Point from, Point to) {
            IShape shape = new EllipseShape();
            shape.SetShape(from, to);
            return shape;
        }
    }
}
