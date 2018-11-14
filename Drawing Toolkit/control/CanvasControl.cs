using System.Drawing;
using System.Windows.Forms;
using Drawing_Toolkit.model.canvas;
using Drawing_Toolkit.model.canvas.state;
using Timer = System.Timers.Timer;

namespace Drawing_Toolkit.control {
    internal class CanvasControl : Control {
        private readonly Canvas canvas = new Canvas();

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
            // reduce flickering
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
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
            Paint += (s, e) => canvas.Render(e.Graphics, e.ClipRectangle);
            InitPeriodicRender();
        }

        private void InitPeriodicRender() {
            var timer = new Timer(1000 / 70); // FPS
            timer.Elapsed += (s, e) => Invalidate();
            timer.Start();
        }
    }
}