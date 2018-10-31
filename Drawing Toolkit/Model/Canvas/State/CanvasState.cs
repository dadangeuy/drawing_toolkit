using Drawing_Toolkit.Model.Drawing;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Drawing_Toolkit.Model.Canvas.State {
    abstract class CanvasState {
        public virtual void ClickDrawing(LinkedList<DrawingContext> drawings, Point location) {
            Console.WriteLine("No Implementation");
        }

        public virtual void DragDrawing(LinkedList<DrawingContext> drawings, Point from, Point to) {
            Console.WriteLine("No Implementation");
        }
    }
}
