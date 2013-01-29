using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Model;

namespace SMA.src.Model
{
    // god save the queen
    public class Queen : Fourmi
    {
        // Propriétés



        // Méthodes

        public Queen(int type, String nom) : base(type, nom) { }

        public Fourmi Pondre()
        {
            int probaChasseuse = (int)Distributions.Instance.Gaussienne(50, 20) * Fourmiliere.Instance.NbrFourmis / (Fourmiliere.Instance.NbrChasseuses + 1);
            int probaOuvriere = (int)Distributions.Instance.Gaussienne(50, 20) * Fourmiliere.Instance.NbrFourmis / (Fourmiliere.Instance.NbrOuvrieres + 1);
            int probaNourrice = (int)Distributions.Instance.Gaussienne(50, 20) * Fourmiliere.Instance.NbrFourmis / (Fourmiliere.Instance.NbrNourrices  + 1);

            Fourmi f;

            if (probaChasseuse >= probaOuvriere && probaChasseuse >= probaNourrice) // chasseuse
                f = Fourmiliere.Instance.MakeFourmi(Fourmiliere.TYPE_CHASSEUSE);

            else if (probaOuvriere >= probaChasseuse && probaOuvriere >= probaNourrice) // ouvrière
                f = Fourmiliere.Instance.MakeFourmi(Fourmiliere.TYPE_CHASSEUSE);

            else // nourrice
                f = Fourmiliere.Instance.MakeFourmi(Fourmiliere.TYPE_CHASSEUSE);

            return f;
        }
    }
}
