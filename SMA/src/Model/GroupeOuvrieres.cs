using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Model;

namespace SMA.src.Model
{
    // groupe de fourmis ouvrières pour creuser des galleries plus larges (avec l'aide de messages olfactifs)
    class GroupeOuvrieres : GroupeFourmis
    {
        private Fourmi _meneuse;

        public Fourmi Meneuse
        {
            get { return _meneuse; }
            set { _meneuse = value; }
        }

        public GroupeOuvrieres()
            : base(Fourmiliere.TYPE_OUVRIERE, "groupe_ouvrieres")
        {
        }
    }
}
