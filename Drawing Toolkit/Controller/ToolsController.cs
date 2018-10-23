using Drawing_Toolkit.Model;
using System.Windows.Forms;

namespace Drawing_Toolkit.Controller {
    class ToolsController {
        public static Tool activeTool = Tool.SELECTOR;

        public ToolsController(ToolStrip tools) {
            var items = tools.Items;

            // setter callback
            items[0].Click += (s, e) => activeTool = Tool.SELECTOR;
            items[1].Click += (s, e) => activeTool = Tool.LINE;
            items[2].Click += (s, e) => activeTool = Tool.ELLIPSE;
        }
    }
}
