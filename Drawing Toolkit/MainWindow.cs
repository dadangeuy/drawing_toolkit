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
            toolsControl.SetCanvasStateEvent += (state) => canvasControl.SetCanvasState(state);
        }
    }
}
