using Drawing_Toolkit.Model.Drawing;
using Drawing_Toolkit.Model.Drawing.Shape;
using Drawing_Toolkit.Model.Tool.Api;
using System.Drawing;

namespace Drawing_Toolkit.Model.Tool.Impl {
    class EllipseTool : ITool, IShapeTool {
        public DrawingContext CreateDrawing(Point from, Point to) {
            IShape shape = new EllipseShape();
            shape.SetContainer(from, to);
            return new DrawingContext(shape);
        }
    }
}
