using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Radon
{
    /// <summary>
    /// A 9-slice sprite used for drawing widget graphics with corners and edges that stay the same size when the widget is resized.
    /// </summary>
    public class NineSliceSprite : Drawable
    {
        public Texture texture;

        private Sprite topLeft = new Sprite();
        private Sprite topCenter = new Sprite();
        private Sprite topRight = new Sprite();
        private Sprite middleLeft = new Sprite();
        private Sprite middleCenter = new Sprite();
        private Sprite middleRight = new Sprite();
        private Sprite bottomLeft = new Sprite();
        private Sprite bottomCenter = new Sprite();
        private Sprite bottomRight = new Sprite();

        private NineSliceInfo sliceInfo;
        public NineSliceInfo SliceInfo
        {
            get => sliceInfo;
            set {
                sliceInfo = value;

                topLeft.Texture = sliceInfo.texture;
                topCenter.Texture = sliceInfo.texture;
                topCenter.Position = new Vector2f(sliceInfo.x1, 0);
                topRight.Texture = sliceInfo.texture;
                middleLeft.Texture = sliceInfo.texture;
                middleLeft.Position = new Vector2f(0, sliceInfo.y1);
                middleCenter.Texture = sliceInfo.texture;
                middleCenter.Position = new Vector2f(sliceInfo.x1, sliceInfo.y1);
                middleRight.Texture = sliceInfo.texture;
                bottomLeft.Texture = sliceInfo.texture;
                bottomCenter.Texture = sliceInfo.texture;
                bottomRight.Texture = sliceInfo.texture;

                topLeft.TextureRect = new IntRect(sliceInfo.x0, sliceInfo.y0, sliceInfo.Width0, sliceInfo.Height0);
                topCenter.TextureRect = new IntRect(sliceInfo.x1, sliceInfo.y0, sliceInfo.Width1, sliceInfo.Height0);
                topRight.TextureRect = new IntRect(sliceInfo.x2, sliceInfo.y0, sliceInfo.Width2, sliceInfo.Height0);

                middleLeft.TextureRect = new IntRect(sliceInfo.x0, sliceInfo.y1, sliceInfo.Width0, sliceInfo.Height1);
                middleCenter.TextureRect = new IntRect(sliceInfo.x1, sliceInfo.y1, sliceInfo.Width1, sliceInfo.Height1);
                middleRight.TextureRect = new IntRect(sliceInfo.x2, sliceInfo.y1, sliceInfo.Width2, sliceInfo.Height1);

                bottomLeft.TextureRect = new IntRect(sliceInfo.x0, sliceInfo.y2, sliceInfo.Width0, sliceInfo.Height2);
                bottomCenter.TextureRect = new IntRect(sliceInfo.x1, sliceInfo.y2, sliceInfo.Width1, sliceInfo.Height2);
                bottomRight.TextureRect = new IntRect(sliceInfo.x2, sliceInfo.y2, sliceInfo.Width2, sliceInfo.Height2);

                Width = width;
                Height = height;
            }
        }

        private float width;
        public float Width
        {
            get => width;
            set
            {
                width = value;

                float centerWidth = width - sliceInfo.Width0 - sliceInfo.Width2;
                topCenter.Scale = new Vector2f(centerWidth / sliceInfo.Width1, topCenter.Scale.Y);
                middleCenter.Scale = new Vector2f(centerWidth / sliceInfo.Width1, middleCenter.Scale.Y);
                bottomCenter.Scale = new Vector2f(centerWidth / sliceInfo.Width1, bottomCenter.Scale.Y);

                topRight.Position = new Vector2f(width - sliceInfo.Width2, 0);
                middleRight.Position = new Vector2f(width - sliceInfo.Width2, sliceInfo.Height0);
                bottomRight.Position = new Vector2f(width - sliceInfo.Width2, height - sliceInfo.Height2);
            }
        }

        private float height;
        public float Height
        {
            get => height;
            set
            {
                height = value;

                float centerHeight = height - sliceInfo.Height0 - sliceInfo.Height2;
                middleLeft.Scale = new Vector2f(middleLeft.Scale.X, centerHeight / sliceInfo.Height1);
                middleCenter.Scale = new Vector2f(middleCenter.Scale.X, centerHeight / sliceInfo.Height1);
                middleRight.Scale = new Vector2f(middleRight.Scale.X, centerHeight / sliceInfo.Height1);

                bottomLeft.Position = new Vector2f(0, height - sliceInfo.Height2);
                bottomCenter.Position = new Vector2f(sliceInfo.Width0, height - sliceInfo.Height2);
                bottomRight.Position = new Vector2f(width - sliceInfo.Width2, height - sliceInfo.Height2);
            }
        }

        public Vector2f position;

        public NineSliceSprite(NineSliceInfo sliceInfo)
        {
            SliceInfo = sliceInfo;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform.Translate(position);

            target.Draw(topLeft, states);
            target.Draw(topCenter, states);
            target.Draw(topRight, states);
            target.Draw(middleLeft, states);
            target.Draw(middleCenter, states);
            target.Draw(middleRight, states);
            target.Draw(bottomLeft, states);
            target.Draw(bottomCenter, states);
            target.Draw(bottomRight, states);
        }
    }
}
