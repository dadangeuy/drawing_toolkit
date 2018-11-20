using System;
using System.Windows.Forms;

namespace Drawing_Toolkit.control {
    internal class ToolsControl : ToolStrip {
        private readonly ToolStripItem EllipseTool = new ToolStripButton("Ellipse") {
            CheckOnClick = true
        };
        private readonly ToolStripItem LineTool = new ToolStripButton("Line") {
            CheckOnClick = true
        };
        private readonly ToolStripItem RectangleTool = new ToolStripButton("Rectangle") {
            CheckOnClick = true
        };
        private readonly ToolStripItem SelectionTool = new ToolStripButton("Selection") {
            CheckOnClick = true,
            Checked = true
        };
        public event EventHandler OnSelectSelectionTool;
        public event EventHandler OnSelectLineTool;
        public event EventHandler OnSelectRectangleTool;
        public event EventHandler OnSelectEllipseTool;

        public ToolsControl() {
            InitUi();
            InitCallback();
        }

        private void InitUi() {
            Items.Add(SelectionTool);
            Items.Add(LineTool);
            Items.Add(RectangleTool);
            Items.Add(EllipseTool);
        }

        private void InitCallback() {
            SelectionTool.MouseDown += (s, args) => UncheckButtons();
            LineTool.MouseDown += (s, args) => UncheckButtons();
            RectangleTool.MouseDown += (s, args) => UncheckButtons();
            EllipseTool.MouseDown += (s, args) => UncheckButtons();

            SelectionTool.Click += (s, args) => OnSelectSelectionTool?.Invoke(s, args);
            LineTool.Click += (s, args) => OnSelectLineTool?.Invoke(s, args);
            RectangleTool.Click += (s, args) => OnSelectRectangleTool?.Invoke(s, args);
            EllipseTool.Click += (s, args) => OnSelectEllipseTool?.Invoke(s, args);
        }

        private void UncheckButtons() {
            foreach (var menuItem in Items) ((ToolStripButton) menuItem).Checked = false;
        }
    }
}