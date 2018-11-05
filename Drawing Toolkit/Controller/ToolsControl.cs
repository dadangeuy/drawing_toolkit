using Drawing_Toolkit.Model.Canvas.State;
using Drawing_Toolkit.Model.Event;
using System.Drawing;
using System.Windows.Forms;

namespace Drawing_Toolkit.Controller {
    class ToolsControl : ToolStrip {
        public event SetCanvasStateEventHandler SetCanvasStateEvent;
        private readonly ToolStripItem selectionTool = new ToolStripButton(Image.FromFile("Asset/arrow.png")) {
            CheckOnClick = true,
            Checked = true
        };
        private readonly ToolStripItem lineTool = new ToolStripButton(Image.FromFile("Asset/line.png")) {
            CheckOnClick = true
        };
        private readonly ToolStripItem rectangleTool = new ToolStripButton(Image.FromFile("Asset/square.png")) {
            CheckOnClick = true
        };
        private readonly ToolStripItem ellipseTool = new ToolStripButton(Image.FromFile("Asset/circle.png")) {
            CheckOnClick = true
        };

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
            // Uncheck Callback
            selectionTool.MouseDown += (s, e) => UncheckButtons();
            lineTool.MouseDown += (s, e) => UncheckButtons();
            rectangleTool.MouseDown += (s, e) => UncheckButtons();
            ellipseTool.MouseDown += (s, e) => UncheckButtons();

            // Set Canvas Callback
            selectionTool.Click += (s, e) => SetCanvasStateEvent.Invoke(SelectState.INSTANCE);
            lineTool.Click += (s, e) => SetCanvasStateEvent.Invoke(CreateLineState.INSTANCE);
            rectangleTool.Click += (s, e) => SetCanvasStateEvent.Invoke(CreateRectangleState.INSTANCE);
            ellipseTool.Click += (s, e) => SetCanvasStateEvent.Invoke(CreateEllipseState.INSTANCE);
        }

        private void UncheckButtons() {
            foreach (var menuItem in Items) {
                ((ToolStripButton)menuItem).Checked = false;
            }
        }
    }
}
