using System;
using System.Collections.Generic;
using System.Text;
using P02.Graphic_Editor.Contracts;

namespace P02.Graphic_Editor
{
    public class CircleGraphicManager : GraphicEditor
    {
        protected override void DrawFigure(IShape shape)
        {
            Console.WriteLine("I'm Circle");
        }

    }
}
