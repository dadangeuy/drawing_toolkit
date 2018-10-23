using System;
using System.Drawing;

namespace Drawing_Toolkit.Model {
    abstract class Shape {
        protected Point from;
        protected Point to;
        protected Pen pen = new Pen(Color.Black);
        private bool isEditing = false;

        public void setPoints(Point from, Point to) {
            this.from = from;
            this.to = to;
        }

        protected Point getLeftUpPoint() {
            int left = Math.Min(from.X, to.X);
            int up = Math.Min(from.Y, to.Y);
            return new Point(left, up);
        }

        protected Point getRightBottomPoint() {
            int right = Math.Max(from.X, to.X);
            int bottom = Math.Max(from.Y, to.Y);
            return new Point(right, bottom);
        }

        protected int getWidth() {
            return Math.Abs(from.X - to.X);
        }

        protected int getHeight() {
            return Math.Abs(from.Y - to.Y);
        }

        public void Select() {
            isEditing = true;
        }

        public void Deselect() {
            isEditing = false;
        }

        public void Move(int horizontal, int vertical) {
            from.X += horizontal;
            to.X += horizontal;
            from.Y += vertical;
            to.Y += vertical;
        }

        public bool Intersect(Point point) {
            Point leftUp = getLeftUpPoint();
            Point rightBottom = getRightBottomPoint();

            bool inRangeX = leftUp.X <= point.X && point.X <= rightBottom.X;
            bool inRangeY = leftUp.Y <= point.Y && point.Y <= rightBottom.Y;
            return inRangeX && inRangeY;
        }

        public void Draw(Graphics graphics) {
            if (isEditing) {
                DrawEditBox(graphics);
            }
            DrawInternal(graphics);
        }

        private void DrawEditBox(Graphics graphics) {
            Point point = getLeftUpPoint();
            graphics.DrawRectangle(new Pen(Color.Blue), point.X - 5, point.Y - 5, getWidth() + 10, getHeight() + 10);
        }

        protected abstract void DrawInternal(Graphics graphics);
    }
}
