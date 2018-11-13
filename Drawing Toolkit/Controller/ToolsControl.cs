using System;
using System.Drawing;
using System.Windows.Forms;

namespace Drawing_Toolkit.Controller {
    class ToolsControl : ToolStrip {
        public event EventHandler OnSelectSelectionTool;
        public event EventHandler OnSelectLineTool;
        public event EventHandler OnSelectRectangleTool;
        public event EventHandler OnSelectEllipseTool;
        private readonly ToolStripItem selectionTool = new ToolStripButton("Selection") {
            CheckOnClick = true,
            Checked = true
        };
        private readonly ToolStripItem lineTool = new ToolStripButton("Line") {
            CheckOnClick = true
        };
        private readonly ToolStripItem rectangleTool = new ToolStripButton("Rectangle") {
            CheckOnClick = true
        };
        private readonly ToolStripItem ellipseTool = new ToolStripButton("Ellipse") {
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
            selectionTool.MouseDown += (s, args) => UncheckButtons();
            lineTool.MouseDown += (s, args) => UncheckButtons();
            rectangleTool.MouseDown += (s, args) => UncheckButtons();
            ellipseTool.MouseDown += (s, args) => UncheckButtons();

            selectionTool.Click += (s, args) => OnSelectSelectionTool.Invoke(s, args);
            lineTool.Click += (s, args) => OnSelectLineTool.Invoke(s, args);
            rectangleTool.Click += (s, args) => OnSelectRectangleTool.Invoke(s, args);
            ellipseTool.Click += (s, args) => OnSelectEllipseTool.Invoke(s, args);
        }

        private void UncheckButtons() {
            foreach (var menuItem in Items) {
                ((ToolStripButton)menuItem).Checked = false;
            }
        }
    }
}
