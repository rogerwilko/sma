using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPack
{
    class Distributions
    {
    
        MersenneTwister mt = new MersenneTwister((int) DateTime.Now.Ticks);
        private bool _gauss = false;
        private double _gaussResult = 0.0;

         double Unif()
        {
            return mt.NextDouble(true);
        }

        double Gaussienne(double moyenne, double sigma)
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

        int PileOuFace()
        {
            double x = Unif();
            return (x > 0.5)? 0 : 1;
        }
 

        double PseudoAleatoire(long min, long max)
        {
            if(min > max)
                throw new ArgumentOutOfRangeException("min","Min is greater than max.");
           return (min + Unif()*(max - min + 1));
        }

        int Histo()
        {
            throw new NotImplementedException();
        }
        

    }
}
