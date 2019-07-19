using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor.Contracts
{
    public interface IGraphicEditor
    {
        void DrawShape(IShape shape);
    }
}
