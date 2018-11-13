using System.Collections.Generic;
using System.Drawing;
using Drawing_Toolkit.Model.Drawable.State;

namespace Drawing_Toolkit.Model.Drawable {
    class GroupDrawable : Drawable {
        private readonly LinkedList<Drawable> drawings = new LinkedList<Drawable>();
        public override DrawingState State {
            get => base.State;
            set {
                base.State = value;
                foreach (var drawing in drawings) drawing.State = value;
            }
        }

        public GroupDrawable(LinkedList<Drawable> drawings) {
            foreach (var drawing in drawings)
                this.drawings.AddLast(drawing);
        }

        public override bool Intersect(Point location) {
            foreach (var drawing in drawings)
                if (drawing.Intersect(location))
                    return true;
            return false;
        }

        public override bool Intersect(Rectangle area) {
            foreach (var drawing in drawings)
                if (drawing.Intersect(area))
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
