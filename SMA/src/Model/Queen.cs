using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Model;

namespace SMA.src.Model
{
    // God save the queen
    // I WANT TO BREAAAAK FREEEEEEEE
    public class Queen : Fourmi
    {
        // Propriétés



        // Méthodes

        public Queen(int type, String nom) : base(type, nom)
        {
            Etat = 1;
        }

        public Fourmi Pondre()
        {
            // probabilité de ne pas pondre
            int probaNoPonte = (int)Distributions.Instance.PseudoAleatoire(0, 100);
            if (probaNoPonte > 5)
                return null;


            int probaChasseuse = (int)(Distributions.Instance.Gaussienne(50, 20) * Fourmiliere.Instance.NbrFourmis / (Fourmiliere.Instance.NbrChasseuses + 1)); // probabilité d'une chasseuse
            int probaOuvriere = (int)(Distributions.Instance.Gaussienne(40, 20) * Fourmiliere.Instance.NbrFourmis / (Fourmiliere.Instance.NbrOuvrieres + 1)); // probabilité d'une ouvrière
            int probaNourrice = (int)(Distributions.Instance.Gaussienne(50, 20) * Fourmiliere.Instance.NbrFourmis / (Fourmiliere.Instance.NbrNourrices + 1)); // probabilité d'une nourrice


            Fourmi f;

            if (probaChasseuse >= probaOuvriere && probaChasseuse >= probaNourrice) // chasseuse
                f = Fourmiliere.Instance.MakeFourmi(Fourmiliere.TYPE_CHASSEUSE);

            else if (probaOuvriere >= probaChasseuse && probaOuvriere >= probaNourrice) // ouvrière
                f = Fourmiliere.Instance.MakeFourmi(Fourmiliere.TYPE_OUVRIERE);

            else // nourrice
                f = Fourmiliere.Instance.MakeFourmi(Fourmiliere.TYPE_NOURRICE);

            f.PosX = PosX;
            f.PosY = PosY;

            return f;
        }
    }
}
