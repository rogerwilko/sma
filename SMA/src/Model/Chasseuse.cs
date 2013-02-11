using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Model;

namespace SMA.src.Model
{
    class Chasseuse : Fourmi
    {
        // Propriétés



        // Méthodes

        public Chasseuse(int type, String nom) : base(type, nom)
        {
            _strategieDeplacement = DeplacerChasseuseStandard;
        }


        public void chasser()
        {
        }


        // déplacement tranquilou dans la fourmilière
        public void DeplacerChasseuseStandard()
        {
            if (Etat == 0)
                return;

            DeplacerNormal();

            double p = Distributions.Instance.PseudoAleatoire(0, 100);
            
            if (p > 95) // tiens, si je partais chercher à grailler ?
                _strategieDeplacement = DeplacerChasseuseALaChasse;
        }


        // sa peau de sanglier sur le dos et son fusil bien en main,
        // la fourmi chasseuse s'en va quérir sa proie dans le monde extérieur cruel et sauvage !
        public void DeplacerChasseuseALaChasse()
        {
            // on joue à cache cache avec la View
            PosX = -10;
            PosY = -10;

            double p = Distributions.Instance.PseudoAleatoire(0, 100);

            if (p < 5) // oui, la chasse est une activité dangereuse déconseillée aux petites fourmimoiselles
            {
                Fourmiliere.Instance.KillFourmi(this); // un jour, il s'est fait assassiné ; il en est mort
            }

            else if (p < 20)
            {
                // chérie, je suis de retour !
                
                // vamos a casa
                PosX = 0;
                PosY = 0;

                
                // de la nourriture, merci !

                int qttfood = (int)Distributions.Instance.Gaussienne(250,150);

                Fourmiliere.Instance.StockNourriture += qttfood; // stockamos el food en el stocko de nourrituro

                _strategieDeplacement = DeplacerChasseuseStandard;
            }

            else
            {
                // une chasseuse sachant chassant sans sa chitine est une bonne chasseuse
            }
        }

    }
}
