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
            DoubleBuffered = true;  // improve rendering performance
        }

        public void SetCanvasState(CanvasState state) {
            canvas.State = state;
        }

        private void InitUI() {
            Dock = DockStyle.Fill;
            BackColor = Color.White;
        }

        private void InitCallback() {
            InitMouseEvent();
            InitRenderEvent();
        }

        private void InitMouseEvent() {
            MouseDown += (s, e) => canvas.MouseDown(e.Location);
            MouseMove += (s, e) => canvas.MouseMove(e.Location);
            MouseUp += (s, e) => canvas.MouseUp(e.Location);
            MouseDown += (s, e) => {
                bool holdShift = ModifierKeys == Keys.Shift;
                if (holdShift) {
                    System.Console.WriteLine("mencet shift");
                }
            };
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
