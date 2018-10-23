using Drawing_Toolkit.Model.Shape.Api;
using System.Collections.Generic;
using System.Drawing;

namespace Drawing_Toolkit.Model.Tool.Api {
    interface IPointerTool {
        void Drag(Point from, Point to, List<IShape> shape);
    }
}
