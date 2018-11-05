using Drawing_Toolkit.Controller;
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
            toolsControl.SetCanvasStateEvent += (state) => canvasControl.SetCanvasState(state);
        }
    }
}
