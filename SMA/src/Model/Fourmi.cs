using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.src.Controller;
using SMA.src.Model;

namespace SMA.Model
{
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


        // Méthodes


        public Fourmi(int typ, String nom)
        {
            _naissance = MainController.Instance.TourCourant;
            _type = typ;
            _nom = nom;

            _posX = MainController.Instance.Rows / 2;
            _posY = MainController.Instance.Cols / 2;

            Console.WriteLine(nom + " (type = "+typ+") is born.");
        }

        ~Fourmi()
        {
            Console.WriteLine(_nom + " (type = " + _type + ") is dead.");
        }


        public void deplacer(int toX, int toY)
        {
        }

        public void communiquer()
        {
        }


        public void VieMaVieDeFourmi(int jour)
        {
            int age = jour - Naissance;

            // naissances

            if (Etat == 0) // fourmi encore à l'état de larve
            {
                int p = (int)Distributions.Instance.PseudoAleatoire(0, 1000);

                if (age > p) // Probabilité de (age / 1000) de grandir
                {
                    Etat = 1;
                }
            }


            // morts naturelles

            if(Type != Fourmiliere.TYPE_QUEEN) // la reine est immortelle
            {
                int p = (int)Distributions.Instance.PseudoAleatoire(100, 2000);
                //Console.WriteLine("p = " + p);

                if (age > p) // Probabilité de mourir dans d'atroces souffrances
                {
                    Fourmiliere.Instance.KillFourmi(this); // adieu monde cruel
                }
            }


            // déplacements

            int x = (int)Distributions.Instance.PseudoAleatoire(-6, 5);
            int y = (int)Distributions.Instance.PseudoAleatoire(-6, 5);

            int newX = PosX + x;
            int newY = PosY + y;

            if (newX > 0 && newX < MainController.Instance.Cols)
                PosX = newX;

            if (newY > 0 && newY < MainController.Instance.Rows)
                PosY = newY;
        }

        public void manger(int qtt)
        {
        }
    }
}
