using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.src.View;
using NPack;
using SMA.Model;
using SMA.src.Model;

namespace SMA.src.Controller
{
    class MainController
    {
        // instance du singleton
        private static MainController _instance;

        public static MainController Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MainController();

                return _instance;
            }
        }


        //MersenneTwister _rand; // Makoto : le retour


        // contrôleur privé pour le singleton
        private MainController()
        {
            // valeurs par défaut pour la simu
            _rows = 100;
            _cols = 100;
            _tourCourant = 0;
            _paused = false;
            //_view = new ViewSFML();
            _fps = 10;
        }


        // permet de relancer la simu avec des options autres que celles par défaut
        public void ResetAll(int nbrcol, int nbrrow, int fps)
        {
            _rows = nbrrow;
            _cols = nbrcol;
            _tourCourant = 0;
            _paused = false;
            //_view = new ViewSFML();
            _fps = fps;

            Fourmiliere.Instance.KillThemAll();

            Execute();
        }


        // Vue
        private IView _view; // pourrait être changé pour un autre type de Vue implémentant IView !

        public IView View
        {
            get { return _view; }
            set { _view = value; }
        }


        private int _cols; // nombre de colonnes

        public int Cols
        {
            get { return _cols; }
            set { _cols = value; }
        }


        private int _rows; // nombre de lignes

        public int Rows
        {
            get { return _rows; }
            set { _rows = value; }
        }


        private int _fps; // framerate

        public int Fps
        {
            get { return _fps; }
            set { _fps = value; }
        }


        private int _tourCourant;

        public int TourCourant
        {
            get { return _tourCourant; }
            set { _tourCourant = value; }
        }




        private bool _paused;

        public bool Paused
        {
            get { return _paused; }
            set { _paused = value; }
        }


        // Méthode principale
        public void Execute()
        {
            if (_view == null)
            {
                _view = new ViewSFML();
                _view.InitView(); // initialisation de la vue
            }


            // on a quelques fourmis de départ

            for (int i = 0 ; i < 10 ; ++i)
                Fourmiliere.Instance.MakeFourmi(Fourmiliere.TYPE_CHASSEUSE);

            for (int i = 0; i < 10; ++i)
                Fourmiliere.Instance.MakeFourmi(Fourmiliere.TYPE_NOURRICE);

            for (int i = 0; i < 30; ++i)
                Fourmiliere.Instance.MakeFourmi(Fourmiliere.TYPE_OUVRIERE);

            
            _view.setFPS(_fps);


            ConfigController.Instance.ShowWin(); // fenêtre de configuration


            // tant que la vue est ouverte et qu'il y a des petites fourmis
            while (_view.IsRunning() && Fourmiliere.Instance.NbrFourmis > 1)
            {
                if (!_paused)
                {
                    Console.WriteLine("\n*** JOUR " + _tourCourant + " ***\n");
                    Console.WriteLine("Nombre de fourmis : " + Fourmiliere.Instance.NbrFourmis);
                    Console.WriteLine("Nombre de fourmis chasseuses : " + Fourmiliere.Instance.NbrChasseuses);
                    Console.WriteLine("Nombre de fourmis ouvrières : " + Fourmiliere.Instance.NbrOuvrieres);
                    Console.WriteLine("Nombre de fourmis nourrices : " + Fourmiliere.Instance.NbrNourrices);

                    // on utilise une copie de la liste car elle peut être modifiée !
                    Fourmi[] list = new Fourmi[Fourmiliere.Instance.NbrFourmis];
                    Fourmiliere.Instance.ListFourmis.CopyTo(list);

                    // pour toutes les fourmis
                    foreach (Fourmi f in list)
                    {
                        f.VieMaVieDeFourmi(_tourCourant);
                    }


                    // reine

                    Fourmiliere.Instance.Reine.Pondre();


                    _tourCourant++;
                }

                _view.UpdateView(); // on met à jour la vue

                GC.Collect();
            }

            Console.WriteLine("\n\nGAME OVER...\n");

            //Console.ReadKey();
        }
    }
}
