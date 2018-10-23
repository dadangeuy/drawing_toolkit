using Drawing_Toolkit.Model.Event;
using Drawing_Toolkit.Model.Tool.Impl;
using System.Windows.Forms;

namespace Drawing_Toolkit.Controller {
    class ToolsControl : ToolStrip {
        public event ToolSelectedEventHandler ToolSelectedEventHandler;

        private readonly ToolStripItem selectionTool = new ToolStripButton("Selection");
        private readonly ToolStripItem rectangleTool = new ToolStripButton("Rectangle");
        private readonly ToolStripItem ellipseTool = new ToolStripButton("Ellipse");

        public ToolsControl() {
            InitUI();
            InitCallback();
        }

        private void InitUI() {
            Items.Add(selectionTool);
            Items.Add(new ToolStripSeparator());
            Items.Add(rectangleTool);
            Items.Add(new ToolStripSeparator());
            Items.Add(ellipseTool);
        }

        private void InitCallback() {
            selectionTool.Click += (s, e) => ToolSelectedEventHandler.Invoke(new SelectionTool());
            rectangleTool.Click += (s, e) => ToolSelectedEventHandler.Invoke(new RectangleTool());
            ellipseTool.Click += (s, e) => ToolSelectedEventHandler.Invoke(new EllipseTool());
        }
    }
}
