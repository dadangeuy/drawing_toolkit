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
            canvas.State = state;
        }

        private void InitUI() {
            Dock = DockStyle.Fill;
            BackColor = Color.White;
            DoubleBuffered = true;  // improve rendering performance
        }

        private void InitCallback() {
            InitMouseEvent();
            InitRenderEvent();
        }

        private void InitMouseEvent() {
            MouseDown += (s, args) => canvas.MouseDown(args);
            MouseMove += (s, args) => canvas.MouseMove(args);
            MouseUp += (s, args) => canvas.MouseUp(args);
            KeyDown += (s, args) => canvas.KeyDown(args);
            KeyUp += (s, args) => canvas.KeyUp(args);
        }

        private void InitRenderEvent() {
            Paint += (s, e) => canvas.Render(e.Graphics);
            InitRenderFpsLimit();
        }

        private void InitRenderFpsLimit() {
            var timer = new System.Timers.Timer(1000.0f / 60.0f);
            timer.Elapsed += (s, e) => Invalidate();
            timer.Start();
        }
    }
}
