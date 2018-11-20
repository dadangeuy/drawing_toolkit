using System.Collections.Generic;
using System.Drawing;
using Drawing_Toolkit.model.drawable.state;

namespace Drawing_Toolkit.model.drawable.impl {
    internal class GroupDrawable : Drawable {
        private readonly LinkedList<Drawable> Drawings = new LinkedList<Drawable>();

        public GroupDrawable(LinkedList<Drawable> drawings) {
            foreach (var drawing in drawings)
                this.Drawings.AddLast(drawing);
        }

        public override DrawingState State {
            get => base.State;
            set {
                base.State = value;
                foreach (var drawing in Drawings) drawing.State = value;
            }
        }

        public override bool Intersect(Point location) {
            foreach (var drawing in Drawings)
                if (drawing.Intersect(location))
                    return true;
            return false;
        }

        public override bool Intersect(Rectangle area) {
            foreach (var drawing in Drawings)
                if (drawing.Intersect(area))
                    return true;
            return false;
        }

        public override void Move(Point offset) {
            foreach (var drawing in Drawings) drawing.Move(offset);
            NotifyUpdate();
        }

        public override void Render(Graphics graphics) {
            foreach (var drawing in Drawings)
                drawing.Render(graphics);
        }

        public override void Resize(Point from, Point to) {
            foreach (var drawing in Drawings) drawing.Resize(from, to);
            NotifyUpdate();
        }
    }
}