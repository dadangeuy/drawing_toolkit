using Drawing_Toolkit.Model.Shape.Api;
using System.Drawing;

namespace Drawing_Toolkit.Model.Tool.Api {
    interface IShapeTool {
        IShape CreateShape(Point from, Point to);
    }
}
