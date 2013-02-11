using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.src.Controller;
using SMA.src.Model;

namespace SMA.Model
{
    public delegate void StrategieMarche();


    public class Fourmi
    {
        // Propriétés


        private int _naissance;

        public int Naissance
        {
            get { return _naissance; }
            set { _naissance = value; }
        }


        private int _posX, _posY;

        public int PosX
        {
            get { return _posX; }
            set { _posX = value; }
        }

        public int PosY
        {
            get { return _posY; }
            set { _posY = value; }
        }


        private string _nom;

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        private int _etat = 0; // 0 : oeuf/larve, 1 : adulte

        public int Etat
        {
            get { return _etat; }

            set
            {
                if (value == 1)
                    Console.WriteLine(_nom + " (type = " +_type + ") is evolving.");

                _etat = value;
            }
        }

        private int _type;

        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }


        private int _direction;

        public int Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }


        public const int DIR_LEFT = 0;
        public const int DIR_RIGHT = 1;
        public const int DIR_TOP = 2;
        public const int DIR_BOTTOM = 3;
        public const int DIR_TOPLEFT = 4;
        public const int DIR_TOPRIGHT = 5;
        public const int DIR_BOTTOMLEFT = 6;
        public const int DIR_BOTTOMRIGHT = 7;


        // Méthodes


        public Fourmi(int typ, String nom)
        {
            _naissance = MainController.Instance.TourCourant;
            _type = typ;
            _nom = nom;

            _posX = Terrain.Instance.Cols / 2;
            _posY = Terrain.Instance.Rows / 2;

            Console.WriteLine(nom + " (type = "+typ+") is born.");

            _strategieDeplacement = DeplacerNormal;
        }

        ~Fourmi()
        {
            Console.WriteLine(_nom + " (type = " + _type + ") is dead.");
        }



        // données pour la stratégie de déplacement

        protected StrategieMarche _strategieDeplacement; // stratégie pour le déplacement

        protected int _restePas; // nombre de pas restants dans la direction courante
        protected int _xPas; // direction et vitesse x
        protected int _yPas; // direction et vitesse y

        // nouvelle position calculée (pas forcément la position actuelle si il s'agit d'un mur !)
        protected int _newX;
        protected int _newY;


        // calcul d'un pas aléatoire (direction et distance) et de la nouvelle position (sans toutefois déplacer la Fourmi)
        protected void CalculerPas()
        {
            if (_restePas == 0)
            {
                _restePas = (int)Distributions.Instance.PseudoAleatoire(10, 15);

                _xPas = (int)Distributions.Instance.PseudoAleatoire(-2, 1);
                _yPas = (int)Distributions.Instance.PseudoAleatoire(-2, 1);

                // calcul de la direction

                if (_xPas < 0 && _yPas < 0)
                    _direction = DIR_TOPLEFT;

                else if (_xPas < 0 && _yPas > 0)
                    _direction = DIR_BOTTOMLEFT;

                else if (_xPas > 0 && _yPas < 0)
                    _direction = DIR_TOPRIGHT;

                else if (_xPas > 0 && _yPas > 0)
                    _direction = DIR_BOTTOMRIGHT;

                else if (_xPas == 0 && _yPas < 0)
                    _direction = DIR_TOP;

                else if (_xPas == 0 && _yPas > 0)
                    _direction = DIR_BOTTOM;

                else if (_yPas == 0 && _xPas > 0)
                    _direction = DIR_RIGHT;

                else if (_yPas == 0 && _xPas < 0)
                    _direction = DIR_LEFT;
            }

            else
            {
                _restePas--;
            }

            _newX = PosX + _xPas;
            _newY = PosY + _yPas;
        }


        public void DeplacerNormal()
        {
            if (Etat == 0)
                return;

            CalculerPas();

            if (_newX > 0 && _newX < Terrain.Instance.Cols
                && _newY > 0 && _newY < Terrain.Instance.Rows
                && Terrain.Instance.Map[_newX, _newY] == Terrain.TERRAIN_GALLERIE)
            {
                PosX = _newX;
                PosY = _newY;
            }
        }

        public void Communiquer()
        {
        }


        public void Manger()
        {
            if (Fourmiliere.Instance.StockNourriture != 0) // nourriture restante : on mange
            {
                Fourmiliere.Instance.StockNourriture--;
                Fourmiliere.Instance.TotalNourriture++;
            }

            else // famine
            {
                if (Type != Fourmiliere.TYPE_QUEEN) // la reine est immortelle
                {
                    int p = (int)Distributions.Instance.Gaussienne(50, 30);

                    if (p > 80) // Probabilité de mourir de faim
                    {
                        Fourmiliere.Instance.KillFourmi(this);
                    }
                }
            }
        }


        public void VieMaVieDeFourmi(int jour)
        {
            int age = jour - Naissance;

            // naissances

            if (Etat == 0) // fourmi encore à l'état de larve
            {
                int p = (int)Distributions.Instance.PseudoAleatoire(0, 5000);

                if (age > p) // Probabilité de (age / 5000) de grandir
                {
                    int centerX = Terrain.Instance.Cols / 2;
                    int centerY = Terrain.Instance.Rows / 2;

                    // on peut éclore seulement quand on est situé dans le couvoir au milieu de la map !
                    if ((PosX > centerX - 5) && ((PosX < centerX + 5)) && (PosY > centerY - 5) && ((PosY < centerY + 5)))
                        Etat = 1;
                }
            }


            // morts naturelles

            if(Type != Fourmiliere.TYPE_QUEEN) // la reine est immortelle
            {
                int p = (int)Distributions.Instance.Gaussienne(2500, 500) ;
                //Console.WriteLine("p = " + p);

                if (age > p) // Probabilité de mourir dans d'atroces souffrances
                {
                    Fourmiliere.Instance.KillFourmi(this); // adieu monde cruel
                }
            }


            // déplacements

            _strategieDeplacement();
            _strategieDeplacement();
            _strategieDeplacement();
            //_strategieDeplacement();

            // miam

            if(Etat != 0)
                Manger();
        }

        public void manger(int qtt)
        {
        }
    }
}
