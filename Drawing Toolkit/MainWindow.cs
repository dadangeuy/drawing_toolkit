using System.Windows.Forms;
using Drawing_Toolkit.control;
using Drawing_Toolkit.model.canvas.state;
using Drawing_Toolkit.model.canvas.state.create;

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
