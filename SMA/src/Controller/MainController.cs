﻿using System;
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
            Terrain.Instance.Rows = 100;
            Terrain.Instance.Cols = 100;
            //Terrain.Instance.MakeTerrain();
            //_tourCourant = 0;
            //_paused = false;
            //_colored = false;
            //_view = new ViewSFML();
            _fps = 10;
        }


        // permet de relancer la simu avec des options autres que celles par défaut
        public void ResetAll(int nbrcol, int nbrrow, int fps)
        {
            Terrain.Instance.Rows = nbrrow;
            Terrain.Instance.Cols = nbrcol;
            //Terrain.Instance.MakeTerrain();
            //_tourCourant = 0;
            //_paused = false;
            // colored = false;
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

        private bool _colored;

        public bool Colored
        {
            get { return _colored; }
            set { _colored = value; }
        }


        // Méthode principale
        public void Execute()
        {
            if (_view == null)
            {
                _view = new ViewSFML();
                _view.InitView(); // initialisation de la vue
            }


            _tourCourant = 0;
            _paused = false;
            _colored = false;


            // création et ajout de l'unique reine à la fourmilière
            Fourmiliere.Instance.Reine = (Queen)Fourmiliere.Instance.MakeFourmi(Fourmiliere.TYPE_QUEEN);

            Fourmiliere.Instance.MakeFourmi(Fourmiliere.TYPE_NOURRICE);


            Fourmiliere.Instance.StockNourriture = 5000; // nourriture de départ
            Fourmiliere.Instance.TotalNourriture = 0;

            Terrain.Instance.MakeTerrain(); // création du terrain


            _view.setFPS(_fps);


            ConfigController.Instance.ShowWin(); // fenêtre de configuration


            // tant que la vue est ouverte et qu'il y a des petites fourmis
            while (_view.IsRunning() /*&& Fourmiliere.Instance.NbrFourmis > 1*/)
            {
                if (!_paused)
                {
                    Console.WriteLine("\n*** JOUR " + _tourCourant + " ***\n");
                    Console.WriteLine("Nombre de fourmis : " + Fourmiliere.Instance.NbrFourmis);
                    Console.WriteLine("Nombre de fourmis chasseuses : " + Fourmiliere.Instance.NbrChasseuses);
                    Console.WriteLine("Nombre de fourmis ouvrières : " + Fourmiliere.Instance.NbrOuvrieres);
                    Console.WriteLine("Nombre de fourmis nourrices : " + Fourmiliere.Instance.NbrNourrices);
                    Console.WriteLine("Stocks de nourriture : " + Fourmiliere.Instance.StockNourriture);
                    Console.WriteLine("Nourriture totale consommée : " + Fourmiliere.Instance.TotalNourriture);

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
