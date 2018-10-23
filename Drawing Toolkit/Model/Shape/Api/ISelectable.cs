using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing_Toolkit.Model.Shape.Api {
    interface ISelectable {
        void Select();
        void Deselect();
    }
}
