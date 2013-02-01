using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.src.Controller;

namespace SMA.src.Model
{
    public class Terrain
    {
        private static Terrain _instance;

        public static Terrain Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Terrain();

                return _instance;
            }
        }


        private Terrain() { }


        private int _cols;

        public int Cols
        {
            get { return _cols; }
            set { _cols = value; }
        }

        private int _rows;

        public int Rows
        {
            get { return _rows; }
            set { _rows = value; }
        }



        // constantes

        public const int TERRAIN_TERRE = 0;
        public const int TERRAIN_GALLERIE = 1;
        public const int TERRAIN_PIERRE = 2;


        Int16[,] _map;

        public Int16[,] Map
        {
            get { return _map; }
            set { _map = value; }
        }


        // permet  de savoir si une case de coordonnées (x,y) est inclus dans un rectangle de la map
        private bool CaseIsIn(int x, int y, int xbornetopleft, int ybornetopleft, int xbornebottomright, int ybornebottomright)
        {
            return (x >= xbornetopleft) && (x <= xbornebottomright) && (y >= ybornetopleft) && (y <= ybornebottomright);
        }


        // permet de savoir si il y a des blocs de gallerie autour, pour générer des galleries aléatoirement
        private bool someGallerieAutour(int x, int y)
        {
            return false;
        }

        public void MakeTerrain()
        {
            _map = new Int16 [_cols, _rows];

            int xbornetopleft = (_cols / 2) - (_cols / 10);
            int ybornetopleft = (_rows / 2) - (_rows / 10);
            int xbornebottomright = (_cols / 2) + (_rows / 10);
            int ybornebottomright = (_rows / 2) + (_rows / 10);

            for (int i = 0; i < _cols; ++i)
            {
                for (int j = 0; j < _rows; ++j)
                {
                    // trou de départ : 10% de la map au milieu
                    if (CaseIsIn(i, j, xbornetopleft, ybornetopleft, xbornebottomright, ybornebottomright))
                        _map[i, j] = TERRAIN_GALLERIE;

                    // on va générer des cases aléatoirement
                    else
                    {
                        int proba = (int)Distributions.Instance.PseudoAleatoire(0, 100);

                        if (proba < 80)
                            _map[i, j] = TERRAIN_TERRE; // dig it !

                        else if (proba < 82)
                            _map[i, j] = TERRAIN_PIERRE;

                        else // générateur de vraies galleries
                            if(someGallerieAutour(i, j))
                                _map[i, j] = TERRAIN_GALLERIE;
                            else
                                _map[i, j] = TERRAIN_TERRE;
                    }
                }
            }
        }
    }
}
