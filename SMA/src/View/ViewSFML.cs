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

        /*private Image _imgFourmi;
        private Sprite _spriteFourmi;*/

        private Image[] _imgFourmi = new Image[8];
        private Sprite[] _spriteFourmi = new Sprite[8];

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

            _imgFourmi[0] = new Image("img/fourmi_top.png");
            _spriteFourmi[0] = new Sprite(_imgFourmi[0]);

            _imgFourmi[1] = new Image("img/fourmi_topright.png");
            _spriteFourmi[1] = new Sprite(_imgFourmi[1]);

            _imgFourmi[2] = new Image("img/fourmi_right.png");
            _spriteFourmi[2] = new Sprite(_imgFourmi[2]);

            _imgFourmi[3] = new Image("img/fourmi_bottomright.png");
            _spriteFourmi[3] = new Sprite(_imgFourmi[3]);

            _imgFourmi[4] = new Image("img/fourmi_bottom.png");
            _spriteFourmi[4] = new Sprite(_imgFourmi[4]);

            _imgFourmi[5] = new Image("img/fourmi_bottomleft.png");
            _spriteFourmi[5] = new Sprite(_imgFourmi[5]);

            _imgFourmi[6] = new Image("img/fourmi_left.png");
            _spriteFourmi[6] = new Sprite(_imgFourmi[6]);

            _imgFourmi[7] = new Image("img/fourmi_topleft.png");
            _spriteFourmi[7] = new Sprite(_imgFourmi[7]);


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

            int caseW = (int)WIDTH / Terrain.Instance.Cols; // largeur d'une case en pixels
            int caseH = (int)HEIGHT / Terrain.Instance.Rows; // hauteur d'une case en pixels

            // affichage de la grille

            for (int y = 0; y < Terrain.Instance.Rows; ++y) // lignes
            {
                Shape line = Shape.Line(new Vector2(0, y * caseH), new Vector2(WIDTH, y * caseH), 1, new Color(220, 120, 0));
                _app.Draw(line);
            }

            for (int x = 0; x < Terrain.Instance.Cols; ++x) // colonnes
            {
                Shape line = Shape.Line(new Vector2(x * caseW, 0), new Vector2(x * caseW, HEIGHT), 1, new Color(220, 120, 0));
                _app.Draw(line);
            }


            // affichage du terrain
            
            Int16[,] map = Terrain.Instance.Map;

            for (int x = 0; x < Terrain.Instance.Cols; ++x)
            {
                for (int y = 0; y < Terrain.Instance.Rows; ++y)
                {
                    if (map[x,y] == Terrain.TERRAIN_GALLERIE)
                    {
                        Shape rect = Shape.Rectangle(new Vector2(x * caseW, y * caseH), new Vector2(x * caseW + caseW, y * caseH + caseH), new Color(250, 150, 50), 1, new Color(220, 120, 0));
                        _app.Draw(rect);
                    }

                    else if (map[x, y] == Terrain.TERRAIN_PIERRE)
                    {
                        Shape rect = Shape.Rectangle(new Vector2(x * caseW, y * caseH), new Vector2(x * caseW + caseW, y * caseH + caseH), new Color(120, 150, 70), 1, new Color(220, 120, 0));
                        _app.Draw(rect);
                    }
                }
            }


            // pour chaque petite fourmi
            foreach (Fourmi f in Fourmiliere.Instance.ListFourmis)
            {
                Sprite spr = null;


                // choix du sprite

                if (f.Etat == 0) // larve
                    spr = _spriteLarve;

                else // fourmi
                {
                    // orientation

                    switch (f.Direction)
                    {
                        case Fourmi.DIR_BOTTOM:
                            //spr.FlipY(true);
                            //spr.Rotation = 180;
                            spr = _spriteFourmi[4];
                            break;

                        case Fourmi.DIR_BOTTOMLEFT:
                            //spr.Rotation = 135;
                            spr = _spriteFourmi[5];
                            break;

                        case Fourmi.DIR_BOTTOMRIGHT:
                            //spr.Rotation = -135;
                            spr = _spriteFourmi[3];
                            break;

                        case Fourmi.DIR_LEFT:
                            //spr.Rotation = 90;
                            spr = _spriteFourmi[6];
                            break;

                        case Fourmi.DIR_RIGHT:
                            //spr.Rotation = -90;
                            spr = _spriteFourmi[2];
                            break;

                        case Fourmi.DIR_TOP:
                            //spr.Rotation = 0;
                            spr = _spriteFourmi[0];
                            break;

                        case Fourmi.DIR_TOPLEFT:
                            //spr.Rotation = 45;
                            spr = _spriteFourmi[7];
                            break;

                        case Fourmi.DIR_TOPRIGHT:
                            //spr.Rotation = -45;
                            spr = _spriteFourmi[1];
                            break;
                    }
                }


                // taille

                if (f.Type == Fourmiliere.TYPE_QUEEN) // reine plus grande
                {
                    spr.Scale = new Vector2(((float)0.35), ((float)0.35));
                }

                else
                {
                    spr.Scale = new Vector2(((float)0.20), ((float)0.20));
                }



                //spr.Center = new Vector2(spr.Width / 2, spr.Height / 2);

                spr.Position = new Vector2(f.PosX * caseW - (spr.Width - caseW) / 2, f.PosY * caseH - (spr.Height - caseH) / 2);


                

                // couleurs au-dessus des fourmis selon le type activées
                if (MainController.Instance.Colored)
                {
                    Color colHead = new Color(255, 255, 255); ;

                    switch (f.Type) // différentes couleurs selon le type de la fourmi
                    {
                        case Fourmiliere.TYPE_CHASSEUSE:
                            colHead = new Color(255, 0, 0);
                            break;

                        case Fourmiliere.TYPE_NOURRICE:
                            colHead = new Color(50, 50, 255);
                            break;

                        case Fourmiliere.TYPE_OUVRIERE:
                            colHead = new Color(0, 255, 0);
                            break;

                        case Fourmiliere.TYPE_QUEEN:
                            colHead = new Color(255, 255, 0);
                            break;
                    }

                    Shape line = Shape.Line(new Vector2(f.PosX * caseW - 7, f.PosY * caseH - 10), new Vector2(f.PosX * caseW + spr.Width, f.PosY * caseH - 10), 2, colHead);
                    _app.Draw(line);
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


        public void Screenshot(String path = "screen.bmp")
        {
            _app.Capture().SaveToFile(path);
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
