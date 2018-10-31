using Drawing_Toolkit.Model.Drawing;
using Drawing_Toolkit.Model.Tool.Api;
using System.Collections.Generic;
using System.Drawing;

namespace Drawing_Toolkit.Model.Tool.Impl {
    class SelectionTool : ITool {
        public DrawingContext FindIntersectDrawing(Point location, LinkedList<DrawingContext> drawings) {
            foreach (var drawing in drawings)
                if (drawing.Intersect(location))
                    return drawing;
            return null;
        }
    }
}
