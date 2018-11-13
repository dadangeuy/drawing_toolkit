﻿using Drawing_Toolkit.Common;
using Drawing_Toolkit.Model.Drawing.State;
using System.Drawing;

namespace Drawing_Toolkit.Model.Drawing {
    abstract class DrawingObject : StateContext<DrawingState> {
        public DrawingObject() : base(EditState.INSTANCE) { }
        public abstract bool Intersect(Point location);
        public abstract bool Intersect(Rectangle area);
        public abstract void Move(Point offset);
        public abstract void Resize(Point from, Point to);
        public abstract void Render(Graphics graphics);

        public static readonly DrawingObject EMPTY = new EmptyDrawingContext();
        private class EmptyDrawingContext : DrawingObject {
            public override bool Intersect(Point location) {
                return false;
            }

            public override bool Intersect(Rectangle area) {
                return false;
            }

            public override void Move(Point offset) {
            }

            public override void Render(Graphics graphics) {
            }

            public override void Resize(Point from, Point to) {
            }
        }
    }
}