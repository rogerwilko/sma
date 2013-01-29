using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SMA.src.Model;
using SMA.Model;
using SFML.Graphics;
using SMA.src.Controller;

namespace SMA.src.View
{
    class ViewSFML : IView
    {
        private RenderWindow _app;

        private Image _imgFourmi;
        private Sprite _spriteFourmi;

        private /*const*/ uint WIDTH = 800; // largeur de la fenêtre en pixels
        private /*const*/ uint HEIGHT = 600; // hauteur de la fenêtre en pixels


        // Initialisation de la vue
        public void InitView()
        {

            // Create the main window
            _app = new RenderWindow(new VideoMode(WIDTH, HEIGHT, 32), "Antzz");

            // Setup event handlers
            _app.Closed += new EventHandler(OnClosed);
            _app.KeyPressed += new EventHandler<KeyEventArgs>(OnKeyPressed);
            _app.Resized += new EventHandler<SizeEventArgs>(OnResized);


            // chargement des images

            _imgFourmi = new Image("img/fourmi.png");
            //_imgFourmi = new Image("img/lol.bmp");
            _spriteFourmi = new Sprite(_imgFourmi);

            //new ConfigWin().Show();
        }


        public void setFPS(int fps)
        {
            _app.SetFramerateLimit((uint)fps);
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

            _app.Clear(new Color(200,100,0));

            //WIDTH = _app.Width;
            //HEIGHT = _app.Height;


            int caseW = (int)WIDTH / MainController.Instance.Cols; // largeur d'une case en pixels
            int caseH = (int)HEIGHT / MainController.Instance.Rows; // hauteur d'une case en pixels

            // affichage de la grille

            for (int y = 0; y < MainController.Instance.Rows; ++y) // lignes
            {
                Shape line = Shape.Line(new Vector2(0, y * caseH), new Vector2(WIDTH, y * caseH), 1, new Color(220, 120, 0));
                _app.Draw(line);
            }

            for (int x = 0; x < MainController.Instance.Cols; ++x) // colonnes
            {
                Shape line = Shape.Line(new Vector2(x * caseW, 0), new Vector2(x * caseW, HEIGHT), 1, new Color(220, 120, 0));
                _app.Draw(line);
            }

            // pour chaque petite fourmi
            foreach (Fourmi f in Fourmiliere.Instance.ListFourmis)
            {
                _spriteFourmi.Position = new Vector2(f.PosX * caseW, f.PosY * caseH);
                if(f.Type == Fourmiliere.TYPE_QUEEN) // reine plus grande
                    _spriteFourmi.Scale = new Vector2(((float)0.5), ((float)0.5));
                else
                    _spriteFourmi.Scale = new Vector2(((float)0.3), ((float)0.3));
                _app.Draw(_spriteFourmi);
            }


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
