using Drawing_Toolkit.Model.Canvas.State;
using Drawing_Toolkit.Model.Event;
using System.Drawing;
using System.Windows.Forms;

namespace Drawing_Toolkit.Controller {
    class ToolsControl : ToolStrip {
        public event SetCanvasStateEventHandler SetCanvasStateEvent;
        private readonly ToolStripItem selectionTool = new ToolStripButton(Image.FromFile("Asset/arrow.png"));
        private readonly ToolStripItem lineTool = new ToolStripButton(Image.FromFile("Asset/line.png"));
        private readonly ToolStripItem rectangleTool = new ToolStripButton(Image.FromFile("Asset/square.png"));
        private readonly ToolStripItem ellipseTool = new ToolStripButton(Image.FromFile("Asset/circle.png"));

        public ToolsControl() {
            InitUI();
            InitCallback();
        }

        private void InitUI() {
            Items.Add(selectionTool);
            Items.Add(lineTool);
            Items.Add(rectangleTool);
            Items.Add(ellipseTool);
        }

        private void InitCallback() {
            selectionTool.Click += (s, e) => SetCanvasStateEvent.Invoke(SelectState.INSTANCE);
            lineTool.Click += (s, e) => SetCanvasStateEvent.Invoke(CreateLineState.INSTANCE);
            rectangleTool.Click += (s, e) => SetCanvasStateEvent.Invoke(CreateRectangleState.INSTANCE);
            ellipseTool.Click += (s, e) => SetCanvasStateEvent.Invoke(CreateEllipseState.INSTANCE);
        }
    }
}
