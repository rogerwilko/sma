using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;

namespace SMA.src.View
{
    class ViewSFML : IView
    {
        private Window _app;


        // Initialisation de la vue
        public void InitView()
        {

            // Create the main window
            _app = new Window(new VideoMode(640, 480, 32), "SFML.Net Window");

            // Setup event handlers
            _app.Closed += new EventHandler(OnClosed);
            _app.KeyPressed += new EventHandler<KeyEventArgs>(OnKeyPressed);
            _app.Resized += new EventHandler<SizeEventArgs>(OnResized);


            //float Time = 0.0F;

            // Start the game loop

        }


        // Mise à jour de la vue
        public void UpdateView()
        {
            // Process events
            _app.DispatchEvents();

            // Set the active window before using OpenGL commands
            // It's useless here because the active window is always the same,
            // but don't forget it if you use multiple windows
            _app.SetActive();



            // Finally, display the rendered frame on screen
            _app.Display();
        }


        // Retourne True si la fenêtre est ouverte
        public bool IsRunning()
        {
            return _app.IsOpened();
        }



        /// <summary>
        /// Function called when the window is closed
        /// </summary>
        static void OnClosed(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Close();
        }

        /// <summary>
        /// Function called when a key is pressed
        /// </summary>
        static void OnKeyPressed(object sender, KeyEventArgs e)
        {
            Window window = (Window)sender;

            if (e.Code == KeyCode.Escape)
                window.Close();
        }

        /// <summary>
        /// Function called when the window is resized
        /// </summary>
        static void OnResized(object sender, SizeEventArgs e)
        {
        }
    }
}
