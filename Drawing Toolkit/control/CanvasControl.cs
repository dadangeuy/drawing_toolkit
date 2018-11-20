using System.Drawing;
using System.Windows.Forms;
using Drawing_Toolkit.model.canvas;
using Drawing_Toolkit.model.canvas.state;
using Timer = System.Timers.Timer;

namespace Drawing_Toolkit.control {
    internal class CanvasControl : Control {
        private readonly Canvas Canvas = new Canvas();

        public CanvasControl() {
            InitUi();
            InitCallback();
        }

        public void SetCanvasState(CanvasState state) {
            Canvas.State = state;
        }

        private void InitUi() {
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
            MouseDown += (s, args) => Canvas.MouseDown(args);
            MouseMove += (s, args) => Canvas.MouseMove(args);
            MouseUp += (s, args) => Canvas.MouseUp(args);
            KeyDown += (s, args) => Canvas.KeyDown(args);
            KeyUp += (s, args) => Canvas.KeyUp(args);
        }

        private void InitRenderEvent() {
            Paint += (s, e) => Canvas.Render(e.Graphics, e.ClipRectangle);
            InitPeriodicRender();
        }

        private void InitPeriodicRender() {
            var timer = new Timer(1000 / 70); // FPS
            timer.Elapsed += (s, e) => Invalidate();
            timer.Start();
        }
    }
}