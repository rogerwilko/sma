using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.src.View;
using NPack;

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


        MersenneTwister _rand; // Makoto : le retour


        // contrôleur privé pour le singleton
        private MainController()
        {
        }



        // Vue
        IView view = new ViewSFML(); // pourrait être changé pour un autre type de Vue implémentant IView !


        // Méthode principale
        public void Execute()
        {
            _rand = new MersenneTwister((int)DateTime.Now.Ticks);

            view.InitView(); // initialisation de la vue

            while (view.IsRunning()) // tant que la vue est ouverte
            {
                Console.WriteLine(_rand.Next(0, 100));
                view.UpdateView(); // on met à jour la vue
            }
        }
    }
}
