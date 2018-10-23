using Drawing_Toolkit.Controller;
using System;
using System.Windows.Forms;

namespace Drawing_Toolkit {
    public partial class MainWindow : Form {

        public MainWindow() {
            InitializeComponent();
            InitializeController();
        }

        private void InitializeController() {
            new CanvasController(CanvasPanel);
            new ToolsController(Tools);
        }
    }
}
