using Drawing_Toolkit.Model.Canvas;
using Drawing_Toolkit.Model.Canvas.State;
using System.Drawing;
using System.Windows.Forms;

namespace Drawing_Toolkit.Controller {
    class CanvasControl : Control {
        private CanvasContext canvas = new CanvasContext();

        public CanvasControl() {
            InitUI();
            InitCallback();
        }

        public void SetCanvasState(CanvasState state) {
            canvas.SetState(state);
        }

        private void InitUI() {
            Dock = DockStyle.Fill;
            BackColor = Color.White;
        }

        private void InitCallback() {
            InitMouseDragEvent();
            InitRenderingEvent();
            InitLazyRenderingUpdate();
        }

        private void InitMouseDragEvent() {
            MouseDown += (s, e) => canvas.MouseDown(e.Location);
            MouseMove += (s, e) => canvas.MouseMove(e.Location);
            MouseUp += (s, e) => canvas.MouseUp(e.Location);
        }

        private void InitRenderingEvent() {
            Paint += (s, e) => canvas.Render(e.Graphics);
        }

        private void InitLazyRenderingUpdate() {
            MouseDown += (s, e) => TriggerRendering();
            MouseMove += (s, e) => {
                bool holdMouse = e.Button.HasFlag(MouseButtons.Left);
                if (holdMouse) TriggerRendering();
            };
            MouseUp += (s, e) => TriggerRendering();
        }

        public void TriggerRendering() {
            Invalidate();
            Update();
        }
    }
}
