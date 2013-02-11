using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.Model;

namespace SMA.src.Model
{
    public class Fourmiliere
    {
        private static Fourmiliere _instance;

        public static Fourmiliere Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Fourmiliere();
                }

                return _instance;
            }
        }


        private Fourmiliere()
        {
            
        }



        // reine
        private Queen _reine;

        public Queen Reine
        {
            get { return _reine; }
            set { _reine = value; }
        }


        // liste de toutes les fourmis
        private List<Fourmi> _listFourmis = new List<Fourmi>();


        public List<Fourmi> ListFourmis
        {
            get { return _listFourmis; }
            set { _listFourmis = value; }
        }


        // nombre de chasseuses
        private int _nbrChasseuses;

        public int NbrChasseuses
        {
            get { return _nbrChasseuses; }
            set { _nbrChasseuses = value; }
        }

       /* // nombre de larves
        private int _nbrLarves;

        public int NbrLarves
        {
            get { return _nbrLarves; }
            set { _nbrLarves = value; }
        }*/

        // nombre de nourrices
        private int _nbrNourrices;

        public int NbrNourrices
        {
            get { return _nbrNourrices; }
            set { _nbrNourrices = value; }
        }


        // nombre d'ouvrières
        private int _nbrOuvrieres;

        public int NbrOuvrieres
        {
            get { return _nbrOuvrieres; }
            set { _nbrOuvrieres = value; }
        }


        // nombre total de fourmis
        public int NbrFourmis
        {
            get { return /*_nbrOuvrieres + _nbrNourrices + _nbrLarves + _nbrChasseuses + 1*/ _listFourmis.Count; }
        }


        private int _StockNourriture; // stock de nourriture

        public int StockNourriture
        {
            get { return _StockNourriture; }
            set { _StockNourriture = value; }
        }

        private int _totalNourriture;

        public int TotalNourriture
        {
            get { return _totalNourriture; }
            set { _totalNourriture = value; }
        }

        public double BesoinNourriture() // besoins en nourriture
        {
            //int besoin = NbrFourmis - StockNourriture;
            double besoin = StockNourriture / NbrFourmis;

            if (besoin <= 0)
                besoin = 0.1;

            return 1/besoin * 200 ;
        }


        private int _cols; // nombre de colonnes

        public int Cols
        {
            get { return _cols; }
            set { _cols = value; }
        }


        private int _rows; // nombre de lignes

        public int Rows
        {
            get { return _rows; }
            set { _rows = value; }
        }



        public const int TYPE_CHASSEUSE = 0;
        public const int TYPE_NOURRICE = 1;
        public const int TYPE_OUVRIERE = 2;
        public const int TYPE_QUEEN = 3;

        private int _id = 0;

        // méthode de fabrication d'une Fourmi
        public Fourmi MakeFourmi(int type)
        {
            Fourmi f = null;

            switch (type)
            {
                case TYPE_CHASSEUSE:
                    f = new Chasseuse(type, "hunter_" + _id);
                    _nbrChasseuses++;
                    break;

                case TYPE_NOURRICE:
                    f = new Nourrice(type, "nurse_" + _id);
                    _nbrNourrices++;
                    break;

                case TYPE_OUVRIERE:
                    f = new Ouvriere(type, "worker_" + _id);
                    _nbrOuvrieres++;
                    break;

                case TYPE_QUEEN:
                    f = new Queen(type, "Kyukyuni_" + _id);
                    break;
            }


            _listFourmis.Add(f);

            _id++;

            return f;
        }


        // tue une fourmi
        public void KillFourmi(Fourmi f)
        {
            int type = f.Type;

            switch (type)
            {
                case TYPE_CHASSEUSE:
                    _nbrChasseuses--;
                    break;

                case TYPE_NOURRICE:
                    _nbrNourrices--;
                    break;

                case TYPE_OUVRIERE:
                    _nbrOuvrieres--;
                    break;
            }

            _listFourmis.Remove(f);
        }


        // tue toutes les fourmis pour un reset
        public void KillThemAll()
        {
            NbrChasseuses = 0;
            NbrNourrices = 0;
            NbrOuvrieres = 0;
            _id = 0;

            _listFourmis.Clear();

            //_reine = (Queen)MakeFourmi(TYPE_QUEEN);
            //_terrain = new Terrain();
        }
    }
}
