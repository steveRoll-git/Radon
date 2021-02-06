using SFML.Graphics;
using SFML.Window;
using System;

namespace RadonTest
{
    class Program
    {
        static void Main(string[] args)
        {
            RenderWindow window = new RenderWindow(new VideoMode(800, 600), "Radon Test");

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

            while (window.IsOpen)
            {
                window.DispatchEvents();

                window.Clear();
                window.Display();
            }
        }
    }
}
