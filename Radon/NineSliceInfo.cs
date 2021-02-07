using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Radon
{
    /// <summary>
    /// Information about how a 9-slice sprite is located within a texture.
    /// </summary>
    public struct NineSliceInfo
    {
        public Texture texture;

        public int x0;
        public int x1;
        public int x2;
        public int x3;

        public int y0;
        public int y1;
        public int y2;
        public int y3;

        public int Width0 => x1 - x0;
        public int Width1 => x2 - x1;
        public int Width2 => x3 - x2;

        public int Height0 => y1 - y0;
        public int Height1 => y2 - y1;
        public int Height2 => y3 - y2;
    }
}
