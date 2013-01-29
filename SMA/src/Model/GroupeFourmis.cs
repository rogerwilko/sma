using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Model;

namespace SMA.src.Model
{
    // groupe de fourmis : pattern composite
    public class GroupeFourmis : Fourmi
    {
        private List<Fourmi> _listFourmis;

        public List<Fourmi> ListFourmis
        {
            get { return _listFourmis; }
            set { _listFourmis = value; }
        }

        public GroupeFourmis(int typ, string nom) : base(typ, nom)
        {
        }
    }
}
