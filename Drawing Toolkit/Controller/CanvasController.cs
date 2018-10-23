using Drawing_Toolkit.Model;
using Drawing_Toolkit.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Drawing_Toolkit.Controller {
    class CanvasController {
        private Graphics graphics;
        private Point mDownLocation = new Point();
        private Point mUpLocation = new Point();
        private LinkedList<Shape> shapes = new LinkedList<Shape>();
        private Shape activeShape;

        public CanvasController(Panel canvasPanel) {
            graphics = canvasPanel.CreateGraphics();

            // setter callback
            canvasPanel.MouseDown += (s, e) => mDownLocation = new Point(e.X, e.Y);
            canvasPanel.MouseUp += (s, e) => mUpLocation = new Point(e.X, e.Y);

            // mDownCallback
            canvasPanel.MouseDown += (s, e) => DeselectAllShape();
            canvasPanel.MouseDown += (s, e) => SelectShape();

            // mUp Callback
            canvasPanel.MouseUp += (s, e) => DrawNewShape();
            canvasPanel.MouseUp += (s, e) => MoveSelectedShape();
            canvasPanel.MouseUp += (s, e) => Render();
        }

        private void DrawNewShape() {
            Tool activeTool = ToolsController.activeTool;
            if (ToolUtil.IsShapeTool(activeTool)) {
                Shape shape = ToolUtil.GetShape(activeTool);
                shape.setPoints(mDownLocation, mUpLocation);
                shapes.AddFirst(shape);
            }
        }

        private void SelectShape() {
            if (ToolsController.activeTool == Tool.SELECTOR) {
                foreach (var shape in shapes) {
                    if (shape.Intersect(mDownLocation)) {
                        shape.Select();
                        activeShape = shape;
                        break;
                    }
                }
            }
        }

        private void DeselectAllShape() {
            foreach (var shape in shapes)
                shape.Deselect();
        }

        private void MoveSelectedShape() {
            if (ToolsController.activeTool == Tool.SELECTOR) {
                bool isMoving = activeShape != null && activeShape.Intersect(mDownLocation);
                if (isMoving) {
                    int horizontal = mUpLocation.X - mDownLocation.X;
                    int vertical = mUpLocation.Y - mDownLocation.Y;
                    activeShape.Move(horizontal, vertical);
                }
            }
        }

        private void Render() {
            graphics.Clear(Color.White);
            foreach (var shape in shapes)
                shape.Draw(graphics);
        }
    }
}
