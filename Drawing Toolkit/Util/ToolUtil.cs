using Drawing_Toolkit.Model;

namespace Drawing_Toolkit.Util {
    class ToolUtil {
        public static bool IsPointerTool(Tool tool) {
            return tool == Tool.SELECTOR;
        }

        public static bool IsShapeTool(Tool tool) {
            return tool == Tool.LINE || tool == Tool.ELLIPSE;
        }

        public static Shape GetShape(Tool tool) {
            switch(tool) {
                case (Tool.LINE):
                    return new Line();
                case (Tool.ELLIPSE):
                    return new Ellipse();
                default:
                    return null;
            }
        }
    }
}
