using Drawing_Toolkit.Controller;
using Drawing_Toolkit.Model.Canvas.State;
using System.Windows.Forms;

namespace Drawing_Toolkit {
    public partial class MainWindow : Form {
        private CanvasControl canvasControl = new CanvasControl();
        private ToolsControl toolsControl = new ToolsControl();

        public MainWindow() {
            InitializeComponent();
            InitUI();
            InjectControlEvent();
            InjectControl();
        }

        private void InitUI() {
            WindowState = FormWindowState.Maximized;
        }

        private void InjectControl() {
            toolStripContainer.ContentPanel.Controls.Add(canvasControl);
            toolStripContainer.LeftToolStripPanel.Controls.Add(toolsControl);
        }

        private void InjectControlEvent() {
            toolsControl.OnSelectSelectionTool += (s, args) => canvasControl.SetCanvasState(SelectState.INSTANCE);
            toolsControl.OnSelectLineTool += (s, args) => canvasControl.SetCanvasState(CreateLineState.INSTANCE);
            toolsControl.OnSelectRectangleTool += (s, args) => canvasControl.SetCanvasState(CreateRectangleState.INSTANCE);
            toolsControl.OnSelectEllipseTool += (s, args) => canvasControl.SetCanvasState(CreateEllipseState.INSTANCE);
        }
    }
}
