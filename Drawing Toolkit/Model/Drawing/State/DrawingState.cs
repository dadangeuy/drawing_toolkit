using Drawing_Toolkit.Model.Drawing.Shape;
using System;
using System.Drawing;

namespace Drawing_Toolkit.Model.Drawing.State {
    abstract class DrawingState {
        public abstract void Render(IShape shape);
        public virtual void Move(IShape shape, Point offset) {
            Console.WriteLine("No Implementation");
        }
    }
}
