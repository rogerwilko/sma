using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Model;

namespace SMA.src.Model
{
    class Ouvriere : Fourmi
    {
        // Propriétés



        // Méthodes

        public Ouvriere(int type, String nom) : base(type, nom)
        {
            _strategieMarche = deplacerOuvriere; // on change la stratégie par défaut
        }


        // déplacement spécifique aux ouvrières
        public void deplacerOuvriere()
        {
            if (Etat == 0)
                return;

            deplacerNormal();

            // terre à l'horizon !
            if (_newX > 0 && _newX < Terrain.Instance.Cols
                && _newY > 0 && _newY < Terrain.Instance.Rows
                && Terrain.Instance.Map[_newX, _newY] == Terrain.TERRAIN_TERRE)
            {
                // on tente de creuser

                int p = (int)Distributions.Instance.PseudoAleatoire(0, 100);

                if (p > 80) // on parvient à creuser
                {
                    Terrain.Instance.Map[_newX, _newY] = Terrain.TERRAIN_GALLERIE;
                }
            }
        }
    }
}
