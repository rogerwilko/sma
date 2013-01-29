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

        private Image _imgLarve;
        private Sprite _spriteLarve;


        private /*const*/ uint WIDTH = 800; // largeur de la fenêtre en pixels
        private /*const*/ uint HEIGHT = 800; // hauteur de la fenêtre en pixels


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
            _spriteFourmi = new Sprite(_imgFourmi);

            _imgLarve = new Image("img/larve.png");
            _spriteLarve = new Sprite(_imgLarve);

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
                Sprite spr;

                if (f.Etat == 1) // fourmi
                    spr = _spriteFourmi;

                else // larve
                    spr = _spriteLarve;


                spr.Center = new Vector2(spr.Width / 2, spr.Height / 2);


                spr.Position = new Vector2(f.PosX * caseW, f.PosY * caseH);

    
                // orientation


                switch (f.Direction)
                {
                    case Fourmi.DIR_BOTTOM:
                        //spr.FlipY(true);
                        spr.Rotation = 180;
                        break;

                    case Fourmi.DIR_BOTTOMLEFT:
                        spr.Rotation = 135;
                        break;

                    case Fourmi.DIR_BOTTOMRIGHT:
                        spr.Rotation = -135;
                        break;

                    case Fourmi.DIR_LEFT:
                        spr.Rotation = 90;
                        break;

                    case Fourmi.DIR_RIGHT:
                        spr.Rotation = -90;
                        break;

                    case Fourmi.DIR_TOP:
                        spr.Rotation = 0;
                        break;

                    case Fourmi.DIR_TOPLEFT:
                        spr.Rotation = 45;
                        break;

                    case Fourmi.DIR_TOPRIGHT:
                        spr.Rotation = -45;
                        break;
                }

                if (f.Type == Fourmiliere.TYPE_QUEEN) // reine plus grande
                {
                    spr.Scale = new Vector2(((float)0.35), ((float)0.35));
                }

                else
                {
                    spr.Scale = new Vector2(((float)0.20), ((float)0.20));
                    //spr.Color = Color.Red;
                }

                _app.Draw(spr);
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
