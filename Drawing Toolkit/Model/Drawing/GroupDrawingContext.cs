using System.Collections.Generic;
using System.Drawing;

namespace Drawing_Toolkit.Model.Drawing {
    class GroupDrawingContext : DrawingApi {
        private readonly LinkedList<DrawingApi> drawings;

        public GroupDrawingContext(LinkedList<DrawingApi> drawings) {
            this.drawings = drawings;
        }

        public override bool Intersect(Point location) {
            foreach (var drawing in drawings)
                if (drawing.Intersect(location))
                    return true;
            return false;
        }

        public override void Move(Point offset) {
            foreach (var drawing in drawings)
                drawing.Move(offset);
        }

        public override void Render(Graphics graphics) {
            foreach (var drawing in drawings)
                drawing.Render(graphics);
        }

        public override void Resize(Point from, Point to) {
            foreach (var drawing in drawings)
                drawing.Resize(from, to);
        }
    }
}
