using System.Windows.Forms;
using Drawing_Toolkit.control;
using Drawing_Toolkit.model.canvas.state;
using Drawing_Toolkit.model.canvas.state.create;

namespace Drawing_Toolkit {
    public partial class MainWindow : Form {
        private CanvasControl CanvasControl = new CanvasControl();
        private ToolsControl ToolsControl = new ToolsControl();

        public MainWindow() {
            InitializeComponent();
            InitUi();
            InjectControlEvent();
            InjectControl();
        }

        private void InitUi() {
            WindowState = FormWindowState.Maximized;
        }

        private void InjectControl() {
            toolStripContainer.ContentPanel.Controls.Add(CanvasControl);
            toolStripContainer.LeftToolStripPanel.Controls.Add(ToolsControl);
        }

        private void InjectControlEvent() {
            ToolsControl.OnSelectSelectionTool += (s, args) => CanvasControl.SetCanvasState(SelectState.Instance);
            ToolsControl.OnSelectLineTool += (s, args) => CanvasControl.SetCanvasState(CreateLineState.Instance);
            ToolsControl.OnSelectRectangleTool += (s, args) => CanvasControl.SetCanvasState(CreateRectangleState.Instance);
            ToolsControl.OnSelectEllipseTool += (s, args) => CanvasControl.SetCanvasState(CreateEllipseState.Instance);
        }
    }
}
