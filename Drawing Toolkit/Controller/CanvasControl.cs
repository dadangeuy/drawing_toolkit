using Drawing_Toolkit.Model.Shape.Api;
using Drawing_Toolkit.Model.Tool.Api;
using Drawing_Toolkit.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Drawing_Toolkit.Controller {
    class CanvasControl : Control {
        public ITool Tool;
        private Point mDownPoint;
        private Point mUpPoint;
        private List<IShape> shapes = new List<IShape>(100);

        public CanvasControl() {
            InitUI();
            InitCallback();
        }

        private void InitUI() {
            Dock = DockStyle.Fill;
            BackColor = Color.White;
        }

        private void InitCallback() {
            Paint += (s, e) => DrawShapes();
            MouseDown += (s, e) => mDownPoint = new Point(e.X, e.Y);
            MouseUp += (s, e) => mUpPoint = new Point(e.X, e.Y);
            MouseUp += (s, e) => ExecuteTool();
            MouseUp += (s, e) => Repaint();
        }

        private void DrawShapes() {
            Graphics g = CreateGraphics();
            foreach (IShape shape in shapes)
                shape.Draw(g);
        }

        private void Repaint() {
            Invalidate();
            Update();
        }

        private void ExecuteTool() {
            if (Tool is IShapeTool) {
                IShapeTool shapeTool = (IShapeTool)Tool;
                IShape shape = shapeTool.CreateShape(mDownPoint, mUpPoint);
                shapes.Add(shape);
            } else if (Tool is IPointerTool) {
                IPointerTool pointerTool = (IPointerTool)Tool;
                pointerTool.Drag(mDownPoint, mUpPoint, shapes);
            }
        }
    }
}
