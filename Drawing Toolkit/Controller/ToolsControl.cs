using Drawing_Toolkit.Model.Canvas.State;
using Drawing_Toolkit.Model.Event;
using System.Windows.Forms;

namespace Drawing_Toolkit.Controller {
    class ToolsControl : ToolStrip {
        public event SetCanvasStateEventHandler SetCanvasStateEvent;
        private readonly ToolStripItem selectionTool = new ToolStripButton("Selection");
        private readonly ToolStripItem lineTool = new ToolStripButton("Line");
        private readonly ToolStripItem rectangleTool = new ToolStripButton("Rectangle");
        private readonly ToolStripItem ellipseTool = new ToolStripButton("Ellipse");

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
