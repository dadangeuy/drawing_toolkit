using Drawing_Toolkit.Model.Shape.Api;
using Drawing_Toolkit.Model.Tool.Api;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Drawing_Toolkit.Controller {
    class CanvasControl : Control {
        public ITool Tool;
        private Point mDownPoint;
        private Point mUpPoint;
        private LinkedList<IShape> shapes = new LinkedList<IShape>();

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
            MouseUp += (s, e) => ExecuteShapeTool();
            MouseUp += (s, e) => ExecuteSelectionTool();
        }

        private void DrawShapes() {
            Graphics g = CreateGraphics();
            foreach (IShape shape in shapes)
                shape.Draw(g);
        }

        private void ExecuteShapeTool() {
            if (Tool is IShapeTool shapeTool) {
                IShape shape = shapeTool.CreateShape(mDownPoint, mUpPoint);
                shapes.AddFirst(shape);
                Repaint();
            }
        }

        private void ExecuteSelectionTool() {
            if (Tool is IPointerTool pointerTool) {
                pointerTool.Drag(mDownPoint, mUpPoint, shapes);
                Repaint();
            }
        }

        private void Repaint() {
            Invalidate();
            Update();
        }
    }
}
