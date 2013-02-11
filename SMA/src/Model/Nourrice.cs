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
            _strategieDeplacement = DeplacerNourriceSansLarve;
        }


        // stratégie de marche sans larve : on marche normalement jusqu'à trouver une larve
        public void DeplacerNourriceSansLarve()
        {
            if (Etat == 0)
                return;

            DeplacerNormal();

            foreach(Fourmi f in Fourmiliere.Instance.ListFourmis)
            {
                if(f.Etat == 0 && f.PosX == PosX && f.PosY == PosY) // on est sur la case d'une larve !
                {
                    _myLarve = f;
                    _strategieDeplacement = DeplacerNourriceAvecLarve; // un peu gluant, mais appétissant !
                }
            }


        }

        private Fourmi _myLarve; // c'est bon, on dirait du veau !

        // stratégie de marche avec larve : on emmène la larve à un endroit
        public void DeplacerNourriceAvecLarve()
        {
            if (_myLarve.Etat == 1) // si la larve a évoluée, on la laisse
            {
                _strategieDeplacement = DeplacerNourriceSansLarve;
            }

            else
            {
                // position de l'objectif
                int objectifX = Terrain.Instance.Cols / 2;
                int objectifY = Terrain.Instance.Rows / 2;

                // distance initiale entre la position courante et l'objectif
                int difx = objectifX - PosX;
                int dify = objectifY - PosY;
                double dist = Math.Sqrt(difx * difx + dify * dify);

                double dist2;

                if (dist < 1.5) // si on est assez prêt on laisse tomber la larve
                {
                    _strategieDeplacement = DeplacerNourriceSansLarve;
                }

                else
                {
                        // on tente des pas jusqu'à trouver une direction qui nous rapproche de l'objectif
                        do
                        {
                            CalculerPas();

                            // distance entre la position calculée et l'objectif

                            difx = _newX - objectifX;
                            dify = _newY - objectifY;

                            dist2 = Math.Sqrt(difx * difx + dify * dify);

                        } while (dist2 > dist);


                        // wesh wesh je suis une nourrice qui transporte sa ve-lar

                        if (_newX > 0 && _newX < Terrain.Instance.Cols
                            && _newY > 0 && _newY < Terrain.Instance.Rows
                            && Terrain.Instance.Map[_newX, _newY] == Terrain.TERRAIN_GALLERIE)
                        {
                            PosX = _newX;
                            PosY = _newY;
                        }

                        _myLarve.PosX = PosX;
                        _myLarve.PosY = PosY;
                }
            }
        }

    }
}
