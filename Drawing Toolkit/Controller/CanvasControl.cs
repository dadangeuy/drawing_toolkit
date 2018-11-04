using Drawing_Toolkit.Model.Canvas;
using Drawing_Toolkit.Model.Canvas.State;
using Drawing_Toolkit.Model.Event;
using System.Drawing;
using System.Windows.Forms;

namespace Drawing_Toolkit.Controller {
    class CanvasControl : Control {
        private CanvasContext canvas = new CanvasContext();
        private event MouseDragEventHandler MouseDrag;
        private MouseEventArgs mDownEvent;
        private bool mHold = false;

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
            InitUpdateContextEvent();
            InitRenderingEvent();
        }

        private void InitMouseDragEvent() {
            MouseDown += (s, e) => {
                mDownEvent = e;
                mHold = true;
            };
            MouseUp += (s, e) => {
                if (mHold) {
                    MouseDrag.Invoke(mDownEvent, e);
                }
                mHold = false;
            };
        }

        private void InitUpdateContextEvent() {
            MouseDrag += (e, e2) => canvas.Drag(new Point(e.X, e.Y), new Point(e2.X, e2.Y));
            MouseDown += (s, e) => canvas.Click(new Point(e.X, e.Y));
        }

        private void InitRenderingEvent() {
            Paint += (s, e) => canvas.Render(e.Graphics);
            MouseUp += (s, e) => Invalidate();
        }
    }
}
