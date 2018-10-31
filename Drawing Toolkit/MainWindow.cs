using Drawing_Toolkit.Controller;
using Drawing_Toolkit.Model.Canvas.State;
using Drawing_Toolkit.Model.Tool.Impl;
using System.Windows.Forms;

namespace Drawing_Toolkit {
    public partial class MainWindow : Form {
        private CanvasControl canvasControl = new CanvasControl();
        private ToolsControl toolsControl = new ToolsControl();

        public MainWindow() {
            InitializeComponent();
            InjectControlEvent();
            InjectControl();
        }

        private void InjectControl() {
            toolStripContainer1.ContentPanel.Controls.Add(canvasControl);
            toolStripContainer1.TopToolStripPanel.Controls.Add(toolsControl);
        }

        private void InjectControlEvent() {
            toolsControl.ToolSelectedEventHandler += (tool) => {
                if (tool is SelectionTool) canvasControl.SetCanvasState(SelectionState.INSTANCE);
                else if (tool is EllipseTool) canvasControl.SetCanvasState(CreateEllipseState.INSTANCE);
                else if (tool is RectangleTool) canvasControl.SetCanvasState(CreateRectangleState.INSTANCE);
            };
        }
    }
}
