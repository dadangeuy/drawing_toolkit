﻿using System.Drawing;

namespace Drawing_Toolkit.model.shape {
    internal interface IShape {
        void SetGraphics(Graphics graphics);
        void SetShape(Point from, Point to);
        void Move(Point offset);
        void MoveFrom(Point offset);
        void MoveTo(Point offset);
        bool Intersect(Point location);
        bool Intersect(Rectangle area);
        void RenderShape();
        void RenderShapeContainer();
    }
}