using System.Drawing;

namespace Drawing_Toolkit.Model.Drawing {
    class GroupDrawingContext : IDrawing {
        private readonly IDrawing[] drawings;

        public GroupDrawingContext(IDrawing[] drawings) {
            this.drawings = drawings;
        }

        public bool Intersect(Point location) {
            foreach (var drawing in drawings)
                if (drawing.Intersect(location))
                    return true;
            return false;
        }

        public void Move(Point offset) {
            foreach (var drawing in drawings)
                drawing.Move(offset);
        }

        public void Render(Graphics graphics) {
            foreach (var drawing in drawings)
                drawing.Render(graphics);
        }

        public void Resize(Point from, Point to) {
            foreach (var drawing in drawings)
                drawing.Resize(from, to);
        }
    }
}
