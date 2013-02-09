using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Model;

namespace SMA.src.Model
{
    class Nourrice : Fourmi
    {
        // Propriétés



        // Méthodes

        public Nourrice(int type, String nom) : base(type, nom)
        {
            _strategieMarche = deplacerNourriceSansLarve;
        }


        // stratégie de marche sans larve : on marche normalement jusqu'à trouver une larve
        public void deplacerNourriceSansLarve()
        {
            deplacerNormal();

            foreach(Fourmi f in Fourmiliere.Instance.ListFourmis)
            {
                if(f.Etat == 0 && f.PosX == PosX && f.PosY == PosY) // on est sur la case d'une larve !
                {
                    _myLarve = f;
                    _strategieMarche = deplacerNourriceAvecLarve; // un peu gluant, mais appétissant !
                }
            }


        }

        private Fourmi _myLarve; // c'est bon, on dirait du veau !

        // stratégie de marche avec larve : on emmène la larve à un endroit
        public void deplacerNourriceAvecLarve()
        {
            if (_myLarve.Etat == 1)
            {
                _strategieMarche = deplacerNourriceSansLarve;
            }

            else
            {
                deplacerNormal();


                // wesh wesh je suis une nourrice qui transporte sa ve-lar

                _myLarve.PosX = PosX;
                _myLarve.PosY = PosY;
            }
        }

    }
}
