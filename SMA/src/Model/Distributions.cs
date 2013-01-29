using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPack;

namespace SMA.src.Model
{
    public class Distributions
    {
        private static Distributions _instance;

        public static Distributions Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Distributions();
 
                return _instance;
            }
        }

        private Distributions()
        {
            _mt = new MersenneTwister((int)DateTime.Now.Ticks);
        }

    
        MersenneTwister _mt;
        private bool _gauss = false;
        private double _gaussResult = 0.0;

        public double Unif()
        {
            return _mt.NextDouble(true);
        }

        public double Gaussienne(double moyenne, double sigma)
        {

            if(sigma <= 0)
                throw new ArgumentOutOfRangeException("sigam","Must be greater than zero.");
            
            if(_gauss)
            {
                _gauss = false;
                return (_gaussResult*sigma + moyenne);
            }

            double x,y,sqrt;
           
            do
            {
                x = 2.0*Unif() - 1.0;
                y = 2.0*Unif() - 1.0;
			    sqrt = x*x + y*y;
            } while ( sqrt >= 1.0 || sqrt == 0.0 );
            
            sqrt = Math.Sqrt( - 2.0*Math.Log(sqrt)/sqrt);
		    _gaussResult = sqrt*x;
            _gauss = true;

            return (y*sqrt*sigma + moyenne);
        }

        public int PileOuFace()
        {
            double x = Unif();
            return (x > 0.5)? 0 : 1;
        }
 

        public double PseudoAleatoire(long min, long max)
        {
            if(min > max)
                throw new ArgumentOutOfRangeException("min","Min is greater than max.");
           return (min + Unif()*(max - min + 1));
        }

        public int Histo()
        {
            throw new NotImplementedException();
        }
        

    }
}
