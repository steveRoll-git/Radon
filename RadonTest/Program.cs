using SFML.Graphics;
using SFML.Window;
using Radon;
using System;

namespace RadonTest
{
    class Program
    {
        static void Main(string[] args)
        {
            RenderWindow window = new RenderWindow(new VideoMode(800, 600), "Radon Test");
            window.SetVerticalSyncEnabled(true);

            NineSliceInfo btnSliceInfo = new NineSliceInfo
            {
                texture = new Texture("images/skin.png"),

                x0 = 0,
                x1 = 3,
                x2 = 21,
                x3 = 24,

                y0 = 0,
                y1 = 3,
                y2 = 21,
                y3 = 24,
            };

            NineSliceSprite btn = new NineSliceSprite(btnSliceInfo)
            {
                position = new SFML.System.Vector2f(100, 200),
                Width = 300,
                Height = 100
            };

            window.Closed += delegate
            {
                window.Close();
            };

            window.Resized += (object obj, SizeEventArgs args) =>
            {
                View currentView = window.GetView();
                currentView.Reset(new FloatRect(0, 0, args.Width, args.Height));
                window.SetView(currentView);
            };

            window.MouseMoved += (object obj, MouseMoveEventArgs args) =>
            {
                btn.Width = args.X - btn.position.X;
                btn.Height = args.Y - btn.position.Y;
            };

            while (window.IsOpen)
            {
                window.DispatchEvents();

                window.Clear(new Color(236, 233, 216));
                window.Draw(btn);
                window.Display();
            }
        }
    }
}
