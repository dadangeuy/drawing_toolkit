﻿using System.Windows.Forms;
using Drawing_Toolkit.Model.DrawableModel;
using Drawing_Toolkit.Model.DrawableModel.State;

namespace Drawing_Toolkit.Model.CanvasModel.State.Create {
    abstract class CreateShapeState : CanvasState {
        public override void MouseDown(Canvas context, MouseEventArgs args) {
            var drawable = CreateNewDrawable();
            context.NewDrawable = drawable;
            context.Drawables.AddFirst(drawable);
            context.InitialLocation = args.Location;
        }

        public override void MouseMove(Canvas context, MouseEventArgs args) {
            var drawable = context.NewDrawable;
            var initialLocation = context.InitialLocation;
            drawable.Resize(initialLocation, args.Location);
        }

        public override void MouseUp(Canvas context, MouseEventArgs args) {
            var drawable = context.NewDrawable;
            drawable.State = LockState.INSTANCE;
        }

        protected abstract Drawable CreateNewDrawable();
    }
}
