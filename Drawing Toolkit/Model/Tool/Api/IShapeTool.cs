using Drawing_Toolkit.Model.Drawing;
using System.Drawing;

namespace Drawing_Toolkit.Model.Tool.Api {
    interface IShapeTool {
        DrawingContext CreateDrawing(Point from, Point to);
    }
}
