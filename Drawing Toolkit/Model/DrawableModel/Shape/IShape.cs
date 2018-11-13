﻿using System.Drawing;

namespace Drawing_Toolkit.Model.DrawableModel.Shape {
    interface IShape {
        void SetGraphics(Graphics graphics);
        void SetShape(Point from, Point to);
        void Move(Point offset);
        bool Intersect(Point location);
        bool Intersect(Rectangle area);
        void RenderShape();
        void RenderShapeContainer();
    }
}